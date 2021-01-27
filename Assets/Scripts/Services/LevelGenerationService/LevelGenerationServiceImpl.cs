using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Service/Level Generation Impl")]
public class LevelGenerationServiceImpl : LevelGenerationService
{
    public int maxSize = 6;
    bool[,] Board;
    private int currentAmount = 4;

    private void CreateBoard()
    {
        Board = new bool[maxSize, maxSize];
        for (var i = 0; i < maxSize; i++)
        {
            for (var j = 0; j < maxSize; j++)
            {
                if (i > 1 && i < 4 && j > 1 && j < 4)
                    Board[i, j] = true;
                else
                {
                    Board[i, j] = Random.value > 0.5f;
                }
            }
        }
    }

    [SerializeField] private IntVariable currentLevel = null;
    [SerializeField] private FloatVariable multiplier = null;

    public override Brick[,] GenerateLevel()
    {
        CreateBoard();
        List<Brick> currentBricks = new List<Brick>();
        Brick[,] aux = new Brick[maxSize, maxSize];

        for (var i = 0; i < maxSize; i++)
        {
            for (var j = 0; j < maxSize; j++)
            {
                aux[i, j] = new Brick();

                if (Board[i, j] == false)
                {
                    aux[i, j].brickType = "NULL";
                }
                else
                {
                    aux[i, j].brickType = "NORMA";
                    currentBricks.Add(aux[i, j]);
                    aux[i, j].impacts = 0;
                }
            }
        }

        for (var i = 0; i < currentAmount; i++)
        {
            currentBricks[Random.Range(0,currentBricks.Count)].impacts++;
        }

        for (var i = 0; i < currentBricks.Count; i++)
        {
            if(currentBricks[i].impacts == 0) {
                currentBricks[i].brickType = "EMPTY";
            }
        }

        return aux;
    }
}
