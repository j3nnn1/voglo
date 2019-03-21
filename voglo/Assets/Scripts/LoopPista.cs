using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopPista : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject manager = GameObject.Find("ManagerSpawn");
            var m = manager.GetComponent<ManagerSpawn>();
            //m.crearPista(transform);
            m.crearPista(transform.parent);
        }
    }
    
}
