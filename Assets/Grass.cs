using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour {

    private float moveSpeed,
                  angle;
    private Vector2 dir;

    void Start()
    {
        moveSpeed = 5.0f;
        angle = Random.Range(90.0f, 180.0f);
        dir.x = Mathf.Cos(angle);
        dir.y = Mathf.Sin(angle);
    }

    void Update()
    {
                transform.Translate(dir * moveSpeed * Time.deltaTime);
    }
}
