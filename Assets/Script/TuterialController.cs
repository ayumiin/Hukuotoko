﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TuterialController : MonoBehaviour
{
    public GameObject tuterial01;
    public GameObject tuterial02;
    public GameObject tuterial03;

    public GameObject nextButton01;
    public GameObject nextButton02;
    public GameObject nextButton03;

    public GameObject backButton01;
    public GameObject backButton02;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextPush01()
    {
        tuterial01.SetActive(false);
        tuterial02.SetActive(true);

        nextButton01.SetActive(false);
        nextButton02.SetActive(true);

        backButton01.SetActive(true);
    }

    public void NextPush02()
    {
        tuterial02.SetActive(false);
        tuterial03.SetActive(true);

        nextButton02.SetActive(false);
        nextButton03.SetActive(true);

        backButton01.SetActive(false);
        backButton02.SetActive(true);
    }

    public void NextPush03()
    {
        SceneManager.LoadScene("play");
    }

    public void BackPush01()
    {
        backButton01.SetActive(false);

        tuterial01.SetActive(true);
        tuterial02.SetActive(false);

        nextButton01.SetActive(true);
        nextButton02.SetActive(false);
    }

    public void BackPush02()
    {
        tuterial03.SetActive(false);
        tuterial02.SetActive(true);

        backButton02.SetActive(false);
        backButton01.SetActive(true);

        nextButton02.SetActive(true);
        nextButton03.SetActive(false);
    }
}
