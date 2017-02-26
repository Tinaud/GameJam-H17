using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public int armyType; //0: Normal, 1: Gunner, 2: Riot Shield
    private float moveSpeed, horizontalSpeed, verticalSpeed;
    private bool action, mexicanTrigger;
    private GameObject closeMexican;
    private int lookDirection;

    // Use this for initialization
    void Start () {
        moveSpeed = 5f;
        lookDirection = 1;
	}

    // Update is called once per frame
    void Update() {

        horizontalSpeed = Input.GetAxis("Horizontal");
        verticalSpeed = Input.GetAxis("Vertical");

        if (Mathf.Abs(horizontalSpeed) > 0.05f) {
            transform.Translate(Vector3.right * horizontalSpeed * moveSpeed * Time.deltaTime);

            Flip(horizontalSpeed);     
        }

        if (Mathf.Abs(verticalSpeed) > 0.05)
            transform.Translate(Vector3.up * verticalSpeed * moveSpeed * Time.deltaTime);


        if (Mathf.Abs(verticalSpeed) < 0.05 && Mathf.Abs(horizontalSpeed) < 0.05f)
            GetComponent<Animator>().SetBool("isIdle", true);
        else
            GetComponent<Animator>().SetBool("isIdle", false);

        if (Input.GetKeyDown(KeyCode.JoystickButton0)) {
            switch (armyType) {
                case 1:
                    GameObject b = (GameObject)Instantiate(Resources.Load("Bullet"), transform.position + new Vector3(lookDirection * 0.5f, -0.1f, 0), Quaternion.identity);
                    b.GetComponent<BulletCollider>().SetDirection(lookDirection);
                    break;
                case 2:
                    GetComponent<Animator>().SetBool("isHitting", true);
                    if(closeMexican != null)
                        StartCoroutine(closeMexican.GetComponent<Mexican>().Stun());
                    break;
                default:
                    GetComponent<Animator>().SetBool("isGrabbing", true);
                    StartCoroutine(Grab());
                    if(closeMexican != null) {
                        Camera.main.GetComponent<GameManager>().AddMexicanOnWall();
                        Destroy(closeMexican.gameObject);
                    }
                    
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

    void Flip(float dir) {
        if (dir < 0) {
            GetComponent<SpriteRenderer>().flipX = true;
            lookDirection = -1;
        }

        else {
            GetComponent<SpriteRenderer>().flipX = false;
            lookDirection = 1;
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

    IEnumerator Grab() {
        yield return new WaitForSeconds(0.1f);
        GetComponent<Animator>().SetBool("isGrabbing", false);
    }
}

