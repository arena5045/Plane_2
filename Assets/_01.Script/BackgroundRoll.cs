using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRoll : MonoBehaviour
{

    float currenttime;
    public float speed = 1.0f;

    public bool isvertical = false;

    public Material mat; 
    // Start is called before the first frame update
    void Start()
    {
        mat.mainTextureOffset = new Vector2(-0.25f, 0);
    }

    // Update is called once per frame
    void LateUpdate()
    {
       

        if (isvertical)
        {
            currenttime = speed * Time.deltaTime;

            mat.mainTextureOffset += Vector2.up * speed * Time.deltaTime;
            Debug.Log("胶农费吝");
        }
        else
        {
            currenttime = speed * Time.deltaTime;

            mat.mainTextureOffset += Vector2.right * speed * Time.deltaTime;
            Debug.Log("胶农费吝");
        }           

}
}
