using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip play, count;

    private float timer;
    private bool bgm = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(count);
    }

    // Update is called once per frame
    void Update()
    {
        if(bgm == false)
        {
            timer += Time.deltaTime;
            if (timer > 4)
            {
                audioSource.clip = play;
                audioSource.Play();
                bgm = true;
            }
        }
    }
}
