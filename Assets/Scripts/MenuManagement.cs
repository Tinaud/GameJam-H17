using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManagement: MonoBehaviour {

    private GameObject _Options, _Menu, _Credits;

    private void Start()
    {
        
        _Options = GameObject.Find("Options");
        _Menu = GameObject.Find("Menu");
        _Credits = GameObject.Find("Credits");

        _Options.SetActive(false);
        _Menu.SetActive(true);
        _Credits.SetActive(false);
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
}
