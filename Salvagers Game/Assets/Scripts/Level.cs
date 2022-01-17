using UnityEngine;
using System.Collections;

public class Level : HUD
{
    bool MovesLeft = true;
    public int numObstaclesLeft;

    //identify level types
    public enum LevelType
    {
        TIMER,
        OBSTACLE,
        MOVES,
    };
    // linking Grid and HUD
    public Grid grid;
    public HUD hud;

    //Links to star pics
    public int score1Star;
    public int score2Star;
    public int score3Star;

    public LevelType type;

    public LevelType Type
    {
        get { return type; }
    }

    //protected int currentScore;

    protected bool didWin;

    // Use this for initialization
    void Start()
    {
        hud.SetScore(currentScore);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void GameWin()
    {
        grid.GameOver();
        didWin = true;
        StartCoroutine(WaitForGridFill());
    }

    public void GameLose()
    {
        grid.GameOver();
        didWin = false;
        StartCoroutine(WaitForGridFill());
    }

    public virtual void OnMove()
    {

    }
    
    

    //updates score and moves once pieces are cleared
    public virtual void OnPieceCleared(GamePiece piece)
    {
        if (Grid.shuffleclick == -1)
        {
            return;
        }
        else
        {
            currentScore += piece.score;
        }
        
        if (currentScore >= score3Star && MovesLeft)
        {
            MovesLeft = false;
            currentScore += 1000 * (numMoves - movesUsed);
        }
        hud.SetScore(currentScore);
    }

    //waits for the grid to fill before displaying gameover screen
    protected virtual IEnumerator WaitForGridFill()
    {
        while (grid.IsFilling)
        {
            yield return new WaitForFixedUpdate();
        }

        if (didWin)
        {
            hud.OnGameWin(currentScore);
        }
        else
        {
            hud.OnGameLose();
        }
    }

    //isolated score checker
    public void StarScore()
    {
        if (Grid.leveltype == 0)
        {
            if (numMoves - movesUsed == 0 || currentScore >= score3Star)
            {
                if (currentScore >= score1Star)
                {
                    GameWin();
                }
                else
                {
                    GameLose();
                }
            }
        }else if (Grid.leveltype == 1)
        {
            if (numObstaclesLeft == 0)
            {
                if (numMoves - movesUsed == 0 || currentScore >= score3Star)
                {
                    if (currentScore >= score1Star)
                    {
                        GameWin();
                    }
                    else
                    {
                        GameLose();
                    }
                }
            }
        }
    }
}
