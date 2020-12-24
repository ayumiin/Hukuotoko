using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 3.0f;
    private Rigidbody2D rigidbody;
    private Vector2 vector;
    private GameObject script;
    private GameController game;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        script = GameObject.Find("GameController");
        game = script.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        vector.x = Input.GetAxis("Horizontal");
        vector.y = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {
        if(game.timerStart == true)
        {
            rigidbody.velocity = vector.normalized * speed;
        }
    }
}
