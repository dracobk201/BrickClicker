using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Gameplay/Level")]
public class Level : ScriptableObject
{
    public string levelName;
    public List<BrickDetail> bricks;
}

[Serializable]
public class BrickDetail
{
    public Global.BrickType brickType;
    public Vector3 position;
}
