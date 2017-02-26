using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadEndingTrump : MonoBehaviour {

    private GameObject sprite;

	// Use this for initialization
	void Start () {
        StartCoroutine(Delete());
	}
	
	IEnumerator Delete()
    {
        yield return new WaitForSeconds(10.0f);
        Destroy(gameObject);
    }
}
