using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentLevel : MonoBehaviour {

    private GameObject _CurrentLevel;

	// Use this for initialization
	void Start () {
        _CurrentLevel = GameObject.Find("Current_Level");
    }
	
	public void Easy()
    {
        
        GetComponent<Text>().text = "Easy";
    }

    public void Medium()
    {
        GetComponent<Text>().text = "Medium";
    }

    public void Hard()
    {
        GetComponent<Text>().text = "Hard";
    }
}
