using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 350f;
    public float sutamina = 20f;
    public Slider StSlider;
    public Text scoretext;

    private Rigidbody2D rigidbody;
    private Vector2 vector;
    private GameObject script;
    private GameController game;
    private float timer = 0;
    private float speedtimer, sutaminatimer;
    private float nowsutamina;
    private int score = 0;
    private bool stop,speedup,sutaminaup;

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
        //現在のスタミナ
        StSlider.value = sutamina;

        vector.x = Input.GetAxis("Horizontal");
        vector.y = Input.GetAxis("Vertical");     
        //sutaminaが0以下になると動かなくなる処理
        if(sutamina <= 0)
        {
            stop = true;
        }
        //sutamina上限
        if(sutamina > 10)
        {
            sutamina = 10;
        }
    }
    private void FixedUpdate()
    {
        //カウントダウン中は動かない処理
        if(game.timerStart == true)
        {
            sutamina += Time.deltaTime;
            //スタミナ減少
            if (stop == false)
            {
                rigidbody.velocity = vector.normalized * speed;

                if (Input.GetKey(KeyCode.W))
                {
                    sutamina -= Time.deltaTime * 2;
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    sutamina -= Time.deltaTime * 2;
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    sutamina -= Time.deltaTime * 2;
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    sutamina -= Time.deltaTime * 2;
                }
            }
            else
            {
                //スタミナ0以下で動かなくなる
                rigidbody.velocity = Vector3.zero;
                if (sutamina >= 10)
                {
                    stop = false;
                }
            }
        }
        //energy取得、スピードアップ
        if (speedup == true)
        {
            speedtimer += Time.deltaTime;
            speed += 50;
            if(speedtimer > 3)
            {
                speedup = false;
                speed = 350;
                speedtimer = 0;
            }
        }
        //スタミナは減らない
        if(sutaminaup == true)
        {
            sutaminatimer += Time.deltaTime;
            sutamina = nowsutamina;
            if(sutaminatimer > 3)
            {
                sutaminaup = false;
                sutamina -= Time.deltaTime * 2;
                sutaminatimer = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("water"))
        {
            sutamina += 3;
            Destroy(collision.gameObject);
        }
        if (collision.collider.CompareTag("Energy"))
        {
            speedup = true;
            Destroy(collision.gameObject);
        }
        if (collision.collider.CompareTag("sutaminaup"))
        {
            sutaminaup = true;
            nowsutamina = sutamina;
            Destroy(collision.gameObject);
        }
        if (collision.collider.CompareTag("score"))
        {
            score++;
            scoretext.text = "score:" + score.ToString();
            Destroy(collision.gameObject);
        }
    }
}
