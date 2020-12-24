using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 100f;
    public float sutamina = 30;
    public Slider StSlider;
    
    private Rigidbody2D rigidbody;
    private Vector2 vector;
    private GameObject script;
    private GameController game;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        StSlider = GameObject.Find("Slider").GetComponent<Slider>();

        script = GameObject.Find("GameController");
        game = script.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        vector.x = Input.GetAxis("Horizontal");
        vector.y = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.W))
        {

        }
    }
    private void FixedUpdate()
    {
        if(game.timerStart == true)
        {
            rigidbody.velocity = vector.normalized * speed;
            sutamina -= Time.deltaTime;
            StSlider.value = sutamina;
        }
    }
}
