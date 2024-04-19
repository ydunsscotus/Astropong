using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public  int PlayerScoreL = 0;
    public  int PlayerScoreR = 0;

    //Buat UI Text
    public TMP_Text txtPlayerScoreL;
    public TMP_Text txtPlayerScoreR;
    
    public static GameManager instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        //Mengisikan nilai integer PlayerScore ke UI
        txtPlayerScoreL.text = PlayerScoreL.ToString();
        txtPlayerScoreR.text = PlayerScoreR.ToString();
    }


    public void Score(string wallID)
    {
        if (wallID == "Line L")
        {
            //StartCoroutine(ShakeCam(0.7f));
            PlayerScoreR = PlayerScoreR + 10; //menambah score
            txtPlayerScoreR.text = PlayerScoreR.ToString(); //mengisikan nilai integer PlayerScore ke UI
            ScoreCheck();
        }
        else
        {
            //StartCoroutine(ShakeCam(0.7f));
            PlayerScoreL = PlayerScoreL + 10;
            txtPlayerScoreL.text = PlayerScoreL.ToString();
            ScoreCheck();
        }
    }

    public void ScoreCheck()
    {
        if (PlayerScoreL == 100)
        {
            Debug.Log("playerL win");
            this.gameObject.SendMessage("ChangeScene","MainMenu");
        }
        else if (PlayerScoreR == 100)
        {
            Debug.Log("playerR win");
            this.gameObject.SendMessage("ChangeScene", "MainMenu");
        }
    }
    

}
