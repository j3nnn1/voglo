using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorArma : MonoBehaviour
{
    public GameObject proyectil;
    public Transform canionleft;
    public float potencia = 1.0f;
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
        bool disparo = Input.GetKeyDown(KeyCode.A);
        //bool disparo = Input.GetButtonDown("Fire1");

        if (disparo && canDisparar)
        {
            GameObject p = GameObject.Instantiate(proyectil, canionleft.position, canionleft.rotation);
            Rigidbody rb = p.GetComponent<Rigidbody>();
            if (rb != null)
                rb.velocity = canionleft.forward * potencia;
            StartCoroutine("CoolDown");
//            if (a != null)
//                a.Play();
        }
    }

}
