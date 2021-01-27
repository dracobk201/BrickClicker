using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelGenerationService: ScriptableObject
{
    public abstract Brick[,] GenerateLevel();
}
