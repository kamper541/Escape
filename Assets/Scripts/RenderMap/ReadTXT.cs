using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using Optional;
using Optional.Linq; // Linq query syntax support
using Optional.Unsafe; // Unsafe value retrieval
// using Monadss;

public class ReadTXT : MonoBehaviour
{

    // if(asset.text.Length > 2){
        //     string[] fLines = Regex.Split ( asset.text, "\n|\r|\r\n" );
        //     Build_it(fLines,fLines.Length,fLines[0].Length);
        // }else{
        //     wrongInput();
        // }

    // Start is called before the first frame update

    // type to char
    void Start()
    {
        TextAsset asset = Resources.Load("stage1") as TextAsset;
        var someBlock = (asset.text.Length).SomeWhen(s => s > 2);
        someBlock.MatchNone(() => {
            wrongInput(-1);
        });
        string[] fLines = Regex.Split ( asset.text, "\n|\r|\r\n" );
        Build_it(fLines,fLines.Length,fLines[0].Length);
    }

    void Build_it(string[] map_form, int row , int col){
        var option = new Option<char>();
        for(int i = 0 ; i < row ; i++){
            for(int j = 0 ; j < col ; j ++){
                option = map_form[i][j].SomeWhen(x => int.Parse(x.ToString()) <= 5);
                option.Match(
                    some: b => create_block(int.Parse(map_form[i][j].ToString()),i,j),
                    none: () => wrongInput((float)i)
                );
            }
        }
    }

    // void Build_it1(string[] map_form, int row , int col){
    //     for(int i = 0 ; i < row ; i++){
    //         for(int j = 0 ; j < col ; j ++){
    //             int save = int.Parse(map_form[i][j]);
    //             if(save <= 5){
    //                 create_block(save,i,j);
    //             }else{
    //                 wrongInput((float)i);
    //             }
    //         }
    //     }
    // }

    void wrongInput(float i){
        float row = i;
        var option = row.NoneWhen(a => a == -1);
        option.Match(
            some: b => print($"Check Your Input Format At Row {b + 1}."),
            none: () => print("Impossible!!!")
        );
        print("here");
        Application.Quit();
    }

    void create_block(float b,int i,int j){
        float num = b;
        var option = num.NoneWhen(a => a == 0);
        option.MatchSome(a => {
            // check if block inst.
            Instantiate(Resources.Load($"Blocks/{a}"), new Vector3(i * 2, 0, j * 2), Quaternion.identity);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
