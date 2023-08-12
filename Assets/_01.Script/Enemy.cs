using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 1.0f;
    public Vector3 dir = Vector3.down;
    GameObject player;
    int ranvalue;

    public int hp = 3; 
    Vector3 playerdir;
    // Start is called before the first frame update
    GameManager manager;
    public GameObject explosion;
    void Start()
    {
        player = GameObject.Find("Player");
        ranvalue = Random.Range(0, 10);

        manager = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (ranvalue < 3)
        {
            if (player != null)
            {
                dir = player.transform.position - gameObject.transform.position;
                dir.Normalize();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (ranvalue < 1)
        {
            if(player != null)
            {
                playerdir = player.transform.position - gameObject.transform.position;
                dir = playerdir;
                dir.Normalize();
            }    
          
        }

        transform.position += dir * speed * Time.deltaTime;

    }


    private void OnCollisionEnter(Collision othercollision)
    {
        if(othercollision.gameObject.tag == "Enemy" || othercollision.gameObject.tag == "EnemyBullet")
        {
            return;
        }
        if(player == null)
        { return; }

        hp--;
        manager.attackscore += 10;
        manager.attackScoretxt.text = manager.attackscore.ToString();

        if (hp <= 0)
        {
            GameObject explo = Instantiate(explosion);
            explo.transform.position = transform.position;

            Destroy(gameObject);
            manager.destroyscore += 100;
            manager.destroyscoretxt.text = manager.destroyscore.ToString();

        }

        else if (othercollision.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerMove>().hp--;

            Destroy(gameObject);
            manager.destroyscore += 100;
            manager.destroyscoretxt.text = manager.destroyscore.ToString();

            if (player.GetComponent<PlayerMove>().hp <= 0)

            {

                Destroy(othercollision.gameObject);

                if(manager.attackscore + manager.destroyscore > PlayerPrefs.GetInt("BestScore"))
                {
                    manager.bestscore = manager.attackscore + manager.destroyscore;
                    manager.bestscoretxt.text = manager.bestscore.ToString();
                    PlayerPrefs.SetInt("BestScore", manager.bestscore);
                }


            }

            GameObject explo = Instantiate(explosion);
            explo.transform.position = transform.position;
        }


    }
    private void OnCollisionStay(Collision collision)
    {
            
    }

    private void OnCollisionExit(Collision collision)
    {
        
    }
}
