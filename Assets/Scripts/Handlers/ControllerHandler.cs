using UnityEngine;

public class ControllerHandler : MonoBehaviour
{
    [SerializeField] private GameEvent failedTap = null;
    [SerializeField] private GameEvent impactedTap = null;

    private Camera gameCamera;

    private void Start()
    {
        gameCamera = Camera.main;
    }

    private void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Ray rayPosition = gameCamera.ScreenPointToRay(Input.GetTouch(i).position);
                RaycastHit hit;
                if (Physics.Raycast(rayPosition, out hit, Mathf.Infinity))
                {
                    if (hit.collider.CompareTag(Global.BrickTag))
                    {
                        impactedTap.Raise();
                        hit.collider.GetComponent<BrickBehaviour>().Impact();
                    }
                }
                else
                    failedTap.Raise();
            }
        }
    }
}
