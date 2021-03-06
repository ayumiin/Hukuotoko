﻿using System.Collections;
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

        //ScoreSend();
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
            Debug.Log("hitenemy");
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            count++;
            rank = count;
            Debug.Log("hitplayer");

            switch (rank)
            {
                case 1:
                    script.score += 2880;
                    break;
                case 2:
                    script.score += 2180;
                    break;
                case 3:
                    script.score += 1960;
                    break;
                case 4:
                    script.score += 1640;
                    break;
                case 5:
                    script.score += 1280;
                    break;
            }
            ScoreSend();
        }
    }
    
    void ScoreSend()
    {
        PlayerPrefs.SetInt(PlayerPrefsKeys.Score, script.score);
        PlayerPrefs.Save();
    }
    
}
