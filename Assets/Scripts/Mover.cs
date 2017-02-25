using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float speed, horizontalSpeed;
    private Vector2 dir;
    private float angle;

    void Start ()
    {
        angle += Random.Range(0,360);
        //dir.x = Mathf.Cos(angle);
        //dir.y = Mathf.Sin(angle);
        dir.x = 0;
        dir.y = -1;
    }

    void Update()
    {
       transform.Translate(dir * speed * Time.deltaTime);
    }
	
}
