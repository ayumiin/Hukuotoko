using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultScript : MonoBehaviour
{

    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        ScoreSend();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ScoreSend()
    {
        PlayerPrefs.SetInt(PlayerPrefsKeys.Result, score);
    }
}
