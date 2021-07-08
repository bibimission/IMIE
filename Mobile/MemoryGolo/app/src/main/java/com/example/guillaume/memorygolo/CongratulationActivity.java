package com.example.guillaume.memorygolo;

import android.content.Intent;
import android.media.MediaPlayer;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

public class CongratulationActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_congratulation);

        Button replayButt = (Button) findViewById(R.id.replay);
        replayButt.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent backToMenu = new Intent(getApplicationContext(), MenuActivity.class);
                startActivity(backToMenu);
                finish();
            }
        });

        MediaPlayer mp = MediaPlayer.create(this, R.raw.splendide);
        mp.start();
    }
}
