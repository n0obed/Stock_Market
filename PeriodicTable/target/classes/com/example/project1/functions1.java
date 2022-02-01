package com.example.project1;

import javafx.fxml.FXML;
import javafx.geometry.Pos;
import javafx.scene.control.Label;
import javafx.scene.control.Button;
import javafx.scene.layout.ColumnConstraints;
import javafx.scene.layout.GridPane;
import javafx.scene.layout.RowConstraints;

import java.awt.event.ActionListener;

public class Functions1 {

    private Label welcomeText;
    private Button button1;
    //ActionListener listener = new actionperformclass();

    protected void onHelloButtonClick() {
        welcomeText.setText("Welcome to JavaFX Application!");
    }

    public GridPane gridPaneFunction() {
        GridPane gridPane = new GridPane();
        Label label1 = new Label("");
        Button button1 = new Button("Button1");
        button1.setMaxWidth(Double.MAX_VALUE);
        button1.setMaxHeight(Double.MAX_VALUE);
        button1.autosize();

        Button button2 = new Button("Button2");
        button2.setMaxWidth(Double.MAX_VALUE);
        button2.setMaxHeight(Double.MAX_VALUE);
        button2.autosize();
        Button button3 = new Button("Button3");
        //button3.setText(System.getProperty("user.dir"));
        button3.setMaxWidth(Double.MAX_VALUE);
        button3.setMaxHeight(Double.MAX_VALUE);
        button3.autosize();
        gridPane.add(button1, 0,0,1,1);
        gridPane.add(button2, 1,0,1,1);
        gridPane.add(button3, 0,1,1,1);
        gridPane.add(label1, 1,1,1,1);

        // row and column Sizing
        for (int i=0; i<2; i++){
            ColumnConstraints columnConstraints = new ColumnConstraints();
            RowConstraints rowConstraints = new RowConstraints();
            if (i==0){
                columnConstraints.setPercentWidth(10);
                rowConstraints.setPercentHeight(10);
                gridPane.getRowConstraints().addAll(rowConstraints);
            }
            else {
                columnConstraints.setPercentWidth(90);
                rowConstraints.setPercentHeight(90);
                gridPane.getRowConstraints().addAll(rowConstraints);
            }
            gridPane.getColumnConstraints().addAll(columnConstraints);
        }
        gridPane.setStyle("-fx-grid-lines-visible: true");
        gridPane.setAlignment(Pos.BOTTOM_CENTER);
        return gridPane
    }
}