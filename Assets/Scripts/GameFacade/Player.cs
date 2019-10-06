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
    private Rigidbody2D mRigidbody;      

    public float speed = 2;
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
    //色彩模式的颜色
    public Color mcolor;

    private void Start()
    {
        globalSetting = FindObjectOfType<GlobalSetting>();
        
        mRigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetShieldSprite()
    {
        shieldSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        shieldSprite.enabled = false;
    }

    public void InitSnake(int initLength)
    {
        //皮肤
        mheadPrefab = Resources.Load("Player/HeadPrefab") as GameObject;
        mbodyPrefab = Resources.Load("Player/BodyPrefab") as GameObject;
        mheadPrefab.GetComponent<SpriteRenderer>().sprite = globalSetting.currentHeadSkin;
        mbodyPrefab.GetComponent<SpriteRenderer>().sprite = globalSetting.currentBodySkin;

        currentRecorder = FindObjectOfType<IGameScene>().recorder;
        oldPositionList = new List<Vector2>();
        snake = new List<GameObject>();
        snake.Add(Instantiate(mheadPrefab, Vector2.zero, Quaternion.identity, this.transform));
        for (int i = 1; i <= initLength; i++)
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
    /// 色彩模式的初始化
    /// </summary>
    public void InitColorSnake()
    {
        mcolor = Color.white;
        mheadPrefab = Resources.Load("Player/ColorSnakePrefab") as GameObject;
        mbodyPrefab = Resources.Load("Player/ColorSnakePrefab") as GameObject;
        currentRecorder = FindObjectOfType<IGameScene>().recorder;
        oldPositionList = new List<Vector2>();
        snake = new List<GameObject>();
        snake.Add(Instantiate(mheadPrefab, Vector2.zero, Quaternion.identity, this.transform));
        for (int i = 1; i <= 40; i++)
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
    /// 一种模式中的移动方式
    /// </summary>
    public void FreeMove()
    {
        mMoveDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        mMoveDir = mMoveDir.normalized;
        //第一个模式的护盾
        if (shieldOn) shieldSprite.enabled = true;
        for (int i = 0; i < tempRunTime; i++)
        {
            oldPositionList.Insert(0, transform.position);
            if (mMoveDir == Vector2.zero)
            {
                Vector3 vec = direction * Vector3.up;
                //transform.position += vec.normalized * speed * Time.deltaTime;
                transform.position += transform.position + vec.normalized * speed * Time.deltaTime;
            }
            else
            {
                transform.position += (Vector3)mMoveDir.normalized * speed * Time.deltaTime;
                //mRigidbody.AddForce(transform.position + (Vector3)mMoveDir.normalized * speed * Time.deltaTime);
                direction = Quaternion.FromToRotation(Vector2.up, mMoveDir);
                transform.GetChild(1).rotation = direction;
            }
            FollowHead();
        }
    }

    /// <summary>
    /// 二种模式中的移动方式
    /// </summary>
    public void FreeMove2()
    {
        mMoveDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        mMoveDir = mMoveDir.normalized;
        //第一个模式的护盾
        if (shieldOn) shieldSprite.enabled = true;
        for (int i = 0; i < 1; i++)
        {
            oldPositionList.Insert(0, transform.position);
            if (mMoveDir == Vector2.zero)
            {
                Vector3 vec = direction * Vector3.up;
                //transform.position += vec.normalized * speed * Time.deltaTime;
                mRigidbody.MovePosition(transform.position + vec.normalized * speed * Time.deltaTime);
            }
            else
            {
                mRigidbody.velocity = mMoveDir.normalized * speed * Time.deltaTime;
                //mRigidbody.AddForce(transform.position + (Vector3)mMoveDir.normalized * speed * Time.deltaTime);
                direction = Quaternion.FromToRotation(Vector2.up, mMoveDir);
                transform.GetChild(1).rotation = direction;
            }
            FollowHead();
        }
    }

    public void HorizontalMove()
    {
        mMoveDir = new Vector2(0, (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).y);
        //mMoveDir = mMoveDir.normalized;
        mMoveDir += Vector2.right;
        for (int i = 0; i < tempRunTime; i++)
        {
            oldPositionList.Insert(0, transform.position);
            if (mMoveDir == Vector2.zero)
            {
                Vector3 vec = direction * Vector3.up;
                //transform.position += vec.normalized * speed * Time.deltaTime;
                mRigidbody.MovePosition(transform.position + vec.normalized * speed * Time.deltaTime);

            }
            else
            {
                mRigidbody.velocity= mMoveDir.normalized * speed * Time.deltaTime;
                //mRigidbody.AddForce(transform.position + (Vector3)mMoveDir.normalized * speed * Time.deltaTime);
                direction = Quaternion.FromToRotation(Vector2.up, mMoveDir);
                transform.GetChild(1).rotation = direction;
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
            GameObject go = Instantiate(mbodyPrefab, (Vector2)snake[snake.Count - 1].transform.position, Quaternion.identity, transform);
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
            if (snake.Count - 1 < 0) return;
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

    public void DeleteSnake()
    {
        for (int i = 0; i < snake.Count; i++) Destroy(snake[i]);                
    }

    //private void OnDrawGizmos()
    //{
    //    for (int i = 0; i < oldPositionList.Count; i++)
    //    {
    //        Gizmos.color = Color.red;
    //        Gizmos.DrawSphere(oldPositionList[i], 0.1f);
    //    }
    //}
}
