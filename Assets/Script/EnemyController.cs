using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public GameObject[] points;
    public GameObject goal;
    public int target = 0;
    private float enemySpeed = 13f;
    private Animator animator;
    private Rigidbody2D rigidbody;
    private Vector2 vector;
    private GameController game;
    private GameObject script;

    // Start is called before the first frame update
    void Start()
    {
        //agent = GetComponent<NavMeshAgent>();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        script = GameObject.Find("GameController");
        game = script.GetComponent<GameController>();

        FixedUpdate();
    }
    /*
    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position,goal.transform.position) < 2f)
        {
            enemySpeed = 0;
        }
    }
    */
    private void FixedUpdate()
    {
        if(game.timerStart == true)
        {
            //transform.Translate(0, enemySpeed * Time.deltaTime, 0);

            transform.position = Vector2.MoveTowards(transform.position, points[target].transform.position, enemySpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, points[target].transform.position) < 1.5f)
            {
                target++;
                switch (target)
                {
                    case 1:
                        animator.SetBool("left", true);
                        break;
                    case 2:
                        animator.SetBool("left", false);
                        break;
                    case 3:
                        animator.SetBool("left", true);
                        break;
                    case 4:
                        animator.SetBool("left", false);
                        break;
                }
                if (target == 5)
                {
                    Debug.Log("hit");
                    enemySpeed = 0;
                }
            }
        }
    }
}
