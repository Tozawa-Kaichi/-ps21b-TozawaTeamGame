using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerDecreseController : MonoBehaviour
{
    public static TimerDecreseController instance;
    [SerializeField] Text timeText = default;
    [SerializeField] Text timeUpText = default;
    public static int timeGroup = 1;
    float timer = 25;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = timer.ToString("F2");
        if (timeGroup == 1)
        {
            timer -= Time.deltaTime;
        }
        else if (timeGroup == 2)
        {
            timer = timer;
        }
        if(timer<=0)
        {
            timer = 0;
            timeText.gameObject.SetActive(false);
            GameObject go = GameObject.FindGameObjectWithTag("Player");
            go.TryGetComponent(out Rigidbody rb);
            rb.isKinematic = true;
            timeUpText.text = "‚»‚±‚Ü‚Å";
        }
    }

}
