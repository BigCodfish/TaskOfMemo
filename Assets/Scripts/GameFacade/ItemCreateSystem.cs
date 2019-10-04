using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCreateSystem : MonoBehaviour
{
    [Tooltip("CreatePosLimit")]
    public Transform leftTop, rightBottom;
    [Tooltip("Wall'sPrefabs")]
    public GameObject[] wallPrefabs;
    [Tooltip("PropPrefab")]
    public GameObject[] propPrefabs;
    [Tooltip("FoodPrefab")]
    public GameObject foodPrefab;

    public List<GameObject> props;
    public List<GameObject> foods;

    private Transform wallParent;
    private Transform propParent;
    private Transform foodParent;
    private int wallCount = 60;
    private int foodCount = 40;
    private int propCount = 30;

    /// <summary>
    /// 第一种模式中生成墙
    /// </summary>
    private void CreateWall()
    {
        int wallKind = (int)Random.Range(0, 6.99f);
        Vector2 wallPos = new Vector2(Random.Range(leftTop.position.x, rightBottom.position.x), Random.Range(rightBottom.position.y, leftTop.position.y));
        Instantiate(wallPrefabs[wallKind], wallPos, wallPrefabs[wallKind].transform.rotation, wallParent);
    }

    public void InitWall()
    {
        for (int i = 0; i < wallCount; i++)
        {
            CreateWall();
        }
    }

    private void CreateFood()
    {
        Vector2 foodPos = new Vector2(Random.Range(leftTop.position.x, rightBottom.position.x), Random.Range(rightBottom.position.y, leftTop.position.y));
        GameObject go = Instantiate(foodPrefab, foodPos, Quaternion.identity, foodParent);           
        foods.Add(go);        
    }

    public void InitFood()
    {
        for (int i = 0; i < foodCount; i++)
        {
            CreateFood();
        }
    }

    public void KeepFoodCount()
    {
        for (int i = 0; i < foods.Count; i++)
        {
            if(foods[i]==null)
            {
                foods.Remove(foods[i]);
                CreateFood();
            }
        }
    }

    private void CreateProp()
    {
        int propKind = (int)Random.Range(0, 4.99f);
        Vector2 propPos = new Vector2(Random.Range(leftTop.position.x, rightBottom.position.x), Random.Range(rightBottom.position.y, leftTop.position.y));
        GameObject go = Instantiate(propPrefabs[propKind], propPos, propPrefabs[propKind].transform.rotation, propParent);
        props.Add(go);
    }

    public void InitProp()
    {
        for (int i = 0; i < propCount; i++)
        {
            CreateProp();
        }
    }

    public void KeepPropCount()
    {
        for (int i = 0; i < props.Count; i++)
        {
            if (props[i] == null)
            {
                props.Remove(props[i]);
                CreateProp();
            }
        }
    }

    private void Start()
    {
        wallParent = GameObject.Find("WallParent").transform;
        foodParent = GameObject.Find("FoodParent").transform;
        propParent = GameObject.Find("PropParent").transform;
    }
}
