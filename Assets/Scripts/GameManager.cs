﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private bool gameStarted;
    private int freeMexicans,
                workingMexicans,
                selectedSoldier;
    private static int nbSoldiers = 5;
    public List<GameObject> armyGuyList = new List<GameObject>();

    void Awake() {
        gameStarted = true;
        freeMexicans = 0;
        workingMexicans = 0;
        selectedSoldier = 0;

        for (int i = 0; i < nbSoldiers; i++) {
            int type = Random.Range(0, 3);
            string toSpawn;

            switch(type) {
                case 1:
                    toSpawn = "ArmyGuyShoot";
                    break;
                case 2:
                    toSpawn = "ArmyShield";
                    break;
                default:
                    toSpawn = "ArmyGuy";
                    break;
            }


            GameObject armyGuy = (GameObject)Instantiate(Resources.Load(toSpawn), new Vector3(Random.Range(-5.0f, 15.0f), Random.Range(-15.0f, 15.0f), 0), Quaternion.identity);
            
            armyGuy.GetComponent<PlayerController>().armyType = type;
            armyGuy.GetComponent<ArmyGuy>().armyType = type;
            armyGuy.GetComponent<PlayerController>().enabled = false;
            armyGuyList.Add(armyGuy);
        }
    }

    public bool IsGameStarted() {
        return gameStarted;
    }

    public void AddMexicanOnWall() {
        workingMexicans++;
    }

    public void AddMexicanFree() {
        freeMexicans++;
    }

    public int MexicansOnWall() {
        return workingMexicans;
    }

    public int MexicansFree() {
        return freeMexicans;
    }

    public static void SetNbSoldiers(int soldiers)
    {
        nbSoldiers = soldiers;
    }

    public void EndGame(bool goodEnding) {
        gameStarted = false;

        if(goodEnding)
            SceneManager.LoadScene("EndGameGood");
        else
            SceneManager.LoadScene("EndGameBad");
    }

    public void ChangeSelectedSoldier(int i) {
        if (armyGuyList[selectedSoldier] != null) {
            armyGuyList[selectedSoldier].GetComponent<PlayerController>().enabled = false;
            armyGuyList[selectedSoldier].GetComponent<ArmyGuy>().enabled = true;
            armyGuyList[selectedSoldier].gameObject.tag = "ArmyGuy";
        }

        selectedSoldier += i;

        if (selectedSoldier < 0)
            selectedSoldier = armyGuyList.Count - 1;
        else if (selectedSoldier > armyGuyList.Count - 1)
            selectedSoldier = 0;

        if (armyGuyList[selectedSoldier] != null) {
            armyGuyList[selectedSoldier].GetComponent<PlayerController>().enabled = true;
            armyGuyList[selectedSoldier].GetComponent<ArmyGuy>().enabled = false;
            armyGuyList[selectedSoldier].gameObject.tag = "Player";
            transform.position = armyGuyList[selectedSoldier].transform.position + new Vector3(0, 0, -10);
            transform.parent = armyGuyList[selectedSoldier].transform;
        }
        else
            ChangeSelectedSoldier(1);
    }
}
