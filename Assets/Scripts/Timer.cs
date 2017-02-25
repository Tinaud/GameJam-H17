using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private GameObject _Hours, _Minutes;
    public static float timer = 480;
    public bool timeStarted = false;
    int hours, minutes;

    public int Minutes
    {
        get
        {
            return minutes;
        }
    }

    public int Hours
    {
        get
        {
            return hours;
        }
    }

    void Start()
    {
        _Hours = GameObject.Find("Hours");
        _Minutes = GameObject.Find("Minutes");
    }

    public void StartTimer()
    {
        timeStarted = true;
    }

    public void StopTimer()
    {
        timeStarted = false;
        enabled = false;
    }

    void Update()
    {
        if (timeStarted)
        {
            timer = timer - Time.deltaTime * 2;
            hours = (int)timer / 60;
            minutes = (int)timer % 60;
            _Hours.GetComponent<Text>().text = hours.ToString();
            _Minutes.GetComponent<Text>().text = minutes.ToString();
            Debug.Log(hours + ":" + minutes);
        }
    }
}