using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMexican : Mexican {

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "ArmyGuy")
            closeEnemies.Add(other.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "ArmyGuy")
            closeEnemies.Remove(other.gameObject);
    }
}
