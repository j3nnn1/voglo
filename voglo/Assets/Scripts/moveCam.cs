using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCam : MonoBehaviour
{
    Rigidbody rb;
    public float distance = 10.0f;
    public float velocity = 1.0f;
    private ControllerPlayer player;
    private Quaternion rotOriginal;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<ControllerPlayer>();
        
        rotOriginal = transform.localRotation;
    }
    private void FixedUpdate()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<ControllerPlayer>();
        if (player == null)
            return;
        
        Vector3 objetive = player.transform.position - (Vector3.forward * distance);

        if (objetive.y > 0) {
            objetive.y = 0.5f;
        }
        transform.position =
            Vector3.Lerp(transform.position, objetive, velocity * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up);
    }
    
}
