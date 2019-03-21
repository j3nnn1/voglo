using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeliveryPackage : MonoBehaviour
{
    public float totalPackages = 6.0f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Package"))
        {
            totalPackages = totalPackages - 1;
            Debug.Log("totalPackages: " + totalPackages);
            if (totalPackages < 1.0f)
            {
                SceneManager.LoadScene("principal");
            }
        }
    }
}
