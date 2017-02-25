using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerMexican : Mexican {

    private GameObject soldierToKill;

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "ArmyGuy" && other.gameObject.GetComponent<PlayerController>().armyType != 2) {
            soldierToKill = other.gameObject;
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot() {
        float temp = moveSpeed;
        moveSpeed = 0;
        GetComponent<Animator>().SetBool("isShooting", true);
        yield return new WaitForSeconds(Random.Range(0.3f, 0.7f));
        moveSpeed = temp;
        GetComponent<Animator>().SetBool("isShooting", false);
        
        if(soldierToKill.GetComponent<PlayerController>().enabled)
            Camera.main.GetComponent<GameManager>().ChangeSelectedSoldier(1);
        Destroy(soldierToKill);
        soldierToKill = null;
    }
}
