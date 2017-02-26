using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuotesSpawn : MonoBehaviour
{

    private string[] quoteList = new string[20];
    private GameObject bubbleWindow;

    // Use this for initialization
    void Start()
    {
        bubbleWindow = Instantiate(Resources.Load("QuoteBubble", typeof(GameObject))) as GameObject;
        bubbleWindow.transform.parent = gameObject.transform;

        StartCoroutine(spawnBubble());
        bubbleWindow.SetActive(false);
        quoteList[0] = "    In God \n  with trust!";
        quoteList[1] = "  Gloire au \nPrésident Trump";
        quoteList[2] = " Ne les \nlaissez pas \nvoler nos tacos!";
        quoteList[3] = "   Regardez \n les courrir!";
        quoteList[4] = "Vive les \nÉtats-Unis d'Amérique!";

        quoteList[10] = "  Sauvez \nmes tacos!";
        quoteList[11] = "  J'ai des \nenfants!";
        quoteList[12] = " J'ai besoin \nd'un travail!";
        quoteList[13] = "  Je veux \nmanger chez \nTaco Bell!";
        quoteList[14] = "  Ça fait \ndes heures \nque je marche!";
        quoteList[15] = "GUACAMOLE!";

    }

    void Update()
    {
        bubbleWindow.transform.position = new Vector3(gameObject.transform.position.x+(1.5f),gameObject.transform.position.y+(1.5f));
    }

    IEnumerator spawnBubble()
    {
        yield return new WaitForSeconds(2);

        while (Camera.main.GetComponent<GameManager>().IsGameStarted())
        {
            yield return new WaitForSeconds(2);
            if (Random.Range(0, 5) == 3)
            {
                bubbleWindow.SetActive(true);
                int quote;
                if (gameObject.CompareTag("ArmyGuy"))
                    quote = Random.Range(0, 4);
                else
                    quote = Random.Range(10, 15);

                GetComponentInChildren<TextMesh>().text = quoteList[quote];
                yield return new WaitForSeconds(4);
            }
            bubbleWindow.SetActive(false);
        }
    }
}
