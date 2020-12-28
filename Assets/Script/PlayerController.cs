using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float speed = 12f;
    private float sutamina = 25f;
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
    public int score { get; set; }
    private bool stop,speedup,sutaminaup,goal;
    private Animator animator;

    public GameObject sutaminaText;

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

        //ScoreSend();
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
        if(sutamina > 25)
        {
            sutamina = 25;
        }
        scoretext.text = "スコア:" + score.ToString();
    }
    private void FixedUpdate()
    {
        //カウントダウン中は動かない処理
        if(game.timerStart == true)
        {
            sutamina += Time.deltaTime * 2;
            animator.SetBool("start", true);
            //スタミナ減少
            if (stop == false)
            {
                rigidbody.velocity = vector.normalized * speed;

                if (Input.GetKey(KeyCode.W))
                {
                    sutamina -= Time.deltaTime * 3;
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    sutamina -= Time.deltaTime * 3;
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    sutamina -= Time.deltaTime * 3;
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    sutamina -= Time.deltaTime * 3;
                }

                sutaminaText.SetActive(false);
            }
            else
            {
                //スタミナ0以下で動かなくなる
                rigidbody.velocity = Vector3.zero;
                if (sutamina >= 3)
                {
                    stop = false;
                }
                sutaminaText.SetActive(true);
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

                Invoke("ResultMove", 2f);     
            }

        }
        else
        {
            animator.SetBool("start", false);
        }

        //energy取得、スピードアップ
        if (speedup == true)
        {
            speedtimer += Time.deltaTime;
            speed = 18;
            if(speedtimer > 2)
            {
                speed = 12;
                speedtimer = 0;
                speedup = false;
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

    public void ResultMove()
    {
        SceneManager.LoadScene(PlayerPrefsKeys.Result);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
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
            score += 1520;
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("water"))
        {
            sutamina += 5;
            Debug.Log("sutamina");
        }
    }

}
