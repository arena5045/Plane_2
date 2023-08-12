using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyFire : MonoBehaviour
{


    public GameObject Bullet;
    public GameObject gunPos;
    float currrentTime;
    public float creatTime = 1f;

    public float bulletspeed = 20f;
    GameObject player;
    Vector3 playerDir;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 dir;
        float angle;

        currrentTime += Time.deltaTime;
        Vector3 Lookpo = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        if (currrentTime > creatTime && player != null)
        {
            GameObject bulletGO = Instantiate(Bullet);
                bulletGO.tag = "EnemyBullet";
                bulletGO.GetComponent<Bullet>().speed = bulletspeed;
            bulletGO.transform.position = transform.position;


            bulletGO.transform.position = gunPos.transform.position;

            playerDir = player.transform.position - gameObject.transform.position;
            playerDir.Normalize();
            bulletGO.GetComponent<Bullet>().dir = playerDir;

             dir = player.transform.position - bulletGO.transform.position;
             angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            bulletGO.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            bulletGO.transform.Rotate(new Vector3(0,0,-90));
            bulletGO.GetComponent<Bullet>().speed = 3f;

            currrentTime = 0f;
        }

        
            dir = player.transform.position - transform.position;
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.Rotate(new Vector3(0, 0, 90));
        }
        

    }
    // Start is called before the first frame update


}
