using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerObstacles : MonoBehaviour
{
    public float maxTimeLive = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        //GameObject.Destroy(gameObject, maxTimeLive);
        //Destroy(gameObject, maxTimeLive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //here revisar porque no lo elimino
            Destroy(gameObject);
        }
    }
}
