using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeCountText : MonoBehaviour
{
    float timer = 25;
    public static int timeGroup = 0;
    [SerializeField] Text timeText;
    [SerializeField] Text timeUpText;
    void Start()
    {
        if(timeText == null)
        {
            Debug.LogError($"Text{timeText}‚È‚¢‚æ");
        }
        if(timeUpText ==null)
        {
            Debug.LogError($"Text{timeUpText}‚È‚¢‚æ");
        }
    }
    void Update()
    {
        if (timeGroup == 0)
        {
            timer -= Time.deltaTime;
        }
        else if (timeGroup == 1)
        {
            timer = timer;
        }
        else if(timeGroup ==2)
        {
            timer = 0;
        }
        if (timer <= 0)
        {
            timeText.gameObject.SetActive(false);
            timeUpText.text = "‚»‚±‚Ü‚Å";   
        }
        timeText.text = timer.ToString("F2");
    }
}
