using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerMexican : Mexican {

    private GameObject soldierInSight;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "ArmyGuy" && other.GetComponent<PlayerController>().armyType != 2) {
            soldierInSight = other.gameObject;
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot() {
        float temp = moveSpeed;
        moveSpeed = 0;
        GetComponent<Animator>().SetBool("isShooting", true);
        
        for(int i = 0; i < 3; i++) {
            Instantiate(Resources.Load("Bullet"), transform.position + new Vector3(0.5f, -0.1f, 0), Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }

        moveSpeed = temp;

        GetComponent<Animator>().SetBool("isShooting", false);
    }
}
