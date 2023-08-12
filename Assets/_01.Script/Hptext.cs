using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hptext : MonoBehaviour
{
    public TMP_Text txt;
    public GameObject player; 
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
      
        if(player == null )
        {
            txt.text = "x0";
        }
        else
        {
            txt.text = "x" + player.GetComponent<PlayerMove>().hp;
        }
    }
}
