using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyGuy : MonoBehaviour {

    public int armyType; //0: Normal, 1: Gunner, 2: Riot Shield
    private enum States { wander, follow, action }
    private float moveSpeed,
                  angle;
    private Vector2 direction;
    private States actualState;
    private GameObject closeMexican;
    private int lookDirection;

    void Start () {
        actualState = States.wander;
        moveSpeed = 5.0f;
        angle = Random.Range(0.0f, 360.0f);
        lookDirection = 1;
    }
	
	void Update () {
        switch(actualState) {
            case States.follow:
                if (closeMexican != null) {
                    direction = Seek(closeMexican.transform.position);
                    transform.Translate(direction * moveSpeed * Time.deltaTime);
                    Flip(direction);

                    float dist = DistSquare(transform.position, closeMexican.transform.position);

                    if (dist > 40) {
                        moveSpeed -= 0.1f;
                        actualState = States.wander;
                    }
                    else if (dist < 5) {
                        moveSpeed -= 0.1f;
                        actualState = States.action;
                    }
                }
                else
                    actualState = States.wander;
                
                break;
            case States.action:
                if(closeMexican != null)
                    switch (armyType) {
                        case 1:
                            StartCoroutine(Shoot());
                            break;
                        case 2:
                            StartCoroutine(closeMexican.GetComponent<Mexican>().Stun());
                            StartCoroutine(Hit());
                            break;
                        default:
                            GetComponent<Animator>().SetBool("isGrabbing", true);
                            StartCoroutine(Grab());
                            if (closeMexican != null) {
                                Camera.main.GetComponent<GameManager>().AddMexicanOnWall();
                                Destroy(closeMexican.gameObject);
                            }
                            break;
                    }
                actualState = States.wander;
                break;
            default:
                direction = Wander();
                transform.Translate(direction * moveSpeed * Time.deltaTime);
                Flip(direction);
                break;
        }
    }

    Vector2 Wander() {
        Vector2 newDirection;

        angle += Random.Range(-0.2f, 0.2f);

        Clamp(angle, 0.0f, 6.2f);

        newDirection.x = Mathf.Cos(angle);
        newDirection.y = Mathf.Sin(angle);

        return new Vector2(newDirection.x, newDirection.y).normalized;
    }

    Vector2 Seek(Vector2 pos) {
        return new Vector2(pos.x - transform.position.x, pos.y - transform.position.y).normalized;
    }

    float DistSquare(Vector3 a, Vector3 b) {
        return Mathf.Pow(a.x - b.x, 2) + Mathf.Pow(a.y - b.y, 2);
    }

    float Clamp(float i, float min, float max) {
        if (i < min)
            i += max;
        else if (i > max)
            i -= max;
        return i;
    }

    void Flip(Vector2 dir) {
        if (dir.x < 0) {
            GetComponent<SpriteRenderer>().flipX = true;
            lookDirection = -1;
        }
            
        else {
            GetComponent<SpriteRenderer>().flipX = false;
            lookDirection = 1;
        }    
    }

    private void OnCollisionEnter2D(Collision2D other) {
        angle += 3.1f;
        Clamp(angle, 0.0f, 6.2f);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Mexican" && actualState != States.follow) {
            actualState = States.follow;
            moveSpeed += 0.1f;
            closeMexican = other.gameObject;
        }
    }

    IEnumerator Shoot() {
        float temp = moveSpeed;
        moveSpeed = 0;
        GetComponent<Animator>().SetBool("isShooting", true);

        for (int i = 0; i < 3; i++) {
            GameObject b = (GameObject)Instantiate(Resources.Load("Bullet"), transform.position + new Vector3(0.5f, -0.1f, 0), Quaternion.identity);
            b.GetComponent<BulletCollider>().SetDirection(lookDirection);
            yield return new WaitForSeconds(0.5f);
        }

        moveSpeed = temp;

        GetComponent<Animator>().SetBool("isShooting", false);
    }

    IEnumerator Hit() {
        float temp = moveSpeed;
        moveSpeed = 0;
        GetComponent<Animator>().SetBool("isHitting", true);
        yield return new WaitForSeconds(0.3f);

        moveSpeed = temp;

        GetComponent<Animator>().SetBool("isHitting", false);
    }

    public IEnumerator Stun() {
        GameObject tacos = (GameObject)Instantiate(Resources.Load("StunEffect"), transform.position + new Vector3(0, 1.0f, 0), Quaternion.identity);
        float temp = moveSpeed;
        moveSpeed = 0;
        yield return new WaitForSeconds(2f);
        Destroy(tacos.gameObject);
        moveSpeed = temp;
    }

    IEnumerator Grab() {
        yield return new WaitForSeconds(0.1f);
        GetComponent<Animator>().SetBool("isGrabbing", false);
    }
}
