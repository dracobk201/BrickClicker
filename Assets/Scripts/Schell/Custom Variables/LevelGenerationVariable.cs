using UnityEngine;

[CreateAssetMenu(menuName = "Basic Variable/Custom/Level Generation Service")]
public class LevelGenerationVariable : ScriptableObject
{
    public LevelGenerationService Value;
    [TextArea]
    public string Description;

    public void SetValue(LevelGenerationService value)
    {
        Value = value;
    }
}
