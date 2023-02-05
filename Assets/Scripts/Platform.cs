using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // C�digo a ser executado quando houver colis�o
        Debug.Log("Teste");
        PlayerController.isBlocked = true;
        PlayerController.jacaiu = false;
        
      //  PlayerController.rb.velocity = new Vector2(rb.velocity.x, 0);
      //  PlayerController.transform.position = new Vector2(transform.position.x, collision.transform.position.y);
    }
}
