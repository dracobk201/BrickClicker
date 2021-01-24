using UnityEngine;
using TMPro;

public class GameplayCanvasActions : MonoBehaviour
{
    [SerializeField] private LevelRuntimeSet levels = null;
    [SerializeField] private IntReference currentLevel = null;
    [SerializeField] private TextMeshProUGUI levelLabel = null;

    public void SetValues()
    {
        levelLabel.text = levels.Items[currentLevel.Value].levelName;
    }
}
