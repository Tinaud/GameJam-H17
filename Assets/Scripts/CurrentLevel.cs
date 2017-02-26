using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentLevel : MonoBehaviour {

    public void Easy() {
        GameManager.SetNbSoldiers(3);
        GetComponent<Text>().text = "Easy";
    }

    public void Medium() {
        GameManager.SetNbSoldiers(5);
        GetComponent<Text>().text = "Medium";
    }

    public void Hard() {
        GameManager.SetNbSoldiers(10);
        GetComponent<Text>().text = "Hard";
    }
}
