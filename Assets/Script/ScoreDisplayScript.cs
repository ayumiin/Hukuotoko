using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDisplayScript : MonoBehaviour
{
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
            naichilab.RankingLoader.Instance.SendScoreAndShowRanking(PlayerPrefs.GetInt(PlayerPrefsKeys.Score));
       
    }
}
