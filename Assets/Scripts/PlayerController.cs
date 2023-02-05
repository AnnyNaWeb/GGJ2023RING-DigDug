using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2f;
    public float previousHorizontal = 0;
    public static Rigidbody2D rb;
   // public Animator animator;
    public int diggingPower = 10;
    public static bool isBlocked = false; // Indicador de terreno bloqueado ou seguro
    Animator animator;
    public bool facingRight = true;
    public bool facingLeft = false;
    float horizontal, vertical;
    Vector2 movement;
    public static bool jacaiu = false;


    bool caiu;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        previousHorizontal = Input.GetAxis("Horizontal");
        caiu = false;
    }



    void Update()
    {
        if(caiu && jacaiu == false){
           CairNoTerreno();
           return;
        }

        if (isBlocked)
        {
            if (caiu)
            {
                // Permite movimento tanto na horizontal quanto na vertical
                horizontal = Input.GetAxis("Horizontal");
                vertical = Input.GetAxis("Vertical");
                 movement = new Vector2(horizontal, vertical);
                rb.velocity = movement * speed;
            }
            else
            {
                CairNoTerreno();
            }
            
        }
        else
        {
            // Permite apenas movimento na horizontal
            horizontal = Input.GetAxis("Horizontal");
            movement = new Vector2(horizontal, vertical);
            rb.velocity = movement * speed;
        }


        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
        animator.SetFloat("Speed", Mathf.Abs(horizontal) + Mathf.Abs(vertical));
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)){
            animator.SetBool("UpDown", true);
        }else{
            animator.SetBool("UpDown", false);
        }

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

    public void CairNoTerreno()
    {  
        if(transform.position.y < 0) jacaiu = true;
        transform.position = new Vector3(transform.position.x, transform.position.y-(float)0.01, 0);
    
    }

    

}