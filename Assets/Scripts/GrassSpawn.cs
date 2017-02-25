using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassSpawn : MonoBehaviour {

    private GameManager gm;

    void Start()
    {
        gm = Camera.main.GetComponent<GameManager>();
        StartCoroutine(Spawn());
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(transform.position.x, transform.position.y + Random.Range(-18.0f, 18.0f), 0);
    }

    IEnumerator Spawn()
    {
        while (gm.IsGameStarted())
        {
            yield return new WaitForSeconds(Random.Range(2.0f, 6.0f));
            Instantiate(Resources.Load("Boule"), RandomSpawnPos(), Quaternion.identity);
        }
    }
}
