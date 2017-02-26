using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trump : MonoBehaviour {

    private float moveSpeed,
                  angle;
    private bool throwingMoney;

    void Start () {
        moveSpeed = 5.0f;
        angle = Random.Range(0.0f, 360.0f);
        throwingMoney = false;
    }
	
	void Update () {
        Vector3 direction = Wander();
        transform.Translate(direction * moveSpeed * Time.deltaTime);
        Flip(direction);
    }

    Vector2 Wander() {
        Vector2 newDirection;

        angle += Random.Range(-0.2f, 0.2f);

        Clamp(angle, 0.0f, 6.2f);

        newDirection.x = Mathf.Cos(angle);
        newDirection.y = Mathf.Sin(angle);

        return new Vector2(newDirection.x, newDirection.y).normalized;
    }

    void Flip(Vector2 dir) {
        if (dir.x < 0)
            GetComponent<SpriteRenderer>().flipX = true;
        else
            GetComponent<SpriteRenderer>().flipX = false;
    }

    float Clamp(float i, float min, float max) {
        if (i < min)
            i += max;
        else if (i > max)
            i -= max;
        return i;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "ArmyGuy" || other.tag == "Player") {
            StartCoroutine(MakeItRain());
            throwingMoney = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "ArmyGuy" || other.tag == "Player")
            throwingMoney = false;
    }

    IEnumerator MakeItRain() {
        GetComponent<Animator>().SetBool("throwMoney", true);
        moveSpeed = 0;
        yield return new WaitWhile(() => throwingMoney);
        GetComponent<Animator>().SetBool("throwMoney", false);
        moveSpeed = 5.0f;
    }
}
