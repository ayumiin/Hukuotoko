using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goalScript : MonoBehaviour
{
    public int count,rank;
    private PlayerController script;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        script = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            count++;
            Debug.Log("hit");
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            count++;
            rank = count;
            Debug.Log("hit");

            //Invoke("Result", 2);
            switch (rank)
            {
                case 1:
                    script.score += 500;
                    break;
                case 2:
                    script.score += 400;
                    break;
                case 3:
                    script.score += 300;
                    break;
                case 4:
                    script.score += 200;
                    break;
                case 5:
                    script.score += 100;
                    break;
            }
        }
    }
    private void Result()
    {
        SceneManager.LoadScene("Result");
    }
}
