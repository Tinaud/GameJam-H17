using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MexicanSpawn : MonoBehaviour {

    private GameManager gm;
    
	void Start () {
        gm = Camera.main.GetComponent<GameManager>();
        StartCoroutine(Spawn());
	}

    string RandomMexicanGenerator() {
        int i = Random.Range(0, 3);

        switch(i) {
            case 1:
                return "Mexican2";
            case 2:
                return "Mexican3";
            default:
                return "Mexican1";
        }
    }

    Vector3 RandomSpawnPos() {
        return new Vector3(transform.position.x, transform.position.y + Random.Range(-18.0f, 18.0f), 0);
    }

    IEnumerator Spawn() {
        while(gm.IsGameStarted()) {
            yield return new WaitForSeconds(1f);
            GameObject mexican = (GameObject)Instantiate(Resources.Load(RandomMexicanGenerator()), RandomSpawnPos(), Quaternion.identity);
        }
    }
}
