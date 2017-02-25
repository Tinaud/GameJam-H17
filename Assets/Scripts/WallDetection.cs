using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetection : MonoBehaviour {
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Wall")
            GetComponentInParent<Mexican>().WallClose(other.transform);
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Wall")
            GetComponentInParent<Mexican>().WallClose(other.transform);
    }
}
