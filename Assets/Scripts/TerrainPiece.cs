using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TerrainPiece : MonoBehaviour
{
    [SerializeField]
    private GameObject dugPrefab;
    [SerializeField]
    private GameObject _break;



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
        //EffectBreak();
        Instantiate(dugPrefab, transform.position, transform.rotation);
       // EffectBreak();
        Destroy(gameObject);

           // spriteRenderer.enabled = false;
            //boxCollider2D.enabled = false;
        
       

    }
   
    public void Update()
    {
        
    }
    public void EffectBreak()
    {
        Instantiate(_break, transform.position, Quaternion.identity);
        Dig();
      
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("TA ENCOSTANO");
        EffectBreak();


    }
}
