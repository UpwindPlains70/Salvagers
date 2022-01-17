using UnityEngine;
using System.Collections;

public class LevelObstacles : Level
{

    public Grid.PieceType[] obstacleTypes;

    // Use this for initialization
    void Start()
    {
        Grid.MaxShufflesReached = false;
        Grid.leveltype = 1;

        type = LevelType.OBSTACLE;

        for (int i = 0; i < obstacleTypes.Length; i++)
        {
            numObstaclesLeft += grid.GetPiecesOfType(obstacleTypes[i]).Count;
        }

        hud.SetLevelType(type);
        hud.SetScore(currentScore);
        hud.SetTarget(numObstaclesLeft);
        hud.SetRemaining(numMoves);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnMove()
    {
        movesUsed++;

        hud.SetRemaining(numMoves - movesUsed);

        if (numMoves - movesUsed == 0 && numObstaclesLeft > 0 || numMoves - movesUsed == 0 && currentScore < score1Star)
        {
            GameLose();
        }
    }


    public override void OnPieceCleared(GamePiece piece)
    {
        base.OnPieceCleared(piece);

        for (int i = 0; i < obstacleTypes.Length; i++)
        {
            if (obstacleTypes[i] == piece.Type)
            {
                numObstaclesLeft--;
                hud.SetTarget(numObstaclesLeft);
            }
        }
        StarScore();
        /*if (numObstaclesLeft == 0)
        {
            if (numMoves - movesUsed == 0 && currentScore >= score1Star)
            {
                currentScore += 1000 * (numMoves - movesUsed);
                hud.SetScore(currentScore);
                GameWin();
            }
        }*/
    }
}
	

