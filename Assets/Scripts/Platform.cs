using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Código a ser executado quando houver colisão
        Debug.Log("Teste");
        PlayerController.isBlocked = true;
    }
}
