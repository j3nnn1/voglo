using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorArma : MonoBehaviour
{
    public GameObject Package;
    public Transform handleft;
    public float potencia = 10.0f;
    public float tiempoCoolDown = 1.0f;
    private bool canDisparar = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator CoolDown()
    {
        canDisparar = false;
        yield return new WaitForSeconds(tiempoCoolDown);
        canDisparar = true;
    }

    void Update()
    {
        bool disparo = Input.GetKeyDown(KeyCode.X);
        //bool disparo = Input.GetButtonDown("Fire1");
        //Debug.Log("disparo:");
        //Debug.Log(disparo);
        //Debug.Log("puede disparar");
        //Debug.Log(canDisparar);
        

        if (disparo && canDisparar)
        {
            GameObject p = GameObject.Instantiate(Package, handleft.position, handleft.rotation);
            Rigidbody rb = p.GetComponent<Rigidbody>();
            if (rb != null)
                rb.velocity = -handleft.right * potencia;
            //Debug.Log("velocidad");
            //Debug.Log(rb.velocity);
            rb.transform.Translate(Vector3.right * potencia * Time.deltaTime);
            StartCoroutine("CoolDown");
//            if (a != null)
//                a.Play();
        }
    }

}
