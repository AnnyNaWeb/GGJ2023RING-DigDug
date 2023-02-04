using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainPieceController : MonoBehaviour
{
    public TerrainPiece terrainPiece;
    public float diggingTime = 0.5f;

    private float diggingCounter = 0f;
    private bool digging = false;

    private void Update()
    {
        if (digging)
        {
            diggingCounter += Time.deltaTime;

            if (diggingCounter >= diggingTime)
            {
                digging = false;
                diggingCounter = 0f;
                terrainPiece.Dig(1);
            }
        }
    }

    public void StartDigging()
    {
        digging = true;
    }
}
