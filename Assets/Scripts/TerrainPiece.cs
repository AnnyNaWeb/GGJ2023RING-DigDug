using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainPiece : MonoBehaviour
{
    [SerializeField]
    private GameObject dugPrefab;

    public int initialHealth = 100;
    private int currentHealth;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;
    float time;

    public Material material;
   
    private TerrainPieceController terrainPieceController;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();

        currentHealth = initialHealth;
        terrainPieceController = GetComponent<TerrainPieceController>();
    }

    public void Dig(int damage)
    {
        terrainPieceController.StartDigging();
        Instantiate(dugPrefab, transform.position, transform.rotation);
        Destroy(gameObject);

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            spriteRenderer.enabled = false;
            boxCollider2D.enabled = false;
        }
    }

    public void Update()
    {
        
    }
}
