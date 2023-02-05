using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformUp : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        // C�digo a ser executado quando houver colis�o
        Debug.Log("Teste");
        PlayerController.isBlocked = false;
        PlayerController.subiu = true;

       
    }
}
