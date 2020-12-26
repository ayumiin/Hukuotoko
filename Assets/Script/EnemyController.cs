using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    //GameObject[] points = new GameObject[];
    public Transform[] points;
    public int target = 0;
    public float enemySpeed = 330f;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        // エージェントが現目標地点に近づいてきたら次の目標地点を選択
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            Move();
    }

    public void Move()
    {
        if (points.Length == 0)
            return;

        // エージェントが現在設定された目標地点に行くように設定
        agent.destination = points[target].position;

        // 配列内の次の位置を目標地点に設定、必要ならば出発地点にもどる
        target = (target + 1) % points.Length;
    }
}
