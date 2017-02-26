using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    int nbOnWall, nbInCountry;
    float wScale;
    GameObject nbWall, nbFree, wallBuilt;

	void Start () {
        nbOnWall = GetComponent<GameManager>().MexicansOnWall();
        nbInCountry = GetComponent<GameManager>().MexicansFree();
        wScale = GetComponent<Wall>().WallScale();

        wallBuilt = GameObject.Find("%");
        nbWall = GameObject.Find("Wnb");
        nbFree = GameObject.Find("Cnb");
	}
	
	void Update () {
        nbWall.GetComponent<Text>().text = "Number of immigrants" + "\n" + "on the wall:" + nbOnWall.ToString();
        nbFree.GetComponent<Text>().text = "Number of immigrants" + "\n" + "in the Country:" + nbInCountry.ToString();
        wallBuilt.GetComponent<Text>().text = "Wall built:" + Pourcentage(wScale).ToString() + "%";
	}

    public float Pourcentage(float wScale)
    {
        return (wScale / 19.15f) * 100.0f;
    }
}
