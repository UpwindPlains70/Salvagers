using System.Collections;
using UnityEngine;

public class QuitandPause : HUD {

    public GameObject screenParent;
    public static bool paused = false;

    // Use this for initialization
    void Start () {
        screenParent.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPauseClicked()
    {
        paused = true;
        screenParent.SetActive(true);        
    }

    public void OnResumeClicked()
    {
        screenParent.SetActive(false);
        paused = false;
    }

    public void OnReplayClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void OnExitclicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelSelect");
    }
}
