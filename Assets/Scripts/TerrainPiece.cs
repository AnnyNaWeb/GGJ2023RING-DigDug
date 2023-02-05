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
        //Digger.cavarTerreno = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();

        currentHealth = initialHealth;
        terrainPieceController = GetComponent<TerrainPieceController>();
    }

    public  void Dig()
    {
       // terrainPieceController.StartDigging();
        Instantiate(dugPrefab, transform.position, transform.rotation);
        Destroy(gameObject);

        //currentHealth -= damage;


        spriteRenderer.enabled = false;
            boxCollider2D.enabled = false;
        
       

    }

    public void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Código a ser executado quando houver colisão
        Debug.Log("TA ENCOSTANO");
        Dig();
       // Digger.cavarTerreno = true;
      
        //  PlayerController.rb.velocity = new Vector2(rb.velocity.x, 0);
        //  PlayerController.transform.position = new Vector2(transform.position.x, collision.transform.position.y);
    }
}
