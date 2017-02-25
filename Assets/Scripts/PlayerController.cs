using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public int armyType; //0: Normal, 1: Gunner, 2: Riot Shield
    private float moveSpeed, horizontalSpeed, verticalSpeed;
    private bool action, mexicanTrigger;
    private GameObject closeMexican;

    // Use this for initialization
    void Start () {
        moveSpeed = 5f;
	}

    // Update is called once per frame
    void Update() {

        horizontalSpeed = Input.GetAxis("Horizontal");
        verticalSpeed = Input.GetAxis("Vertical");

        if (Mathf.Abs(horizontalSpeed) > 0.05f) {
            transform.Translate(Vector3.right * horizontalSpeed * moveSpeed * Time.deltaTime);

            if (horizontalSpeed < 0)
                GetComponent<SpriteRenderer>().flipX = true;
            else
                GetComponent<SpriteRenderer>().flipX = false;
        }
            

        if (Mathf.Abs(verticalSpeed) > 0.05)
            transform.Translate(Vector3.up * verticalSpeed * moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.JoystickButton0) && closeMexican != null) {
            switch (armyType) {
                case 1:
                    Destroy(closeMexican.gameObject);
                    break;
                case 2:
                    StartCoroutine(closeMexican.GetComponent<Mexican>().Stun());
                    break;
                default:
                    Camera.main.GetComponent<GameManager>().AddMexicanOnWall();
                    Destroy(closeMexican.gameObject);
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
            closeMexican = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Mexican")
        {
            closeMexican = null;
        }
    }
}

