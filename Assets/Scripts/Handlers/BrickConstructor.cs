using System.Collections.Generic;
using UnityEngine;

public class BrickConstructor : MonoBehaviour
{
    [SerializeField] private LevelRuntimeSet levels = null;
    [SerializeField] private IntReference currentLevel = null;
    [SerializeField] private IntReference remainingBricks = null;
    [SerializeField] private IntReference brickPool = null;
    [SerializeField] private GameObject firstBrick = null;
    [SerializeField] private GameObject secondBrick = null;
    [SerializeField] private GameObject thirdBrick = null;
    [SerializeField] private GameObject fourthBrick = null;
    [SerializeField] private GameObject fifthBrick = null;
    [SerializeField] private Transform firstBrickHolder = null;
    [SerializeField] private Transform secondBrickHolder = null;
    [SerializeField] private Transform thirdBrickHolder = null;
    [SerializeField] private Transform fourthBrickHolder = null;
    [SerializeField] private Transform fifthBrickHolder = null;
    private List<GameObject> firstBricks;
    private List<GameObject> secondBricks;
    private List<GameObject> thirdBricks;
    private List<GameObject> fourthBricks;
    private List<GameObject> fifthBricks;

    private void Awake()
    {
        firstBricks = new List<GameObject>();
        secondBricks = new List<GameObject>();
        thirdBricks = new List<GameObject>();
        fourthBricks = new List<GameObject>();
        fifthBricks = new List<GameObject>();
        InstantiateBricks();
    }

    private void Start()
    {
        GenerateCurrentLevel();
    }

    private void InstantiateBricks()
    {
        GeneratorByBrick(firstBrick, firstBrickHolder, firstBricks);
        GeneratorByBrick(secondBrick, secondBrickHolder, secondBricks);
        GeneratorByBrick(thirdBrick, thirdBrickHolder, thirdBricks);
        GeneratorByBrick(fourthBrick, fourthBrickHolder, fourthBricks);
        GeneratorByBrick(fifthBrick, fifthBrickHolder, fifthBricks);
    }

    private void GenerateCurrentLevel()
    {
        Level levelToCreate = levels.Items[currentLevel.Value];
        remainingBricks.Value = levelToCreate.bricks.Count;
        foreach (var brick in levelToCreate.bricks)
        {
            switch (brick.brickType)
            {
                case Global.BrickType.First:
                    SearchAndActivate(firstBricks, brick.position);
                    break;
                case Global.BrickType.Second:
                    SearchAndActivate(secondBricks, brick.position);
                    break;
                case Global.BrickType.Third:
                    SearchAndActivate(thirdBricks, brick.position);
                    break;
                case Global.BrickType.Fourth:
                    SearchAndActivate(fourthBricks, brick.position);
                    break;
                case Global.BrickType.Fifth:
                    SearchAndActivate(fifthBricks, brick.position);
                    break;
            }
        }
    }

    private static void SearchAndActivate(List<GameObject> list, Vector3 position)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (!list[i].activeInHierarchy)
            {
                list[i].transform.localPosition = position;
                list[i].transform.localRotation = Quaternion.identity;
                list[i].SetActive(true);
                break;
            }
        }
    }

    private void GeneratorByBrick(GameObject brick, Transform holder, List<GameObject> list)
    {
        for (int i = 0; i < brickPool.Value; i++)
        {
            GameObject brickObject = Instantiate(brick);
            brickObject.GetComponent<Transform>().SetParent(holder);
            brickObject.SetActive(false);
            list.Add(brickObject);
        }
    }
}
