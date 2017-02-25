using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentLevel : MonoBehaviour {

    public void Easy() {
        GetComponent<Text>().text = "Easy";
    }

    public void Medium() {
        GetComponent<Text>().text = "Medium";
    }

    public void Hard() {
        GetComponent<Text>().text = "Hard";
    }
}
