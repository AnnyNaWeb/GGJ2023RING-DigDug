using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerControllerBackUp : MonoBehaviour
{
    public float speed = 2f;
    public float previousHorizontal = 0;
    public static Rigidbody2D rb;
    // public Animator animator;
    public static float transformerPosH = 0;
    public int diggingPower = 10;
    public static bool isBlocked = false; // Indicador de terreno bloqueado ou seguro
    public static Animator animator;
    public bool facingRight = true;
    public bool facingLeft = false;
    float horizontal, vertical;
    Vector2 movement;
    public static bool jacaiu = false;
    public static float posCaida;
    public AudioSource cavar;


    public static bool caiu;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        animator = GetComponent<Animator>();
        previousHorizontal = Input.GetAxis("Horizontal");
        

        // caiu = false;
    }
    public void FreezePosition()
    {

        if (rb.velocity.x > 0)
        {
            // Player est� vindo da direita
            transform.position = new Vector3(transform.position.x - 2f, transform.position.y, transform.position.z);
        }
        else if (rb.velocity.x < 0)
        {
            // Player est� vindo da esquerda
            transform.position = new Vector3(transform.position.x +1.5f, transform.position.y, transform.position.z);
        }
        else if (rb.velocity.y > 0)
        {
            // Player est� vindo de cima
            transform.position = new Vector3(transform.position.x, transform.position.y - 1.5f, transform.position.z);
        }
        else if (rb.velocity.y < 0)
        {
            // Player est� vindo de baixo
            transform.position = new Vector3(transform.position.x , transform.position.y +2f, transform.position.z);
        }
       

        rb.constraints = RigidbodyConstraints2D.FreezePosition;
    }

    public void UnfreezePosition()
    {
        rb.constraints = RigidbodyConstraints2D.None;
       
    }


    void Update()
    {
       

        if (isBlocked)
        {
            if (caiu)
            {
                // Permite movimento tanto na horizontal quanto na vertical
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                horizontal = Input.GetAxis("Horizontal");
                vertical = Input.GetAxis("Vertical");
                movement = new Vector2(horizontal, vertical);
               
               

                rb.velocity = movement * speed;
            }
            else
            {
                posCaida = transform.position.x;
                FreezePosition();
                CairNoTerreno();
                
                return;
            }

        }
        else
        {
            // Permite apenas movimento na horizontal
            horizontal = Input.GetAxis("Horizontal");
            movement = new Vector2(horizontal, 0);
            rb.velocity = movement * speed;
        }


        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
        animator.SetFloat("Speed", Mathf.Abs(horizontal) + Mathf.Abs(vertical));


        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("UpDown", true);
        }
        else
        {
            animator.SetBool("UpDown", false);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (previousHorizontal < horizontal)
        {
            animator.SetBool("facingLeft", false);
            animator.SetBool("facingRight", true);
        }
        else if (previousHorizontal > horizontal)
        {
            animator.SetBool("facingRight", false);
            animator.SetBool("facingLeft", true);
        }
        previousHorizontal = Input.GetAxis("Horizontal");


    }

    public void CairNoTerreno()
    {
        //animator.SetBool("UpDown", true);
        Debug.Log(transform.position.y);
        
        if (transform.position.y > -10)
        {
            transform.position = new Vector3(posCaida, transform.position.y - (float)0.05, transform.position.z);
            transform.Rotate(new Vector3(0, 0, 1 * Time.deltaTime * 90));
            //  jacaiu = true;

        }
        else 
        {
           
            jacaiu = true; 
            caiu = true;
            
            // transform.Rotation = Quaternion(0, 0, 0, 0);
            //  transform.Rotate(new Vector3(0, 0, 45));

            UnfreezePosition();
            float rotation = transform.eulerAngles.z;
            transform.eulerAngles = new Vector3(0, 0, 0);
            //transform.Rotate(new Vector3(0, 0, 0));

        }
       

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Terrain"))
        {
            cavar.Play();
        }


    }


}