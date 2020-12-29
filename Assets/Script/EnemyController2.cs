using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController2 : MonoBehaviour
{
    //GameObject[] points = new GameObject[];
    public GameObject[] points;
    public int target = 0;
    public float enemySpeed = 12.1f;
    //private NavMeshAgent agent;
    private Rigidbody2D rigidbody;
    private Animator animator;
    private Vector2 vector;
    private GameController game;
    private GameObject script;

    // Start is called before the first frame update
    void Start()
    {
        //agent = GetComponent<NavMeshAgent>();
        rigidbody = GetComponent<Rigidbody2D>();
        script = GameObject.Find("GameController");
        game = script.GetComponent<GameController>();
        animator = GetComponent<Animator>();

        FixedUpdate();

        //transform.position = points[target].transform.position;
        //transform.LookAt(points[target].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        // エージェントが現目標地点に近づいてきたら次の目標地点を選択
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        */
    }

    private void FixedUpdate()
    {
        if (game.timerStart == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[target].transform.position, enemySpeed * Time.deltaTime);

            animator.SetBool("start", true);

            if (Vector2.Distance(transform.position, points[target].transform.position) < 1.5f)
            {
                target++;
                switch (target)
                {
                    case 1:
                        animator.SetBool("back", true);
                        break;
                    case 2:
                        animator.SetBool("left", true);
                        break;
                    case 3:
                        animator.SetBool("left", false);
                        animator.SetBool("back", false);
                        break;
                    case 4:
                        animator.SetBool("left", true);
                        break;
                    case 5:
                        animator.SetBool("left", false);
                        break;
                }

                if (target == 6)
                {
                    Debug.Log("hit");
                    enemySpeed = 0;
                }
            }
        }
        else
        {
            animator.SetBool("start", false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GOAL"))
        {
            enemySpeed = 0;

        }
    }
}
