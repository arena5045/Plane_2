using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //��ǥ ���� �����Ѵ�
    //�ʿ�Ӽ� Ư���ð� ����ð� �����ӿ�����Ʈ
    // ����1 Ư�� �ð��� �帥��
    // ����2 Ư�� �ð��� �帣��
    // ���� 3 ���� �����ȴ�

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
