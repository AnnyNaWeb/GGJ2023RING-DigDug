using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Digger : MonoBehaviour
{
    public int diggingPower = 10;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
            if (hit.collider != null)
            {
                TerrainPiece terrainPiece = hit.collider.GetComponent<TerrainPiece>();
                if (terrainPiece != null)
                {
                    terrainPiece.Dig(diggingPower);
                    Debug.Log("Cavou este terreno");
                }
            }
        }
    }
}
