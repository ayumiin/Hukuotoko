using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SceneController : MonoBehaviour
{
    public Text titleText;
    public GameObject touch;
    public GameObject tuterial;

    // Start is called before the first frame update
    void Start()
    {
        titleText.transform.DOScale(new Vector3(1, 1, 1), 1.8f);

        Invoke("Touch", 3.0f);
    }

    public void Touch()
    {
        touch.SetActive(true);
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            tuterial.SetActive(true);
        }
    }

    public void TitleButtonPush()
    {
        SceneManager.LoadScene("Title");
    }

    public void RestartPush()
    {
        SceneManager.LoadScene("play");
    }

}
