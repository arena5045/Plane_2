using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssistFire : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject gunPos;
    public int skillLev = 0;

    public Vector3 loc;
    public int namecount;

    public float curtime;
    public float cooltime=0.5f;

    // Start is called before the first frame update
    void Start()
    {
        loc = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        curtime += Time.deltaTime;
        if (curtime > cooltime)
        {
            ExcuteSkill(skillLev);
            curtime = 0;
        }



        if (Input.GetKeyDown(KeyCode.Space))
        {
            ExcuteSkill(skillLev);
        }


    }

    private void ExcuteSkill(int _skilLev)
    {
        switch (_skilLev)
        {
            case 0:
                Exskill();
                break;
            case 1:
                Exskill2();
                break;
            case 2:
                Exskill3();
                break;
            case 3:
                Superskill();
                break;
            default:
                Superskill();
                break;


        }

        void Exskill()
        {
            GameObject bulletGo = Instantiate(Bullet);

            bulletGo.transform.position = gunPos.transform.position;

        }

        void Exskill2()
        {
            GameObject bulletGo = Instantiate(Bullet);
            GameObject bulletGo2 = Instantiate(Bullet);

            bulletGo.transform.position = gunPos.transform.position + new Vector3(-0.2f, 0f, 0f);
            bulletGo2.transform.position = gunPos.transform.position + new Vector3(0.2f, 0f, 0f);
        }

        void Exskill3()
        {
            GameObject bulletGo = Instantiate(Bullet);
            GameObject bulletGo2 = Instantiate(Bullet);
            GameObject bulletGo3 = Instantiate(Bullet);

            bulletGo.transform.position = gunPos.transform.position + new Vector3(-0.2f, 0f, 0f);
            bulletGo.transform.rotation = Quaternion.Euler(0f, 0f, 30);
            bulletGo.GetComponent<Bullet>().dir = bulletGo.transform.up;

            bulletGo3.transform.position = gunPos.transform.position;

            bulletGo2.transform.position = gunPos.transform.position + new Vector3(0.2f, 0f, 0f);
            bulletGo2.transform.rotation = Quaternion.Euler(0f, 0f, -30);
            bulletGo2.GetComponent<Bullet>().dir = bulletGo2.transform.up;
        }

        void Superskill()
        {

                GameObject bulletGo = Instantiate(Bullet);
                GameObject bulletGo2 = Instantiate(Bullet);
                GameObject bulletGo3 = Instantiate(Bullet);
                GameObject bulletGo4 = Instantiate(Bullet);
                GameObject bulletGo5 = Instantiate(Bullet);

                bulletGo.transform.position = gunPos.transform.position + new Vector3(-0.2f, 0f, 0f);
                bulletGo.transform.rotation = Quaternion.Euler(0f, 0f, 30);
                bulletGo.GetComponent<Bullet>().dir = bulletGo.transform.up;

                bulletGo3.transform.position = gunPos.transform.position;

                bulletGo2.transform.position = gunPos.transform.position + new Vector3(0.2f, 0f, 0f);
                bulletGo2.transform.rotation = Quaternion.Euler(0f, 0f, -30);
                bulletGo2.GetComponent<Bullet>().dir = bulletGo2.transform.up;

            bulletGo4.transform.position = gunPos.transform.position + new Vector3(0.2f, 0f, 0f);
            bulletGo4.transform.rotation = Quaternion.Euler(0f, 0f, -60);
            bulletGo4.GetComponent<Bullet>().dir = bulletGo2.transform.up;

            bulletGo5.transform.position = gunPos.transform.position + new Vector3(-0.2f, 0f, 0f);
            bulletGo5.transform.rotation = Quaternion.Euler(0f, 0f, 60);
            bulletGo5.GetComponent<Bullet>().dir = bulletGo.transform.up;

        }

    }

}
