using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController3 : MonoBehaviour
{
    //GameObject[] points = new GameObject[];
    public GameObject[] points;
    public int target = 0;
    private float enemySpeed = 5f;
    //private NavMeshAgent agent;
    private Rigidbody2D rigidbody;
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
            transform.Translate(0, enemySpeed * Time.deltaTime, 0);

            if (Vector2.Distance(transform.position, points[target].transform.position) < 4f)
            {
                target++;
                switch (target)
                {
                    case 1:
                        transform.Rotate(0, 0, 90);
                        Debug.Log("hit");
                        break;
                    case 2:
                        transform.Rotate(0, 0, -90);
                        Debug.Log("hit");
                        break;
                    case 3:
                        transform.Rotate(0, 0, 90);
                        Debug.Log("hit");
                        break;
                    case 4:
                        transform.Rotate(0, 0, -90);
                        target = 0;
                        break;

                }
            }
        }
    }
}
