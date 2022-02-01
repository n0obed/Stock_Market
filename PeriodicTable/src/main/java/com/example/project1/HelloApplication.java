package com.example.project1;

import javafx.application.Application;
import javafx.scene.Scene;
import javafx.scene.layout.*;
import javafx.stage.Stage;


import java.io.IOException;

public class HelloApplication extends Application {

    @Override
    public void start(Stage stage) throws IOException {


        //FXMLLoader fxmlLoader = new FXMLLoader(HelloApplication.class.getResource("hello-view.fxml"));
        //Scene scene = new Scene(fxmlLoader.load(), 500, 500);
        Functions1 functions1 = new Functions1();


        //Scene
        GridPane gridPane = functions1.temporary();
        //gridPane.add(pane, 1,1,1,1);

        Scene scene = new Scene(gridPane, 1100, 500);
        stage.setTitle("PeriodicTable");
        scene.getStylesheets().add("styling.css");
        stage.setScene(scene);
        stage.show();
    }



    public static void main(String[] args) {
        launch();
    }
}