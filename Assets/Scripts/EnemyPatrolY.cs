using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyPatrolY : MonoBehaviour
{
    public Transform player;
    public float patrolSpeed = 2f;
    public float previousHorizontal = 0;
    public float chaseSpeed = 5f;
    public float chaseTriggerDistance = 5f;
    public static Animator animator;
    private Vector2 patrolDestination;
    private int currentPatrolIndex;
    public Vector2[] patrolWaypoints;

    private void Start()
    {
        animator = GetComponent<Animator>();
        patrolWaypoints = new Vector2[] {
            new Vector2(transform.position.x , transform.position.y- 10),
            new Vector2(transform.position.x , transform.position.y+ 10)
        };
        
        previousHorizontal = transform.position.y;
        patrolDestination = patrolWaypoints[0];
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceToPlayer < chaseTriggerDistance)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
        
        if (previousHorizontal < transform.position.y)
        {
            GetComponent<Animator>().SetBool("ESQUERDA", true);
        }
        else if (previousHorizontal > transform.position.y)
        {
             GetComponent<Animator>().SetBool("ESQUERDA", false);
        }
         previousHorizontal = transform.position.y;
    }

    private void ChasePlayer()
    {
        float step = chaseSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, player.position, step);
    }

    private void Patrol()
    {

        float step = patrolSpeed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, patrolDestination, step);

        if (Vector2.Distance(transform.position, patrolDestination) < 0.1f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolWaypoints.Length;
            patrolDestination = patrolWaypoints[currentPatrolIndex];
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // O inimigo detectou o jogador
            SceneManager.LoadScene(2);
        }




    }
}
