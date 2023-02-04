using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainDig : MonoBehaviour
{
    [SerializeField]
    private Transform diggingPoint;

    [SerializeField]
    private float diggingRadius = 0.5f;

    [SerializeField]
    private LayerMask terrainLayer;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(diggingPoint.position, diggingRadius, terrainLayer);

            foreach (Collider2D collider in colliders)
            {
                if (collider.GetComponent<TerrainPiece>() != null)
                {

                    collider.GetComponent<TerrainPiece>().Dig(100);
                }
            }
        }
    }
}
