using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDisplayScript : MonoBehaviour
{
    private PlayerController script;
    // Start is called before the first frame update
    void Start()
    {
        ShowResult();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowResult()
    {
        //if (PlayerPrefs.HasKey(PlayerPrefsKeys.Score))
        //{
            naichilab.RankingLoader.Instance.SendScoreAndShowRanking(PlayerPrefs.GetInt(PlayerPrefsKeys.Score));
        //}
        /*
        else
        {
            naichilab.RankingLoader.Instance.SendScoreAndShowRanking(PlayerPrefs.GetInt(PlayerPrefsKeys.Score));
        }
        //naichilab.RankingLoader.Instance.SendScoreAndShowRanking(PlayerPrefs.GetInt(PlayerPrefsKeys.Score));
        */
    }
}
