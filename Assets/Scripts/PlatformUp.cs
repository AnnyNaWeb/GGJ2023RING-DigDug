using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformUp : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            Vitoria();

        }
       

       
    }

    public void Vitoria()
    {

        SceneManager.LoadScene(3);
    }
}
