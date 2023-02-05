using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveTile : MonoBehaviour
{
    public PlayerControllerBackUp targetObject;
    public MonoBehaviour targetScript;

    public AudioSource bateu;

    void Start()
    {
      //  targetObject = nPlayerControllerBackUP;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            targetObject.FreezePosition();
            targetScript.enabled = false;
           
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bateu.Play();
            targetScript.enabled = true;
            targetObject.UnfreezePosition();
        }
    }
}
