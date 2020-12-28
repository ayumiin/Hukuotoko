using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goalScript : MonoBehaviour
{
    public int count,rank;

    // Start is called before the first frame update
    void Start()
    {
        
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
            //Invoke("Result", 2);
        }
    }
    private void Result()
    {
        SceneManager.LoadScene("Result");
    }
}
