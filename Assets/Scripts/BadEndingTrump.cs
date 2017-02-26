using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadEndingTrump : MonoBehaviour
{

    GameObject unTrump;
    Vector2 direction;
    private float moveSpeed,
                  angle;
    private int lookDirection;

    // Use this for initialization
    void Start()
    {
        unTrump = GameObject.Find("Trump playable");
        moveSpeed = 3.0f;
        angle = Random.Range(0.0f, 360.0f);
        lookDirection = 1;
    }

    private void Update()
    {
        direction = Wander();
        transform.Translate(direction * moveSpeed * Time.deltaTime);
        Flip(direction);
    }

    Vector2 Wander()
    {
        Vector2 newDirection;

        angle += Random.Range(-0.2f, 0.2f);

        Clamp(angle, 0.0f, 6.2f);

        newDirection.x = Mathf.Cos(angle);
        newDirection.y = Mathf.Sin(angle);

        return new Vector2(newDirection.x, newDirection.y).normalized;
    }

    void Flip(Vector2 dir)
    {
        if (dir.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            transform.localScale = new Vector3(1.5f, 1.5f, 0);
            lookDirection = -1;
        }

        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
            transform.localScale = new Vector3(1.5f, 1.5f, 0);
            lookDirection = 1;
        }

    }

    float Clamp(float i, float min, float max)
    {
        if (i < min)
            i += max;
        else if (i > max)
            i -= max;
        return i;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        angle += 3.1f;
        Clamp(angle, 0.0f, 6.2f);
    }

}
