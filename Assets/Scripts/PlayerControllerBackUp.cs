using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public static float posCaida = 0;
    
    
    bool caiu;
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
            // Player está vindo da direita
            transform.position = new Vector3(transform.position.x - 1.5f, transform.position.y, transform.position.z);
        }
        else if (rb.velocity.x < 0)
        {
            // Player está vindo da esquerda
            transform.position = new Vector3(transform.position.x +1.5f, transform.position.y, transform.position.z);
        }
        else if (rb.velocity.y > 0)
        {
            // Player está vindo de cima
            transform.position = new Vector3(transform.position.x, transform.position.y - 1.5f, transform.position.z);
        }
        else if (rb.velocity.y < 0)
        {
            // Player está vindo de baixo
            transform.position = new Vector3(transform.position.x , transform.position.y +1.5f, transform.position.z);
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
                
                horizontal = Input.GetAxis("Horizontal");
                vertical = Input.GetAxis("Vertical");
                movement = new Vector2(horizontal, vertical);
                rb.velocity = movement * speed;
            }
            else
            {
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
            transform.position = new Vector3(posCaida, transform.position.y - (float)0.02, 0);

            jacaiu = true;

        }
        else { jacaiu = true; caiu = true; }

    }


}