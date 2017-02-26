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
        bubbleWindow.transform.position = new Vector3(gameObject.transform.position.x + (1.5f), gameObject.transform.position.y + (1.5f));

        StartCoroutine(spawnBubble());
        bubbleWindow.SetActive(false);
        quoteList[0] = "    In God \n  with trust!";
        quoteList[1] = "  Hail \nPresident Trump";
        quoteList[2] = " Don't let \nthem steal \nmy tacos!";
        quoteList[3] = "   look \n them running!";
        quoteList[4] = "For the \nUnited States!";

        quoteList[10] = "  Save \nmy tacos!";
        quoteList[11] = "  I have \nchildren!";
        quoteList[12] = " I need \na job!";
        quoteList[13] = "  I want \nto go to \nTaco Bell!";
        quoteList[14] = "  I walked \nfor hours!";
        quoteList[15] = "GUACAMOLE!";

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
                int quote =-1;
                if (gameObject.CompareTag("ArmyGuy") || gameObject.CompareTag("Player"))
                    quote = Random.Range(0, 4);
                else
                    if(gameObject.CompareTag("Mexican"))
                        quote = Random.Range(10, 15);

                if(quote!=-1)
                    GetComponentInChildren<TextMesh>().text = quoteList[quote];
                yield return new WaitForSeconds(4);
            }
            bubbleWindow.SetActive(false);
        }
    }
}
