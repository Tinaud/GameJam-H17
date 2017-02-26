using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollider : MonoBehaviour {

    private float speed;


    void Start() {
        StartCoroutine(BulletLife());
    }
    void Update() {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    public void SetDirection(int d) {
        speed = 14.0f * d;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Mexican") {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if(other.gameObject.tag == "ArmyGuy") {
            if (other.gameObject.GetComponent<ArmyGuy>().armyType != 2)
                Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if(other.gameObject.tag == "Wall") {
            Destroy(gameObject);
        }
    }

    IEnumerator BulletLife() {
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }
}
