using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DetectHit : MonoBehaviour
{
    public float totalPackages = 6.0f;

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

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Desde la pared: se pego con la pared un objeto player ");
        }
        if (collision.gameObject.CompareTag("Package"))
        {
            totalPackages = totalPackages - 1;
            Debug.Log("totalPackages: " + totalPackages);
            if (totalPackages < 1.0f)
            {
                SceneManager.LoadScene("LevelComplete");
            }
        }
        //col.transform.position = new Vector3(0, -5f, 0);
    }
}
