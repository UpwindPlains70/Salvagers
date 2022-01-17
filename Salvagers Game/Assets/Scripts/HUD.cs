using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

    public int numMoves;
    public int movesUsed = 0;
    public int visibleStar = 0;

    public Level level;
	public GameOver gameOver;

    protected int currentScore;

    //allows you to asosiate items through inspector(unity) 
    public UnityEngine.UI.Text remainingText;
	public UnityEngine.UI.Text remainingSubtext;
	public UnityEngine.UI.Text targetText;
	public UnityEngine.UI.Text targetSubtext;
	public UnityEngine.UI.Text scoreText;
	public UnityEngine.UI.Image[] stars;

	public int starIdx = 0;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < stars.Length; i++) {
			if (i == starIdx) {
				stars [i].enabled = true;
			} else {
				stars [i].enabled = false;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    //Checks currentscore and assigns stars acordingly
	public void SetScore(int score)
	{
        scoreText.text = score.ToString();

        if (score >= level.score1Star && score < level.score2Star)
            {
                visibleStar = 1;
            }
            else if (score >= level.score2Star && score < level.score3Star)
            {
                visibleStar = 2;
            }
            else if (score >= level.score3Star)
            {
                visibleStar = 3;
            }        

		for (int i = 0; i < stars.Length; i++)
			if (i == visibleStar) {
				stars [i].enabled = true;
			} else {
				stars [i].enabled = false;
			}
            starIdx = visibleStar;
	}
    //inspector input value
	public void SetTarget(int target)
	{
		targetText.text = target.ToString ();
	}
    //inspector input value
    public void SetRemaining(int remaining)
	{
		remainingText.text = remaining.ToString ();
	}
    //inspector input value
    public void SetRemaining(string remaining)
	{
		remainingText.text = remaining;
	}
    //Assigns values to level types
    public void SetLevelType(Level.LevelType type)
	{
		if (type == Level.LevelType.MOVES) {
			remainingSubtext.text = "moves remaining";
			targetSubtext.text = "target score";
		} else if (type == Level.LevelType.OBSTACLE) {
			remainingSubtext.text = "moves remaining";
			targetSubtext.text = "bubbles remaining";
		} else if (type == Level.LevelType.TIMER) {
			remainingSubtext.text = "time remaining";
			targetSubtext.text = "target score";
		}
	}

    //show score and stars on win
	public void OnGameWin(int score)
	{
		gameOver.ShowWin (score, starIdx);
        
            if (starIdx > PlayerPrefs.GetInt(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name, 0))
            {       
            //stores the users score for the level
                PlayerPrefs.SetInt(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name, starIdx);
            }
        
    }

	public void OnGameLose()
	{
		gameOver.ShowLose ();
	}
        
}
