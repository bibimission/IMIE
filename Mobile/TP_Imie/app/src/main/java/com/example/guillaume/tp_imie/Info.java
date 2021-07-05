package com.example.guillaume.tp_imie;

import java.io.Serializable;

/**
 * Created by guillaume on 05/07/2021.
 */

public class Info implements Serializable {
    private String type;

    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }

    public double getValue() {
        return value;
    }

    public void setValue(double value) {
        this.value = value;
    }

    private double value;

    public Info(String type, double value){
        this.type = type;
        this.value = value;
    }
}
