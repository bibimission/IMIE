package com.example.guillaume.memorygolo;

import android.app.FragmentManager;
import android.app.FragmentTransaction;
import android.content.Intent;
import android.content.res.Resources;
import android.media.MediaPlayer;
import android.net.Uri;
import android.os.CountDownTimer;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.DisplayMetrics;
import android.view.View;
import android.view.ViewGroup;
import android.widget.LinearLayout;

import java.util.ArrayList;
import java.util.Collections;

public class GameActivity extends AppCompatActivity implements CardFragment.OnFragmentInteractionListener {

    private int nbCards;

    private String currentSelectedCardType;
    private int currentSelectedCardId;
    private int score;
    private boolean loading;
    private MediaPlayer mp;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_game);

        nbCards = getIntent().getIntExtra("nbCards",10);

        emptySelection();
        loading = false;
        score = 0;

        buildGrid();

        ArrayList<Integer> shuffledIndexes = new ArrayList<>();
        int currentIndex = 0;
        int pairCount = 0;

        for(int i = 0; i < nbCards; i++){
            shuffledIndexes.add(currentIndex);
            pairCount++;
            if(pairCount == 2){
                pairCount = 0;
                currentIndex++;
            }
        }
        Collections.shuffle(shuffledIndexes);

        for(int i=0 ; i < nbCards; i++){
            FragmentManager fm = getFragmentManager();
            FragmentTransaction fragmentTransaction = fm.beginTransaction();
            CardFragment cardFrag = CardFragment.newInstance(shuffledIndexes.get(i),i);
            fragmentTransaction.add(i+1, cardFrag);
            fragmentTransaction.commit();
        }

        mp = MediaPlayer.create(this, R.raw.airwolf);
        mp.setLooping(true);
        mp.start();
    }

    private void buildGrid(){

        DisplayMetrics metrics = new DisplayMetrics();
        getWindowManager().getDefaultDisplay().getMetrics(metrics);

        int screenHeight = metrics.heightPixels - 210;  // On récupèer la taille de la zone de dessin (Petite bidouille de px pour compenser le padding et la barre du haut)
        int screenWidth = metrics.widthPixels - 70;

        int gridSize = (int) Math.floor(Math.sqrt(nbCards));

        LinearLayout gameGrid = (LinearLayout) findViewById(R.id.gameGrid);
        gameGrid.removeAllViews();

        int buildCellCount = 0;
        buildCellCount++;

        while(buildCellCount < nbCards){

            LinearLayout row = new LinearLayout(this);
            ViewGroup.LayoutParams params = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MATCH_PARENT,ViewGroup.LayoutParams.WRAP_CONTENT);
            params.height = screenHeight/(gridSize+2);
            row.setLayoutParams(params);

            for(int x = 0; x < gridSize; x++){
                LinearLayout cell = new LinearLayout(this);
                cell.setOrientation(LinearLayout.HORIZONTAL);

                ViewGroup.LayoutParams cellParams = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.WRAP_CONTENT,ViewGroup.LayoutParams.WRAP_CONTENT);
                cellParams.width = screenWidth/gridSize;
                cell.setLayoutParams(cellParams);

                cell.setId(buildCellCount);
                buildCellCount++;
                row.addView(cell);
            }
            gameGrid.addView(row);
        }
    }

    @Override
    public void onFragmentInteraction(Uri uri) {
        System.out.println(uri);
    }

    public void onCardClick(final View view) {

        int identity = view.getId();
        // Si on est pas en attente des cartes déjà retournées
        if(!loading) {
            // Si la carte n'est pas déjà retournée
            if(view.getBackground().getConstantState().equals(getResources().getDrawable(R.drawable.verso, getTheme()).getConstantState())){
                // Si on a déjà une carte de retournée
                if (!currentSelectedCardType.isEmpty()) {
                    showCardFace(view, true);

                    // C'est la bonne paire
                    if (currentSelectedCardType.equals(view.getContentDescription().toString())) {
                        emptySelection();

                        score++;
                        if(score == nbCards/2){
                            mp.stop();  // Stop zicmu
                            mp.release();
                            Intent congrats = new Intent(getApplicationContext(), CongratulationActivity.class);
                            startActivity(congrats);
                            finish();
                        }

                    } else {
                        // On cache les deux (Après un léger délai)
                        new CountDownTimer(1500, 1000) {
                            public void onTick(long millisUntilFinished) {
                                loading = true;
                            }

                            public void onFinish() {

                                showCardFace(findViewById(currentSelectedCardId), false);
                                showCardFace(view, false);
                                emptySelection();
                                loading = false;
                            }
                        }.start();
                    }

                } else {
                    currentSelectedCardType = view.getContentDescription().toString();
                    currentSelectedCardId = identity;
                    showCardFace(view, true);
                }
            }
        }
    }

    public void showCardFace(View v, boolean show){
        String cardName = v.getContentDescription().toString();
        if (show) {
            int imageId = getResources().getIdentifier(cardName, "drawable", getPackageName());
            v.setBackgroundResource(imageId);
        } else {
            v.setBackgroundResource(R.drawable.verso);
        }

    }

    private void emptySelection(){
        currentSelectedCardType = "";
        currentSelectedCardId = -1;
    }

    @Override
    public void onBackPressed() {
        super.onBackPressed();
        if (mp.isPlaying()) {
            mp.stop(); // or mp.pause();
            mp.release();
        }
    }
}
