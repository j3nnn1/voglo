using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            //if (explosion != null)
            //    GameObject.Instantiate(explosion, transform.position, Quaternion.Euler(0f, Random.Range(-180f, 180f), 0f));
            //GameObject.Destroy(collision.gameObject);
            //ControladorSalud s = collision.gameObject.GetComponent<ControladorSalud>();
            //if (s != null)
            //    s.RecibirDanio(danio);
            GameObject.Destroy(gameObject);
        }
    }
}
