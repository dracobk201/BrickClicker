using UnityEngine;

public class BrickBehaviour : MonoBehaviour
{
    [SerializeField] private Brick brickData;
    [SerializeField] private GameEvent brickDestroyed;
    private int _life;

    private void OnEnable()
    {
        _life = brickData.impacts;
    }

    public void Impact()
    {
        _life--;
        if (_life <= 0)
            DestroyBrick();
    }
    
    private void DestroyBrick()
    {
        brickDestroyed.Raise();
        gameObject.SetActive(false);
    }
}
