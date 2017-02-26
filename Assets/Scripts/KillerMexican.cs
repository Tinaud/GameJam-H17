using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerMexican : Mexican {

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "ArmyGuy" || other.tag == "Player") 
            StartCoroutine(Shoot());
    }

    IEnumerator Shoot() {
        GetComponent<AudioSource>().Play();
        tag = "Player";
        float temp = GetSpeed();
        SetSpeed(0);
        GetComponent<Animator>().SetBool("isShooting", true);
        
        for(int i = 0; i < 3; i++) {
            GameObject b = (GameObject)Instantiate(Resources.Load("Bullet"), transform.position + new Vector3(0.5f, -0.1f, 0), Quaternion.identity);
            b.GetComponent<BulletCollider>().SetDirection(1);
            yield return new WaitForSeconds(0.3f);
        }

        SetSpeed(temp);

        GetComponent<Animator>().SetBool("isShooting", false);
        tag = "ArmyGuy";
    }
}
