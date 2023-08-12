using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public int attackscore;
    public int bestscore;
    public int destroyscore;

    public TMP_Text attackScoretxt;
    public TMP_Text bestscoretxt;
    public TMP_Text destroyscoretxt;


    void Start()
    {
        attackScoretxt.text = "0";
        destroyscoretxt.text="0";

        bestscore = PlayerPrefs.GetInt("BestScore");
        bestscoretxt.text = bestscore.ToString();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
