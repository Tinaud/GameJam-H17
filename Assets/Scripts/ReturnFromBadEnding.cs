using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnFromBadEnding : MonoBehaviour {

    public GameObject unTrump;

    private void Start()
    {
        StartCoroutine(Trump());
    }

    public void Back()
    {
        SceneManager.LoadScene("Main Menu");
    }

    IEnumerator Trump()
    {
        while (true)
        {
            Instantiate(unTrump, new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-8.0f, 8.0f), 0), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
