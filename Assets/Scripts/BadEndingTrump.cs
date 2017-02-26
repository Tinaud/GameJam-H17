using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadEndingTrump : MonoBehaviour {

    GameObject unTrump, CurrentTrump;

	// Use this for initialization
	void Start () {
        unTrump = GameObject.Find("Trump playable");
        CurrentTrump = Instantiate(unTrump, new Vector3(0, 0, 0), Quaternion.identity);
    }

    private void Update()
    {
        
    }
}
