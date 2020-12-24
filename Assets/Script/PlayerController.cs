using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 100f;
    public float sutamina = 20f;
    public Slider StSlider;
    public bool stop;

    private Rigidbody2D rigidbody;
    private Vector2 vector;
    private GameObject script;
    private GameController game;
    private float timer = 0;

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
        if(sutamina > 20)
        {
            sutamina = 20;
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
    }
}
