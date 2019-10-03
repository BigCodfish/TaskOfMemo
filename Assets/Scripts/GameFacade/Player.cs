using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveMode
{
    FREE,
    HORIZONTAL
}

public class Player : MonoBehaviour
{
    private Quaternion direction;
    //移动方式
    private MoveMode mMoveMode;
    private GameObject mheadPrefab;
    private GameObject mbodyPrefab;
    private GlobalSetting globalSetting;
    //蛇身
    private List<GameObject> snake;

    private List<Vector2> oldPositionList;
    private Vector2 mMoveDir = Vector2.right;
    private int positionLength = 5;
    private float vertical;
    private float horizontal;
    private float speed = 1;

    private void Start()
    {
        globalSetting = FindObjectOfType<GlobalSetting>();
        mheadPrefab = Resources.Load("Player/HeadPrefab") as GameObject;
        mbodyPrefab = Resources.Load("Player/BodyPrefab") as GameObject;
        mheadPrefab.GetComponent<SpriteRenderer>().sprite = globalSetting.currentHeadSkin;
        mbodyPrefab.GetComponent<SpriteRenderer>().sprite = globalSetting.currentBodySkin;

        InitSnake();
    }

    private void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        mMoveDir = new Vector2(horizontal, vertical).normalized;
        if (mMoveMode == MoveMode.FREE) FreeMove();
    }


    private void InitSnake()
    {
        oldPositionList = new List<Vector2>();
        snake = new List<GameObject>();
        snake.Add(Instantiate(mheadPrefab, Vector2.zero, Quaternion.identity, this.transform));
        for (int i = 1; i <= 3; i++)
        {
            snake.Add(Instantiate(mbodyPrefab, (Vector2)snake[i-1].transform.position-mMoveDir, Quaternion.identity, this.transform));
        }
    }

    private void FreeMove()
    {
        Vector3 stickAxis = mMoveDir;
        int tempRunTime = 1;
        for (int i = 0; i < tempRunTime; i++)
        {
            oldPositionList.Insert(0, transform.position);
            if (stickAxis == Vector3.zero)
            {
                Vector3 vec = direction * Vector3.up;
                transform.position += vec.normalized * speed * Time.deltaTime;
            }
            else
            {
                transform.position += stickAxis.normalized * speed * Time.deltaTime;
                direction = Quaternion.FromToRotation(Vector2.up, stickAxis);
                transform.rotation = direction;
            }
            FollowHead();
        }
    }

    /// <summary>
    /// 身体跟随
    /// </summary>
    private void FollowHead()
    {
        for (int i = 0; i < snake.Count; i++)
        {
            snake[i].transform.position = oldPositionList[(i + 1) * (positionLength)];
        }
        if (oldPositionList.Count > snake.Count * positionLength + 40)
        {
            oldPositionList.RemoveAt(oldPositionList.Count - 1);
        }
    }

    private void HorizontalMove()
    {

    }

}
