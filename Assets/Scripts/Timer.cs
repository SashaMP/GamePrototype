using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using deltaTime;

public class Timer : MonoBehaviour
{ 

     public GameObject BackgroundLoseObject;
     public AudioSource LevelMusic;
     //public GameObject TimerTextObject;

    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;

    void Start()
    {
        BackgroundLoseObject.SetActive(false);
       // TimerTextObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;
            BackgroundLoseObject.SetActive(true);
            LevelMusic.Pause();
            //TimerTextObject.SetActive(true);
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); 
    }
}
