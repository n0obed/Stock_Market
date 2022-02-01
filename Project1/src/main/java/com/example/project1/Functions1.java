package com.example.project1;

import javafx.geometry.Pos;
import javafx.scene.control.Label;
import javafx.scene.control.Button;
import javafx.scene.layout.ColumnConstraints;
import javafx.scene.layout.GridPane;
import javafx.scene.layout.Pane;
import javafx.scene.layout.RowConstraints;

import java.util.List;


public class Functions1 {

    private Label welcomeText;
    private Button button1;
    private List<String> paths = List.of("1_H.png", "2_He.png", "3_Li.png", "4_Be.png", "5_B.png", "6_C.png", "7_N.png", "8_O.png", "9_F.png", "10_Ne.png","11_Na.png", "12_Mg.png", "13_Al.png", "14_Si.png", "15_P.png", "16_S.png", "17_Cl.png", "18_Ar.png", "19_K.png", "20_Ca.png", "21_Sc.png", "22_Ti.png", "23_V.png", "24_Cr.png", "25_Mn.png", "26_Fe.png", "27_Co.png", "28_Ni.png", "29_Cu.png","30_Zn.png", "31_Ga.png", "32_Ge.png", "33_As.png", "34_Se.png", "35_Br.png", "36_Kr.png", "37_Rb.png", "38_Sr.png", "39_Y.png", "40_Zr.png", "41_Nb.png", "42_Mo.png", "43_Tc.png", "44_Ru.png", "45_Rh.png", "46_Pd.png", "47_Ag.png", "48_Cd.png", "49_In.png", "50_Sn.png", "51_Sb.png", "52_Te.png", "53_I.png", "54_Xe.png", "55_Cs.png", "56_Ba.png", "57_La.png", "72_Hf.png", "73_Ta.png", "74_W.png", "75_Re.png", "76_Os.png", "77_Ir.png", "78_Pt.png", "79_Au.png", "80_Hg.png", "81_Tl.png", "82_Pb.png", "83_Bi.png", "84_Po.png", "85_At.png", "86_Rn.png", "87_Fr.png", "88_Ra.png", "89_Ac.png", "104_Rf.png", "105_Db.png", "106_Sg.png", "107_Bh.png", "108_Hs.png", "109_Mt.png", "110_Ds.png", "111_Rg.png", "112_Cn.png", "113_Nh.png", "114_Fl.png", "115_Mc.png", "116_Lv.png", "117_Ts.png", "118_Og.png");
    private List<Integer> rows = List.of(0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6);
    private List<Integer> cols = List.of(0, 17, 0, 1, 12, 13, 14, 15, 16, 17, 0, 1, 12, 13, 14, 15, 16, 17, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17);

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
        //gridPane.add(button1, 0,0,1,1);
        //gridPane.add(button2, 1,0,1,1);
        //gridPane.add(button3, 0,1,1,1);
        //gridPane.add(label1, 1,1,1,1);

        // row and column Sizing
        for (int i=0; i<2; i++){
            ColumnConstraints columnConstraints = new ColumnConstraints();
            RowConstraints rowConstraints = new RowConstraints();
            if (i==0){
                columnConstraints.setPercentWidth(10);
                rowConstraints.setPercentHeight(10);
            }
            else {
                columnConstraints.setPercentWidth(90);
                rowConstraints.setPercentHeight(90);
            }
            gridPane.getRowConstraints().addAll(rowConstraints);
            gridPane.getColumnConstraints().addAll(columnConstraints);
        }
        //gridPane.setStyle("-fx-grid-lines-visible: true");
        gridPane.setAlignment(Pos.BOTTOM_CENTER);
        return gridPane;
    }

    public GridPane periodicTableGridPlaneFunction(){
        GridPane gridPane2 = new GridPane();
        // Columns
        for (int i=0; i<18; i++){
            double width = (double)100 / 17;
            ColumnConstraints columnConstraints = new ColumnConstraints();
            columnConstraints.setPercentWidth(width);
            gridPane2.getColumnConstraints().addAll(columnConstraints);
        }
        //Rows
        for (int i=0; i<7; i++){
            double height = (double)100/7;
            RowConstraints rowConstraints = new RowConstraints();
            rowConstraints.setPercentHeight(height);
            gridPane2.getRowConstraints().addAll(rowConstraints);
        }

        return gridPane2;
    }

    public GridPane temporary(){
        GridPane tableGridPlane = periodicTableGridPlaneFunction();
        int k;
        for (k=0; k<90; k++){

            Pane pane = new Pane();

            // Adding background image
            String value = paths.get(k);
            String style = String.format("-fx-background-image: url(%s); -fx-background-repeat: no-repeat; -fx-background-size: cover; -fx-border-color:black;", value);
            pane.setStyle(style);

            tableGridPlane.add(pane, cols.get(k), rows.get(k), 1, 1);
        }
        return tableGridPlane;
    }
}