using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {




        if(other.gameObject.tag == "DestroyZone" || other.gameObject.tag == "Player")
        {
            return;
        }
        Destroy(other.gameObject);
    }
}
