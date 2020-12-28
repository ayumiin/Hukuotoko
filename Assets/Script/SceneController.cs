using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update

    public void TitleButtonPush()
    {
        SceneManager.LoadScene("Title");
    }

    public void RestartPush()
    {
        SceneManager.LoadScene("play");
    }

}
