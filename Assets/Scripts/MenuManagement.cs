using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManagement: MonoBehaviour {

    private bool gameStarted;
    private int freeMexicans,
                workingMexicans,
                selectedSoldier;
    private MenuManagement gm;
    public List<GameObject> armyGuyList = new List<GameObject>();
    private GameObject _Options, _Menu, _Credits, _Mexican;

    private void Start()
    {
        gm = Camera.main.GetComponent<MenuManagement>();
        StartCoroutine(Spawn());

        freeMexicans = 0;
        workingMexicans = 0;
        selectedSoldier = 0;

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

    public void EndGame(bool goodEnding)
    {
        
    }

    public void ChangeSelectedSoldier(int i)
    {
        armyGuyList[selectedSoldier].GetComponent<PlayerController>().enabled = false;
        armyGuyList[selectedSoldier].GetComponent<ArmyGuy>().enabled = true;

        selectedSoldier += i;

        if (selectedSoldier < 0)
            selectedSoldier = armyGuyList.Count - 1;
        else if (selectedSoldier > armyGuyList.Count - 1)
            selectedSoldier = 0;

        armyGuyList[selectedSoldier].GetComponent<PlayerController>().enabled = true;
        armyGuyList[selectedSoldier].GetComponent<ArmyGuy>().enabled = false;
        transform.position = armyGuyList[selectedSoldier].transform.position + new Vector3(0, 0, -10);
        transform.parent = armyGuyList[selectedSoldier].transform;
    }


    IEnumerator Spawn()
    {
        while (true)
        {
            _Mexican = (GameObject)Instantiate(Resources.Load("Mexican1"), new Vector3(-5,1,0), Quaternion.identity);
            yield return new WaitForSeconds(4.0f);
            Destroy(_Mexican);
        }
    }
}
