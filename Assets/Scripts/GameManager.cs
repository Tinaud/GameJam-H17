using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private bool gameStarted;
    private int workingMexican,
                selectedSoldier;
    public List<GameObject> armyGuyList = new List<GameObject>();

    void Awake() {
        gameStarted = true;
        workingMexican = 0;
        selectedSoldier = 0;

        for (int i = 0; i < 3; i++) {
            GameObject armyGuy = (GameObject)Instantiate(Resources.Load("ArmyGuy"), new Vector3(Random.Range(-5.0f, 15.0f), Random.Range(-15.0f, 15.0f), 0), Quaternion.identity);
            armyGuy.GetComponent<PlayerController>().enabled = false;
            armyGuyList.Add(armyGuy);
        }
    }

    public bool IsGameStarted() {
        return gameStarted;
    }

    public void AddMexicanOnWall() {
        workingMexican++;
        Debug.Log("Mexicans on the wall : " + workingMexican);
    }

    public int MexicansOnWall() {
        return workingMexican;
    }

    public void EndGame() {
        gameStarted = false;
        workingMexican = 0;

        //Change la scene dépendamment des points yo
        //SceneManager.LoadScene("EndGameGood");
        //SceneManager.LoadScene("EndGameBad");
    }

    public void ChangeSelectedSoldier(int i) {
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
}
