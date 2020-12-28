using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ResultDoTween : MonoBehaviour
{
    public Text Text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MessageMove()
    {
        Text.transform.DOScale(new Vector3(1.18f, 1.18f, 1.18f), 1.8f);
    }
}
