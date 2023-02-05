using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGrid : MonoBehaviour
{
    public GameObject tilePrefab;
    public int gridWidth = 10;
    public int gridHeight = 10;
    public Vector2 tileSize;
    public static bool isInteractive;

    void Start()
    {
        SpriteRenderer spriteRenderer = tilePrefab.GetComponent<SpriteRenderer>();
        tileSize = spriteRenderer.sprite.bounds.size;

        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                GameObject tile = Instantiate(tilePrefab, new Vector3(x * tileSize.x, y * tileSize.y, 0), Quaternion.identity);
                tile.transform.parent = transform;

                if (isInteractive)
                {
                    BoxCollider2D collider = tile.AddComponent<BoxCollider2D>();
                    collider.isTrigger = true;
                }
            }
        }
    }
}
