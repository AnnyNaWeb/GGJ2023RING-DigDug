using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveTile : MonoBehaviour
{
    public GameObject targetObject;
    public MonoBehaviour targetScript;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            targetScript.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            targetScript.enabled = true;
        }
    }
}
