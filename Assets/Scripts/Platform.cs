using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // C�digo a ser executado quando houver colis�o
        Debug.Log("Teste");
        PlayerControllerBackUp.isBlocked = true;
      PlayerControllerBackUp.jacaiu = false;
      PlayerControllerBackUp.posCaida = PlayerControllerBackUp.transformerPosH;
        PlayerControllerBackUp.animator.SetBool("UpDown", true);
   }
}
