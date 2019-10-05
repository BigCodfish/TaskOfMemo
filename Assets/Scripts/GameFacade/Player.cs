using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //private float vertical;
    //private float horizontal;

    private Recorder currentRecorder;
    private Quaternion direction;    
    private GameObject mheadPrefab;
    private GameObject mbodyPrefab;
    private GlobalSetting globalSetting;       
    private Vector2 mMoveDir = Vector2.right;
    private SpriteRenderer shieldSprite;
          
    private float speed = 2;
    //每节的距离单位
    private int positionLength = 15;
    //蛇身移动位置
    private List<Vector2> oldPositionList;
    //蛇身
    private List<GameObject> snake;
    //移动频率 在不改变相对位置的情况下增大速度
    private int tempRunTime = 1;
    //护盾开启
    private bool shieldOn = false;

    private void Start()
    {
        
        globalSetting = FindObjectOfType<GlobalSetting>();
        mheadPrefab = Resources.Load("Player/HeadPrefab") as GameObject;
        mbodyPrefab = Resources.Load("Player/BodyPrefab") as GameObject;
        mheadPrefab.GetComponent<SpriteRenderer>().sprite = globalSetting.currentHeadSkin;
        mbodyPrefab.GetComponent<SpriteRenderer>().sprite = globalSetting.currentBodySkin;
        shieldSprite = GetComponent<SpriteRenderer>();
        shieldSprite.enabled = false;
    }

    private void Update()
    {
        //vertical = Input.GetAxis("Vertical");
        //horizontal = Input.GetAxis("Horizontal");
        //mMoveDir = new Vector2(horizontal, vertical).normalized;        
        mMoveDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        mMoveDir = mMoveDir.normalized;
        if (shieldOn) shieldSprite.enabled = true;
    }


    public void InitSnake()
    {
        currentRecorder = FindObjectOfType<IGameScene>().recorder;
        oldPositionList = new List<Vector2>();
        snake = new List<GameObject>();
        snake.Add(Instantiate(mheadPrefab, Vector2.zero, Quaternion.identity, this.transform));
        for (int i = 1; i <= 4; i++)
        {
            snake.Add(Instantiate(mbodyPrefab, new Vector2(transform.position.x, transform.position.y - 0.07f * i), Quaternion.identity, this.transform));
        }
        //一开始有5个蛇身体，每个身体的间隔为positionLength个单元
        for (int i = 0; i < 6 * positionLength + 1; i++)
        {
            oldPositionList.Add(new Vector2(transform.position.x, transform.position.y - 0.07f / positionLength * (i + 1)));
        }
    }

    /// <summary>
    /// 一二种模式中的移动方式
    /// </summary>
    public void FreeMove()
    {
        Debug.DrawLine(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), Color.red);      
        for (int i = 0; i < tempRunTime; i++)
        {
            oldPositionList.Insert(0, transform.position);
            if (mMoveDir == Vector2.zero)
            {
                Vector3 vec = direction * Vector3.up;
                transform.position += vec.normalized * speed * Time.deltaTime;
            }
            else
            {
                //Debug.Log(mMoveDir);
                transform.position += (Vector3)mMoveDir.normalized * speed * Time.deltaTime;
                direction = Quaternion.FromToRotation(Vector2.up, mMoveDir);                
                transform.GetChild(1).rotation = direction;
            }
            FollowHead();
        }
    }

    public void HorizontalMove()
    {

    }

    /// <summary>
    /// 身体跟随
    /// </summary>
    private void FollowHead()
    {
        for (int i = 0; i < snake.Count; i++)
        {
            snake[i].transform.position = oldPositionList[(i) * (positionLength)];
        }
        if (oldPositionList.Count > snake.Count * positionLength + 40)
        {
            oldPositionList.RemoveAt(oldPositionList.Count - 1);
        }
    }

    public void AddBody(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject go = Instantiate(mbodyPrefab, (Vector2)snake[snake.Count - 1].transform.position - mMoveDir * 0.7f, Quaternion.identity, transform);
            for (int j = 0; j < positionLength; j++)
            {
                oldPositionList.Add(go.transform.position);
            }
            snake.Add(go);
        }
        currentRecorder.ChangeData("Score", count * 5 * tempRunTime);
        currentRecorder.ChangeData("SnakeLength", count);
    }

    public void DeleteBody(int count)
    {
        if(shieldOn)
        {
            shieldOn = false;
            shieldSprite.enabled = false;
            return;
        }
        for (int i = 0; i < count; i++)
        {
            Destroy(snake[snake.Count - 1]);
            snake.RemoveAt(snake.Count - 1);
        }
        currentRecorder.ChangeData("Score", -count * 5);
        currentRecorder.ChangeData("SnakeLength", -count);
    }

    public void AddSpeed(int value)
    {
        tempRunTime += value;
        currentRecorder.ChangeData("Energy", value);
    }

    public int GetBodyLength() => snake.Count;

    public bool SetShield() => shieldOn = true;

    //private void OnDrawGizmos()
    //{
    //    for (int i = 0; i < oldPositionList.Count; i++)
    //    {
    //        Gizmos.color = Color.red;
    //        Gizmos.DrawSphere(oldPositionList[i], 0.1f);
    //    }
    //}
}
