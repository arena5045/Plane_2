using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //목표 적을 생성한다
    //필요속성 특정시간 현재시간 적게임오브젝트
    // 순서1 특정 시간이 흐른다
    // 순서2 특정 시간이 흐르면
    // 순서 3 적이 생성된다

    public float creatTime = 0f;
    public int minTime = 3;
    public int maxTime = 6;

    float currentTime = 0f;
    public GameObject[] enemy = new GameObject[6];

    // Start is called before the first frame update
    void Start()
    {
        creatTime = Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;


        if (currentTime > creatTime) 
        {
            int cnum = Random.Range(0,enemy.Length);
            GameObject enemyGo = Instantiate(enemy[cnum]);
            enemyGo.transform.position = transform.position;


            currentTime = 0;
        
        }
    }
}
