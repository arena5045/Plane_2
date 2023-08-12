using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5f;
    public int hp = 10;

    Vector3 playerpos = new Vector3(0, 0,0);
    Vector3 enemypos = new Vector3(0, 0, 0);

    public float keydowncount;
    public Material background;

    public float dashspeed = 2.0f;
    public float slowspeed = 2.0f;

    public PlayerFire pf;
    public GameObject plane;
    void Start()
    {
        // Vector3 direction = enemypos - playerpos;
        //  float distance = direction.magnitude;

        // print("direction: " + direction);
        //  print("distance: "+ distance);

        pf = GetComponent<PlayerFire>();
        plane = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = 10f;
        }
        else if(Input.GetKey(KeyCode.LeftControl))
        {
            speed = 2f;
        }
        else
        {
            speed = 5f;
        }
       
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            keydowncount +=  Time.deltaTime;
            background.mainTextureOffset += new Vector2(-0.1f* speed/5f* Time.deltaTime,0); 

            plane.transform.rotation = Quaternion.Slerp(plane.transform.rotation,Quaternion.Euler( new Vector3(-90, 50,0)),10f*Time.deltaTime);
          AssistFire[] ass = GetComponentsInChildren<AssistFire>();
            foreach(AssistFire assplane in ass) 
            {
                Vector3 Pos = assplane.loc;
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    Pos = new Vector3(-0.2f - assplane.namecount * 0.2f, 0.5f, 0);
                }
                if(keydowncount> 0.05f * assplane.namecount)
                {
                    assplane.gameObject.transform.rotation = Quaternion.Slerp(assplane.gameObject.transform.rotation, Quaternion.Euler(new Vector3(0, 50, 0)), 10f * Time.deltaTime);
                    assplane.gameObject.transform.localPosition = Vector3.Lerp(assplane.gameObject.transform.localPosition, Pos + new Vector3(-0.3f, 0, 0), 10f * Time.deltaTime);
                }
             
            }
        }
        else
        if (Input.GetKey(KeyCode.RightArrow))
        {
            keydowncount += Time.deltaTime;
            background.mainTextureOffset += new Vector2(+0.1f * speed / 5f * Time.deltaTime, 0);

            plane.transform.rotation = Quaternion.Slerp(plane.transform.rotation, Quaternion.Euler(new Vector3(-90, -50, 0)), 10f * Time.deltaTime);
            AssistFire[] ass = GetComponentsInChildren<AssistFire>();
            foreach (AssistFire assplane in ass)
            {
                Vector3 Pos = assplane.loc;
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    Pos = new Vector3(0.2f + assplane.namecount * 0.2f, 0.5f, 0);
                }
                if (keydowncount > 0.05f * assplane.namecount)
                {
                    assplane.gameObject.transform.rotation = Quaternion.Slerp(assplane.gameObject.transform.rotation, Quaternion.Euler(new Vector3(0, -50, 0)), 10f * Time.deltaTime);
                    assplane.gameObject.transform.localPosition = Vector3.Lerp(assplane.gameObject.transform.localPosition, Pos + new Vector3(0.3f, 0, 0), 10f * Time.deltaTime);
                }
               
            }
        }
        else
        {
            keydowncount = 0;

            plane.transform.rotation = Quaternion.Slerp(plane.transform.rotation, Quaternion.Euler(new Vector3(-90, 0, 0)), 10f * Time.deltaTime);
            AssistFire[] ass = GetComponentsInChildren<AssistFire>();
            foreach (AssistFire assplane in ass)
            {
                assplane.gameObject.transform.rotation = Quaternion.Slerp(assplane.gameObject.transform.rotation, Quaternion.Euler(new Vector3(0, 0, 0)), 10f * Time.deltaTime);
                assplane.gameObject.transform.localPosition = Vector3.Lerp(assplane.gameObject.transform.localPosition, assplane.loc , 10f * Time.deltaTime);
            }
        }


        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir =  Vector3.right * h + Vector3.up * v;
        //transform.Translate(dir*speed*Time.deltaTime);
        transform.position = transform.position + dir*speed*Time.deltaTime;
    }
}
