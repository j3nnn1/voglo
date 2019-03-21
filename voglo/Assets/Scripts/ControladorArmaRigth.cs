using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorArmaRigth : MonoBehaviour
{
    public GameObject Package;
    public Transform handrigth;
    public float potencia = 10.0f;
    public float tiempoCoolDown = 1.0f;
    private bool canDisparar = true;
    
    IEnumerator CoolDown()
    {
        canDisparar = false;
        yield return new WaitForSeconds(tiempoCoolDown);
        canDisparar = true;
    }

    void Update()
    {
        bool disparo = Input.GetKeyDown(KeyCode.X);

        if (disparo && canDisparar)
        {
            GameObject p = GameObject.Instantiate(Package, handrigth.position, handrigth.rotation);
            Rigidbody rb = p.GetComponent<Rigidbody>();
            if (rb != null)
                rb.velocity = -handrigth.right * potencia;
            //Debug.Log("velocidad");
            //Debug.Log(rb.velocity);
            rb.transform.Translate(Vector3.left * potencia * Time.deltaTime);
            StartCoroutine("CoolDown");
            //            if (a != null)
            //                a.Play();
        }
    }

}
