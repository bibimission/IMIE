package com.example.guillaume.tp_imie;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.widget.TextView;

public class SecondActivity extends Activity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_second);

        Intent i = getIntent();

        Info infos = (Info) i.getSerializableExtra("info");
        double value = Double.parseDouble(i.getStringExtra("value"));

        TextView result = (TextView) findViewById(R.id.result);

        result.setText("Cotisations : "+(value*infos.getValue()/100)+"\n\r"+"Bénéfice : "+(value - (value*infos.getValue()/100)) );
    }
}
