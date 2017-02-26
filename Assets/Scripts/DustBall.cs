using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustBall : MonoBehaviour {

    private float moveSpeed;

    void Start() {
        moveSpeed = Random.Range(3.0f, 5.0f);
        StartCoroutine(DestroyBall());
    }

    void Update() {
        float right = moveSpeed * Time.deltaTime;
        float up = moveSpeed * Time.deltaTime * Mathf.Sin(Time.time * 7);
        transform.parent.transform.Translate(new Vector3(right, up, 0));
        transform.Rotate(new Vector3(0, 0, -10));
    }
    
    IEnumerator DestroyBall() {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
