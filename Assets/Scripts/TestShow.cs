using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestShow : MonoBehaviour
{
    [SerializeField] private LevelGenerationVariable LegelGeneratorService = null;

    void Start()
    {
        CreateNewLevel();
    }

    private void CreateNewLevel()
    {
        Brick[,] aux = LegelGeneratorService.Value.GenerateLevel();

        for (int j = 0; j < aux.GetLength(1); j++)
        {
            string line = "";
            for (int i = 0; i < aux.GetLength(0); i++)
            {
                line += " " + aux[i, j].brickType;
            }
                Debug.Log(line);

        }
    }
}
