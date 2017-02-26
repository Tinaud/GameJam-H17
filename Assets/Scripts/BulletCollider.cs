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
        speed = 4.0f * d;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Mexican") || other.gameObject.CompareTag("ArmyGuy")) {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        if(other.gameObject.CompareTag("Wall")) {
            Destroy(gameObject);
        }
    }

    IEnumerator BulletLife() {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
