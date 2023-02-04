using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;
   // public Animator animator;
    public int diggingPower = 10;

    public static bool isBlocked = false; // Indicador de terreno bloqueado ou seguro

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
     //  animator = GetComponent<Animator>();
    }

    void Update()
    {
       // float horizontal = Input.GetAxis("Horizontal");
       // float vertical = Input.GetAxis("Vertical");

        //  rb.velocity = new Vector2(horizontal * speed, vertical * speed);

        if (isBlocked)
        {
            // Permite movimento tanto na horizontal quanto na vertical
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Vector2 movement = new Vector2(horizontal, vertical);
            rb.velocity = movement * speed;
        }
        else
        {
            // Permite apenas movimento na horizontal
            float horizontal = Input.GetAxis("Horizontal");
            Vector2 movement = new Vector2(horizontal, 0);
            rb.velocity = movement * speed;
        }

        //  animator.SetFloat("Horizontal", horizontal);
        // animator.SetFloat("Vertical", vertical);
        // animator.SetFloat("Speed", Mathf.Abs(horizontal) + Mathf.Abs(vertical));





    }




}
