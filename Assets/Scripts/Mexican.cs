using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mexican : MonoBehaviour {

    private enum States { run, shoot, flee };
    private float moveSpeed,
                  wallHeight;
    public GameObject objectiveLocation;
    private States actualState;
    private List<GameObject> closeEnemies = new List<GameObject>();
    private bool tryAvoidWall;

	void Start () {
        moveSpeed = Random.Range(3.5f, 5.5f);
        actualState = States.run;
        objectiveLocation = GameObject.Find("EndZone");
        tryAvoidWall = false;
	}

	void Update () {
        transform.Translate(GetDirection() * moveSpeed * Time.deltaTime);
	}

    Vector2 GetDirection() {
        Vector2 direction = Vector2.zero;

        switch (actualState) {
            case States.run:
                direction = 2 * Seek(objectiveLocation.transform.position) + Flee();

                if (tryAvoidWall)
                    direction += (WallAvoidance());

                break;
        }
        
        return direction.normalized;
    }

    Vector2 Seek(Vector2 pos) {
        return new Vector2(pos.x - transform.position.x, pos.y).normalized;
    }

    Vector2 Flee() {
        Vector2 fleeDirection = Vector2.zero;

        foreach(GameObject g in closeEnemies) {
            Transform a = g.transform;
            Transform m = transform;
            fleeDirection -= new Vector2(a.position.x - m.position.x, a.position.y - m.position.y);
        }

        return fleeDirection.normalized;
    }

    Vector2 WallAvoidance() {
        return new Vector2(0, wallHeight);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "ArmyGuy")
            closeEnemies.Add(other.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "ArmyGuy")
            closeEnemies.Remove(other.gameObject);
    }

    public void WallClose(Transform t) {
        tryAvoidWall = !tryAvoidWall;
        wallHeight = t.localScale.y + 5;
    }

    public IEnumerator Stun() {
        float temp = moveSpeed;
        moveSpeed = 0;
        yield return new WaitForSeconds(2f);
        moveSpeed = temp;
    }
}