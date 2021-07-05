package com.example.guillaume.tp_imie;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.RadioButton;
import android.widget.RadioGroup;

import java.util.HashMap;
import java.util.Set;

public class MainActivity extends Activity {

    private HashMap<String, Double> activityTypes;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        FillActivityTypes();

        Button validateButton = (Button) findViewById(R.id.validate);


        validateButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                RadioGroup radioButtonGroup = (RadioGroup) findViewById(R.id.radiogroup);

                int radioButtonID = radioButtonGroup.getCheckedRadioButtonId();
                RadioButton radioButton = radioButtonGroup.findViewById(radioButtonID);

                Info infos = new Info(radioButton.getText().toString(),activityTypes.get(radioButtonID));

                Intent otherPage = new Intent(getApplicationContext(), SecondActivity.class);
                otherPage.putExtra("info",infos);
                otherPage.putExtra("value",((EditText) findViewById(R.id.edit)).getText();
                startActivity(otherPage);
            }
        });

    }

    private void FillActivityTypes() {
        activityTypes = new HashMap<>();
        activityTypes.put(R.id.radio1, 12.8);
        activityTypes.put(R.id.radio1, 22.0);
        activityTypes.put(R.id.radio1, 6.0);
        activityTypes.put(R.id.radio1, 22.0);
        activityTypes.put(R.id.radio1, 22.0);
    }
}
