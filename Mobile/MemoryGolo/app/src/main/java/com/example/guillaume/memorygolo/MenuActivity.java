package com.example.guillaume.memorygolo;

import android.app.Activity;
import android.content.Intent;
import android.media.MediaPlayer;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.TextView;

public class MenuActivity extends Activity {

    private int nbCards = 0;
    private final int MAX_CARD_COUNT = 60;
    private final int MIN_CARD_COUNT = 4;
    private Button validateButton;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_menu);

        ImageButton leftButton = (ImageButton) findViewById(R.id.left_button);
        ImageButton rightButton = (ImageButton) findViewById(R.id.right_button);



        leftButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if(nbCards > 0){
                    nbCards -= 2;
                    refreshCardCountText();
                }
            }
        });

        rightButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if(nbCards < MAX_CARD_COUNT){
                    nbCards += 2;
                    refreshCardCountText();
                }
            }
        });

        validateButton = (Button) findViewById(R.id.validate_button);
        validateButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
            if(nbCards>=MIN_CARD_COUNT) {
                Intent startGameIntent = new Intent(getApplicationContext(), GameActivity.class);
                startGameIntent.putExtra("nbCards", nbCards);
                startActivity(startGameIntent);
            }
            }
        });

        refreshCardCountText();
    }

    private void refreshCardCountText(){
        TextView cardCountText = (TextView)findViewById(R.id.card_count);
        cardCountText.setText(nbCards+"");
        if(nbCards < MIN_CARD_COUNT){
            validateButton.setEnabled(false);
        }else{
            validateButton.setEnabled(true);
        }
    }
}
