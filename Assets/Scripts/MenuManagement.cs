using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManagement: MonoBehaviour {

    private bool gameStarted;
    public List<GameObject> armyGuyList = new List<GameObject>();
    private GameObject _Options, _Menu, _Credits, _Mexican;

    private void Start()
    {
        StartCoroutine(Spawn());

        for (int i = 0; i < 1; i++)
        {
            GameObject armyGuy = (GameObject)Instantiate(Resources.Load("ArmyGuy"), new Vector3(0, 0, 0), Quaternion.identity);
            int type = Random.Range(0, 3);
            armyGuy.GetComponent<PlayerController>().armyType = type;
            armyGuy.GetComponent<ArmyGuy>().armyType = type;
            armyGuy.GetComponent<PlayerController>().enabled = false;
            armyGuyList.Add(armyGuy);

            _Options = GameObject.Find("Options");
            _Menu = GameObject.Find("Menu");
            _Credits = GameObject.Find("Credits");

            _Options.SetActive(false);
            _Menu.SetActive(true);
            _Credits.SetActive(false);
        }
    }

    public void Back()
    {
        _Options.SetActive(false);
        _Menu.SetActive(true);
        _Credits.SetActive(false);
    }

    public void Options()
    {
        _Options.SetActive(true);
        _Menu.SetActive(false);
        _Credits.SetActive(false);
    }

    public void Credits()
    {
        _Options.SetActive(false);
        _Menu.SetActive(false);
        _Credits.SetActive(true);
    }

    public void Play()
    {
        SceneManager.LoadScene("SceneMathieu");
    }

    public void Exit()
    {
        Application.Quit();
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            Instantiate(Resources.Load("MexicanMenu 1"), new Vector3(-12,Random.Range(-10.0f, 10.0f),0), Quaternion.identity);
                yield return new WaitForSeconds(1.0f);
        }
    }
}
