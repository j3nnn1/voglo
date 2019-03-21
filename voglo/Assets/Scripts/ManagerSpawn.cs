using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSpawn : MonoBehaviour
{
    public List<GameObject> pistas;
    public float z = 2;
    public float z2 = 2;
    public GameObject wallred;
    public GameObject wall;
    public float largoPista = 1;

    public  void crearPista(Transform t)
    {
        z = t.position.z + largoPista;
        int indice = Random.Range(0, pistas.Count);
        GameObject p = GameObject.Instantiate(pistas[indice], new Vector3(0.0f, 0.0f, z), new Quaternion(0.0f, 0.0f, z, 0.0f));
        //Debug.Log(indice);
        //if (indice == 1) {
        //    //buscar el player con la position del player 
            
        //    GameObject wall = GameObject.FindGameObjectWithTag("PistaTarget");
        //    GameObject.Instantiate(wallred, new Vector3(wall.transform.position.x, 0.0f, wall.transform.position.z), new Quaternion(0.0f, 0.0f, z, 0.0f));
        //}

    }
}
