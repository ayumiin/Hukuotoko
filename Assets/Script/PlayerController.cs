using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float speed = 12.7f;
    private float sutamina = 20f;
    public Slider StSlider;
    public Text scoretext, ranktext;

    private Rigidbody2D rigidbody;
    private Vector2 vector;
    private GameObject script,hit;
    private GameController game;
    private goalScript GoalScript;
    private float timer = 0;
    private float speedtimer, sutaminatimer;
    private float nowsutamina;
    private int inttime;
    public int score = 0;
    private bool stop,speedup,sutaminaup,goal;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        StSlider = GameObject.Find("Slider").GetComponent<Slider>();

        script = GameObject.Find("GameController");
        game = script.GetComponent<GameController>();

        hit = GameObject.Find("goal");
        GoalScript = hit.GetComponent<goalScript>();

        animator = GetComponent<Animator>();
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
        scoretext.text = "score:" + score.ToString();
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
            //animation
            if (Input.GetKey(KeyCode.A))
            {
                animator.SetBool("left", true);
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                animator.SetBool("left", false);
            }
            if (Input.GetKey(KeyCode.S))
            {
                animator.SetBool("back", true);
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                animator.SetBool("back", false);
            }
            if (Input.GetKey(KeyCode.D))
            {
                animator.SetBool("right", true);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                animator.SetBool("right", false);
            }
            
            //goal
            if (Vector2.Distance(transform.position, hit.transform.position) < 2.5f)
            {
                rigidbody.velocity = Vector3.zero;
                
                ranktext.text = GoalScript.rank.ToString() + "位";
                game.playtimer -= Time.deltaTime;
                game.resulttime = game.playtimer;
                inttime = (int)game.resulttime;
                game.Playtext.text = "タイム:" + inttime.ToString();
                /*
                switch (GoalScript.rank)
                {
                    case 1:
                        score += 500;
                        break;
                    case 2:
                        score += 400;
                        break;
                    case 3:
                        score += 300;
                        break;
                    case 4:
                        score += 200;
                        break;
                    case 5:
                        score += 100;
                        break;
                }
                
                // Type == Number の場合
                //naichilab.RankingLoader.Instance.SendScoreAndShowRanking(score);
                
                // Type == Time の場合
                var millsec = 123456;
                var timeScore = new System.TimeSpan(0, 0, 0, 0, millsec);
                naichilab.RankingLoader.Instance.SendScoreAndShowRanking(timeScore);
                */
            }
                
        }
        //energy取得、スピードアップ
        if (speedup == true)
        {
            speedtimer += Time.deltaTime;
            speed += 1;
            if(speedtimer > 3)
            {
                speedup = false;
                speed = 10;
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
        if (collision.gameObject.CompareTag("water"))
        {
            sutamina += 3;
        }
        if (collision.gameObject.CompareTag("Energy"))
        {
            speedup = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("sutaminaup"))
        {
            sutaminaup = true;
            nowsutamina = sutamina;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("score"))
        {
            score += 500;
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GOAL"))
        {
            /*
            ranktext.text = GoalScript.rank.ToString() + "位";
            game.playtimer -= Time.deltaTime;
            game.resulttime = game.playtimer;
            inttime = (int)game.resulttime;
            game.Playtext.text = "タイム:" + inttime.ToString();
            
            switch (GoalScript.rank)
            {
                case 1:
                    score += 500;
                    break;
                case 2:
                    score += 400;
                    break;
                case 3:
                    score += 300;
                    break;
                case 4:
                    score += 200;
                    break;
                case 5:
                    score += 100;
                    break;
            }
            */
        }
    }
}
