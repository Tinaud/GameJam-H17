using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    int nbOnWall, nbInCountry;
    float wScale;
    GameObject nbWall, nbFree, wallBuilt, WALL;

	void Start () {
       
        WALL = GameObject.Find("WALL");
        wallBuilt = GameObject.Find("%");
        nbWall = GameObject.Find("Wnb");
        nbFree = GameObject.Find("Cnb");
	}
	
	void Update () {

        nbOnWall = GetComponent<GameManager>().MexicansOnWall();
        nbInCountry = GetComponent<GameManager>().MexicansFree();
        wScale = WALL.GetComponent<Wall>().WallScale();

        nbWall.GetComponent<Text>().text = nbOnWall.ToString();
        nbFree.GetComponent<Text>().text = nbInCountry.ToString();
        
        if(Pourcentage(wScale) >= 100.0f)
        {
            wallBuilt.GetComponent<Text>().text = "100%";
        }
        else
        {
            wallBuilt.GetComponent<Text>().text = Pourcentage(wScale).ToString() + "%";
        }
	}

    public int Pourcentage(float wScale)
    {
        return (int)(((wScale / 19.15f) * 100.0f) - 7);
    }
}
