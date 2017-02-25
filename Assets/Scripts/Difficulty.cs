using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour {

    private GameObject _Difficulty;

    private void Start()
    {
        _Difficulty = GameObject.Find("Current_Level");
    }

    public void Easy()
    {

        _Difficulty.GetComponent<Text>().text = "Easy";
    }

    public void Medium()
    {

        _Difficulty.GetComponent<Text>().text = "Medium";
    }

    public void Hard()
    {

        _Difficulty.GetComponent<Text>().text = "Hard";
    }
}
