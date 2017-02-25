using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float speed;

    void Start ()
    {

    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
	
}
