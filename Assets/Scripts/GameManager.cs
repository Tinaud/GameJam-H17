using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private bool canMove;
	private float moveSpeed;

	void Start () {
		canMove = true;
		moveSpeed = 0.5f;
	}
	
	void Update () {
		if(canMove)
			transform.Translate(Vector3.up *  moveSpeed * Time.deltaTime);

		if(Input.GetKeyDown("space"))
			canMove = !canMove;
	}
}
