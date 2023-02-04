using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2f;
    public float previousHorizontal = 0;
    private Rigidbody2D rb;
   // public Animator animator;
    public int diggingPower = 10;
    public static bool isBlocked = false; // Indicador de terreno bloqueado ou seguro
    Animator animator;
    public bool facingRight = true;
    public bool facingLeft = false;
    float horizontal, vertical;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        previousHorizontal = Input.GetAxis("Horizontal");
    }



    void Update()
    {
       // float horizontal = Input.GetAxis("Horizontal");
       // float vertical = Input.GetAxis("Vertical");

        //  rb.velocity = new Vector2(horizontal * speed, vertical * speed);

        if (isBlocked)
        {
            // Permite movimento tanto na horizontal quanto na vertical
             horizontal = Input.GetAxis("Horizontal");
             vertical = Input.GetAxis("Vertical");
            Vector2 movement = new Vector2(horizontal, vertical);
            rb.velocity = movement * speed;
        }
        else
        {
            // Permite apenas movimento na horizontal
             horizontal = Input.GetAxis("Horizontal");
            Vector2 movement = new Vector2(horizontal, 0);
            rb.velocity = movement * speed;
        }

        //  animator.SetFloat("Horizontal", horizontal);
        // animator.SetFloat("Vertical", vertical);
        // animator.SetFloat("Speed", Mathf.Abs(horizontal) + Mathf.Abs(vertical));


        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
        animator.SetFloat("Speed", Mathf.Abs(horizontal) + Mathf.Abs(vertical));
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)){
            animator.SetBool("isWalking", true);
        }else{
            animator.SetBool("isWalking", false);
        }

        if(previousHorizontal < horizontal){
            animator.SetBool("facingLeft", false);
            animator.SetBool("facingRight", true);
        }else if(previousHorizontal >  horizontal){
            animator.SetBool("facingRight", false);
            animator.SetBool("facingLeft", true);
        }
        previousHorizontal = Input.GetAxis("Horizontal");


    }

}
