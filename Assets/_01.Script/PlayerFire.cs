using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerFire : MonoBehaviour
{   //목표 : 사용자 입력 (space)를 받아 총알을 생성
    // 순서 : 입력을 받고싶다
    // 순서2 : 총알을 만들고싶다

    public GameObject Bullet;
    public GameObject gunPos;
    public int skillLev = 0;

    public float curtime;
    public float cooltime;

    public GameObject asplane;
    public GameObject[] asspos;

    public int planecount = 0;

    // Update is called once per frame
    void Update()
    {
        curtime += Time.deltaTime;
        if(curtime > cooltime)
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

            bulletGo.transform.position = gunPos.transform.position + new Vector3(-0.5f, 0f, 0f);
            bulletGo2.transform.position = gunPos.transform.position + new Vector3(0.5f, 0f, 0f);
        }

        void Exskill3()
        {
            GameObject bulletGo = Instantiate(Bullet);
            GameObject bulletGo2 = Instantiate(Bullet);
            GameObject bulletGo3 = Instantiate(Bullet);

            bulletGo.transform.position = gunPos.transform.position + new Vector3(-0.5f, 0f, 0f);
            bulletGo.transform.rotation = Quaternion.Euler(0f, 0f, 30);
            bulletGo.GetComponent<Bullet>().dir = bulletGo.transform.up;

            bulletGo3.transform.position = gunPos.transform.position;

            bulletGo2.transform.position = gunPos.transform.position + new Vector3(0.5f, 0f, 0f);
            bulletGo2.transform.rotation = Quaternion.Euler(0f, 0f, -30);
            bulletGo2.GetComponent<Bullet>().dir = bulletGo2.transform.up;
        }

        void Superskill()
        {

            for(int i=0; i < 24; i++) 
            {
                GameObject bulletGo = Instantiate(Bullet);
                bulletGo.gameObject.name = "Bullet" + i;
                bulletGo.transform.position = transform.position;
                bulletGo.transform.rotation = Quaternion.Euler(0f, 0f, 15*i);
                bulletGo.GetComponent<Bullet>().dir = bulletGo.transform.up;
                //bulletGo.transform.Translate(bulletGo.GetComponent<Bullet>().dir *1 ,Space.World);
            }

        }

    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Item")
        {
            switch( other.GetComponent<SkillItemMove>().itemcode)
            {
                case 0: // 공격력 증가
                    skillLev++;

                    

                    AssistFire[] assistplan = GetComponentsInChildren<AssistFire>();
                    foreach (AssistFire assist in assistplan)
                    {
                        assist.skillLev++;
                    }

                    break ;
                case 1: //보조기 증가
                    if(planecount<2)
                    {
                        GameObject assitplane = Instantiate(asplane, asspos[planecount].transform);
                        assitplane.transform.SetParent(gameObject.transform);
                        assitplane.GetComponent<AssistFire>().namecount = planecount;

                        planecount++;
                    }
                    else if(planecount % 2 == 0)
                    {
                        Transform setplane = asspos[0].transform;
                        setplane.transform.position += new Vector3(-0.3f, -0.2f, 0);
                        GameObject assitplane = Instantiate(asplane, setplane.transform);
                        assitplane.transform.SetParent(gameObject.transform);
                        assitplane.GetComponent<AssistFire>().namecount = planecount;

                        planecount++;
                    }
                    else
                    {
                        Transform setplane = asspos[1].transform;
                        setplane.transform.position += new Vector3(0.3f, -0.2f, 0);
                        GameObject assitplane = Instantiate(asplane, setplane.transform);
                        assitplane.transform.SetParent(gameObject.transform);
                        assitplane.GetComponent<AssistFire>().namecount = planecount;

                        planecount++;
                    }
                    break;
                case 2: //체력회복

                    gameObject.GetComponent<PlayerMove>().hp++;
                    break;
                case 3:// 공속증가
                    cooltime *= 0.85f;
                    break;


            }
            Destroy(other.gameObject);
        }
    }
}
