using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public bool timerStart;
    public float playtimer,resulttime;
    public int second,third;
    private float totaltimer = 4;

    public Text Playtext,Totaltext;

    // Start is called before the first frame update
    void Start()
    {
        //3count表示
        var count = GameObject.Find("TotalTime");
        Totaltext = count.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //3countの整数表示
        totaltimer -= Time.deltaTime;
        //intに変換
        second = (int)totaltimer;
        Totaltext.text = second.ToString();
        if (totaltimer < 1)
        {
            Totaltext.text = "Go!";
        }
        if (totaltimer < 0)
        {
            timerStart = true;
            Totaltext.enabled = false;
        }
        //三秒後にレーススタート
        if (timerStart == true)
        {
            playtimer += Time.deltaTime;
        }
        //intに変換
        third = (int)playtimer;
        Playtext.text = "タイム:" + third.ToString();
    }
}
