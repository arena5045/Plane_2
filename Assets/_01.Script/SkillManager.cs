using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{

    public GameObject[] skillItem;
    public float creatTime;
    float currentTime;

    public float mincTime = 2;
    public float maxcTime = 6;



    private void Start()
    {
       creatTime = Random.Range(mincTime, maxcTime);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if(currentTime > creatTime)
        {
            GameObject SkillGo = Instantiate(skillItem[Random.Range(0,skillItem.Length)]);

            SkillGo.transform.position = transform.position+ new Vector3(Random.Range(-2.0f,2.0f),0,0);
            currentTime = 0;

            creatTime = Random.Range(mincTime, maxcTime);
        }

    }
}
