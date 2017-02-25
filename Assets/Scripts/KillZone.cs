using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour {

    GameManager gm;

    private void Start() {
        gm = Camera.main.GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Mexican") {
            Destroy(other.gameObject);
            if (gm.IsGameStarted())
                gm.AddMexicanOnWall();
        }
    }
}
