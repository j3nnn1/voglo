﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTime : MonoBehaviour
{
    public float tiempo = 1.0f;
    public GameObject obstacle;

    public List<Transform> posiciones;
    private float x;
    private float z;
    private Quaternion rotOriginal;
    private readonly float xlimit = 1.5f;
    private readonly float xinit = -1.5f;
    private readonly float zlimit = 10.0f;
    private readonly float zinit = -10.0f; // el z init  se actualiza con el movimiento del player

    private ControllerPlayer player;
    private readonly float distance = 0.5f;
    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(tiempo);

                x = Random.Range(xinit, xlimit);
                z = Random.Range(zinit, zlimit);

                GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
                player = playerObj.GetComponent<ControllerPlayer>();

                if (player != null) {
                    z = player.transform.position.z + distance;
                }

                GameObject.Instantiate(obstacle, new Vector3(x, 0, z), new Quaternion(x, 0.0f, z, 0.0f ));

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !activo)
        {
            StartCoroutine("Spawn");
            //AudioSource a = GetComponent<AudioSource>();
            //if (a != null)
            //{
            //    a.Play();
            //}
            activo = true;
        }
    }

    private bool activo = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
