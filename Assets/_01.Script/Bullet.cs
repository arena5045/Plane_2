using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public float speed = 1.0f;
    public Vector3 dir = Vector3.up;
    public GameObject bulex;
    // Update is called once per frame


    private void Start()
    {
        Destroy(gameObject,3f);
    }
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;

    }



    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag =="Player" && tag =="EnemyBullet")
        {
            GameObject Player = collision.gameObject;
            Player.GetComponent<PlayerMove>().hp--;


            if (Player.GetComponent<PlayerMove>().hp <= 0) 
            {
                Destroy(collision.gameObject);


                GameObject bulexp = Instantiate(bulex);
                bulexp.transform.position = transform.position;

                GameManager manager = GameObject.Find("GameManager").GetComponent<GameManager>();

                if (manager.attackscore + manager.destroyscore > PlayerPrefs.GetInt("BestScore"))
                {
                    manager.bestscore = manager.attackscore + manager.destroyscore;
                    manager.bestscoretxt.text = manager.bestscore.ToString();
                    PlayerPrefs.SetInt("BestScore", manager.bestscore);
                }

            }
            else
            {
                GameObject bulexp = Instantiate(bulex);
                bulexp.transform.position = transform.position;
            }

            
        }

            Debug.Log(collision.gameObject.name+"¿¡ ºÎµúÈû!");
            Destroy(gameObject);

    }
}
