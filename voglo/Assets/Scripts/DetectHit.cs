using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void isTriggerEnter(Collision col)
    {
        Debug.Log("Desde la pared isTriggerEnter : se pego con la pared");
        Debug.Log(col);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Desde la pared: se pego con la pared un objeto player ");
        }
        //col.transform.position = new Vector3(0, -5f, 0);
    }
}
