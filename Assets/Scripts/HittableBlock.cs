using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HittableBlock : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _hit;

    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.collider.GetComponent<PlayerControllerBackUp>();
        if(player && other.contacts[0].normal.y > 0)
        {
            _hit?.Invoke();
        }
    }
}
