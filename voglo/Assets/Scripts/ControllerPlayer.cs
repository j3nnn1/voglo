using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerPlayer : MonoBehaviour
{
    Rigidbody rb;
    public float velocity = 0.5f;
    public bool localX = true;
    public bool localZ = true;
    public bool sobrePlano = true;
    private ControllerHealth health;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        health = GetComponent<ControllerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb == null)
            return;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //Debug.Log(h);
        Vector3 right, forward;
        if (localX)
          right = transform.right;
        else
          right = Vector3.right;

        if (localZ)
            forward = transform.forward;
        else
            forward = Vector3.forward;

        if (sobrePlano)
        {
            right.y = 0;
            forward.y = 0;
            right.Normalize();
            forward.Normalize();
        }

        rb.velocity = (h * Vector3.right + v * Vector3.forward) * velocity + Vector3.up * rb.velocity.y;
        //Debug.Log("Posicion jugador: " + transform.position);
        //1 transform.position += transform.forward * Time.deltaTime;
        //transform.Translate(Vector3.forward * Time.deltaTime); //later add difficulty
        // 3 NO ANDA rb.AddForce(transform.forward * velocity * Time.deltaTime);
        rb.MovePosition(transform.position + (transform.forward * Time.deltaTime)); //later add difficulty
        // 4 alternative Vector3 newPosition = transform.position + (transform.forward * Time.deltaTime);
        // 4 rb.MovePosition(newPosition);
    }
    void OnCollisionEnter(Collision collision)
    {
        //col.transform.position = new Vector3(0, -5f, 0);
        if (collision.gameObject.CompareTag("Wall"))
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
        if (collision.gameObject.CompareTag("Lethal")) {
            if (health == null)
                Debug.Log("Health Component not added");
            else
                health.GetDamage(1.0f);
        }
    }
    public void OnDeath() {
        SceneManager.LoadScene("menu");
    }
    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Wall"))
    //   {
    //        Vector3 newPos = transform.position;
    //        Vector3 collisionDir = rb.ClosestPointOnBounds(collision.transform.position);
    //        Debug.Log("Desde el jugador: y el objecto 2 es una pared ");
    //       Debug.Log(newPos);
    //        collisionDir.x = collisionDir.x - 0.3f;
    //        //when use x plus or lesss
    //        Debug.Log(collisionDir);
    //        transform.position = collisionDir;

      //  }
    //}
}
