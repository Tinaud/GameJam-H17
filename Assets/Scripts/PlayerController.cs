using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Vector3 moveDirection = Vector3.zero;

    private int armyType; //0: Normal, 1: Gunner, 2: Riot Shield
    private float moveSpeed, horizontalSpeed, verticalSpeed;
    private bool action, mexicanTrigger;

    // Use this for initialization
    void Start () {
        moveSpeed = 5f;
	}

    // Update is called once per frame
    void Update() {

        horizontalSpeed = Input.GetAxis("Horizontal");
        verticalSpeed = Input.GetAxis("Vertical");

        if (horizontalSpeed > 0)
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

        if (Input.GetKeyDown(KeyCode.JoystickButton0) && mexicanTrigger == true)
        {
            switch (armyType)
            {
                case 0:
                    Camera.main.GetComponent<GameManager>().AddMexicanOnWall();
                    break;
                case 1:
                    //Shot mexican
                    break;
                case 2:
                    //Stun Mexican
                    break;
                default:
                    Camera.main.GetComponent<GameManager>().AddMexicanOnWall();
                    break;
            }
        }

        //Changement de soldat à gauche
        if(Input.GetKeyDown(KeyCode.JoystickButton4)) {
            Camera.main.GetComponent<GameManager>().ChangeSelectedSoldier(-1);
        }

        //Changement de soldat à droite
        if(Input.GetKeyDown(KeyCode.JoystickButton5)) {
            Camera.main.GetComponent<GameManager>().ChangeSelectedSoldier(1);
        }
    }

        private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Mexican")
        {
            mexicanTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Mexican")
        {
            mexicanTrigger = false;
        }
    }
}

