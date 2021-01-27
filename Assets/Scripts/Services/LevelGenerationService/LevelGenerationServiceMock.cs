using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Service/Level Generation Mock")]
public class LevelGenerationServiceMock : LevelGenerationService
{
    public int maxSize = 6;
    public override Brick[,] GenerateLevel()
    {

        Brick[,] aux = new Brick[maxSize,maxSize];

        for (var i = 0; i < maxSize; i++)
        {
            for (var j = 0; j < maxSize; j++)
            { 
                aux[i,j] = new Brick();
                aux[i,j].brickType= "EMPTY";
            }
        }
        return aux;
    }
}
