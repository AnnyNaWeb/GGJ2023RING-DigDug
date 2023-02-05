using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainPiece : MonoBehaviour
{
    [SerializeField]
    private GameObject dugPrefab;



    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;


    public Material material;
   
  

    private void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();


       
    }

    public  void Dig()
    {

        Instantiate(dugPrefab, transform.position, transform.rotation);
        Destroy(gameObject);

            spriteRenderer.enabled = false;
            boxCollider2D.enabled = false;
        
       

    }

    public void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("TA ENCOSTANO");
        Dig();
      
    }
}
