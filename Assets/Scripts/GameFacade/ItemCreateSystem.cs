using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCreateSystem : MonoBehaviour
{
    [Tooltip("CreatePosLimit")]
    public Transform leftTop, rightBottom;
    [Tooltip("Wall'sPrefabs")]
    public GameObject[] wallPrefabs;
    [Tooltip("FoodPrefab")]
    public GameObject foodPrefab;
    [Tooltip("EnergyPrefab")]
    public GameObject energyPrefab;
    [Tooltip("BombPrefab")]
    public GameObject bombPrefab;
    [Tooltip("SmartGrassPrefab")]
    public GameObject grassPrefab;
    [Tooltip("PoisonousGrassPrefab")]
    public GameObject PoisonousGrassPrefab;
    [Tooltip("MushroomPrefab")]
    public GameObject MushroomPrefab;

    private Transform wallParent;
    private int wallCount = 50;

    /// <summary>
    /// 第一种模式中生成墙
    /// </summary>
    private void CreateWall()
    {
        int wallKind = (int)Random.Range(0, 6.99f);
        Vector2 wallPos = new Vector2(Random.Range(leftTop.position.x, rightBottom.position.x), Random.Range(rightBottom.position.y, leftTop.position.y));
        Instantiate(wallPrefabs[wallKind], wallPos, wallPrefabs[wallKind].transform.rotation, wallParent);
    }

    private void InitWall()
    {
        for (int i = 0; i < wallCount; i++)
        {
            CreateWall();
        }
    }



    private void Start()
    {
        wallParent = GameObject.Find("WallParent").transform;
        InitWall();
    }
}
