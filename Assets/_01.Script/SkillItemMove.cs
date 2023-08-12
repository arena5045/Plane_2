using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkillItemMove : MonoBehaviour
{
    public GameObject itemeffect;
    Vector3 dir = Vector3.down;
    public float speed = 5.0f;
    public int itemcode;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * Time.deltaTime * speed;
    }



    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded) return;


        GameObject itemiffection  = Instantiate(itemeffect);
        itemiffection.transform.position = transform.position;

       
        //sound 
        GameObject soundmanager = GameObject.Find("SoundManager");
        AudioSource se = soundmanager.GetComponent<SoundManager>().soundeffect;
        se.clip = soundmanager.GetComponent<SoundManager>().itemclip[0];
        se.Play();
    }
}
