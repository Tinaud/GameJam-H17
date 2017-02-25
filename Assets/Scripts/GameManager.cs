using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private bool gameStarted;
    private int workingMexican;
    private List<GameObject> mexican_list;

	void Awake () {
        gameStarted = true;
        workingMexican = 0;
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
    }
}
