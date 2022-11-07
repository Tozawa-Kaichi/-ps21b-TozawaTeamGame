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
    bool _isTimeStop;
    /// <summary>
    /// タイマーフラグのプロパティ
    /// </summary>
    public bool IsTimeStop { get => _isTimeStop; set => _isTimeStop = value; } 
    void Start()
    {
        if(timeText == null)
        {
            Debug.LogError($"Text{timeText}ないよ");
        }
        if(timeUpText ==null)
        {
            Debug.LogError($"Text{timeUpText}ないよ");
        }
        _isTimeStop = true;
        timeText.gameObject.SetActive(false);
    }
    void Update()
    {
        if(!_isTimeStop)
        {
            timeText.gameObject.SetActive(true);
            timer -= Time.deltaTime;
        }    
        if (timer <= 0)
        {
            timeText.gameObject.SetActive(false);
            timeUpText.text = "そこまで";   
        }
        timeText.text = timer.ToString("F2");
    }
}
