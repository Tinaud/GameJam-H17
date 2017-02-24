using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Vector3 moveDirection = Vector3.zero;

    public float moveSpeed;
    private float horizontalSpeed, verticalSpeed;
    private bool action;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        horizontalSpeed = Input.GetAxis("Horizontal");
        verticalSpeed = Input.GetAxis("Vertical");
        //action = Input.GetKeyDown("JoystickButton1");

        if(horizontalSpeed > 0)
        {
            transform.Translate(Vector3.right * horizontalSpeed * moveSpeed * Time.deltaTime);
        }

        if (horizontalSpeed < 0)
        {
            transform.Translate(Vector3.left * -horizontalSpeed * moveSpeed * Time.deltaTime);
        }

        if (verticalSpeed > 0)
        {
            transform.Translate(Vector3.up * verticalSpeed * moveSpeed * Time.deltaTime);
        }

        if (verticalSpeed < 0)
        {
            transform.Translate(Vector3.down * -verticalSpeed * moveSpeed * Time.deltaTime);
        }
    }
}
