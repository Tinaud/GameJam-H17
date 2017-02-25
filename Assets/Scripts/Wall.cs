using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {
    private GameManager gm;

    void Start() {
        gm = Camera.main.GetComponent<GameManager>();    
    }
    
	void Update () {
        transform.localScale += new Vector3(0, gm.MexicansOnWall() * 0.0005f, 0);

        if (transform.localScale.y >= 20)
            gm.EndGame(false);
	}
}
