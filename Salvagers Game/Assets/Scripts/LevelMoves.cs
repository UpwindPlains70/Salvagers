using UnityEngine;
using System.Collections;


public class LevelMoves : Level
{

    public int targetScore;

    // Use this for initialization
    void Start()
    {
        Grid.MaxShufflesReached = false;
        Grid.leveltype = 0;

        type = LevelType.MOVES; 

        hud.SetLevelType(type);
        hud.SetScore(currentScore);
        hud.SetTarget(targetScore);
        hud.SetRemaining(numMoves);
    }

    // Update is called once per frame
    void Update()
    {

    }
    //updates moves remaining and checks score
    public override void OnMove()
    {
            movesUsed++;

            hud.SetRemaining(numMoves - movesUsed);

        if (numMoves - movesUsed == 0 || currentScore >= score3Star)
        {
            if (currentScore >= score3Star)
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
