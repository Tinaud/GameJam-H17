using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnFromBadEnding : MonoBehaviour {

    

    private void Start()
    {
        
    }

    public void Back()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
