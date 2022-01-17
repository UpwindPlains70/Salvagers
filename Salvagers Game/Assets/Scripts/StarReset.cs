using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarReset : LevelSelect
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnResetClicked()
    {
        PlayerPrefs.DeleteAll();
    }    

    public void OnQuitClicked()
    {
        Application.Quit();
    }
}
