using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mexican : MonoBehaviour {

    private float wallHeight;
    public float moveSpeed;
    private GameObject objectiveLocation;
    public List<GameObject> closeEnemies = new List<GameObject>();
    private bool tryAvoidWall;

	void Start () {
        moveSpeed = Random.Range(3.5f, 5.5f);
        objectiveLocation = GameObject.Find("EndZone");
        tryAvoidWall = false;
	}

	void Update () {
        transform.Translate(GetDirection() * moveSpeed * Time.deltaTime);
	}

    Vector2 GetDirection() {
        Vector2 direction = Vector2.zero;

        direction = 2 * Seek(objectiveLocation.transform.position) + Flee();

        if (tryAvoidWall)
            direction += (WallAvoidance());

        return direction.normalized;
    }

    Vector2 Seek(Vector2 pos) {
        return new Vector2(pos.x - transform.position.x, pos.y).normalized;
    }

    Vector2 Flee() {
        Vector2 fleeDirection = Vector2.zero;

        foreach(GameObject g in closeEnemies) {
            if(g != null) {
                Transform a = g.transform;
                Transform m = transform;
                fleeDirection -= new Vector2(a.position.x - m.position.x, a.position.y - m.position.y);
            }
        }

        return fleeDirection.normalized;
    }

    Vector2 WallAvoidance() {
        return new Vector2(0, wallHeight);
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