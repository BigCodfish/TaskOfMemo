using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropGroupCreater : MonoBehaviour
{
    public NumberFood[] mNumberFoods;
    public Square[] mSquares;
    public Sprite[] mSprites;

    private void Start()
    {
        InitProps();
    }

    public void InitProps()
    {
        for (int i = 0; i < mNumberFoods.Length; i++)
        {
            InitNumberFood(mNumberFoods[i]);
        }
        for (int i = 0; i < mSquares.Length; i++)
        {
            InitSquare(mSquares[i]);
        }
    }

    private void InitNumberFood(NumberFood numberFood)
    {
        float on = Random.Range(0, 1.0f);
        if (on > 0.5f) numberFood.gameObject.SetActive(true);
        else numberFood.gameObject.SetActive(false);
        int number = (int)Random.Range(1, 9.99f);
        numberFood.SetNumber(number);
    }

    private void InitSquare(Square square)
    {
        int id = (int)Random.Range(0, mSprites.Length - 0.01f);
        int number = (int)Random.Range(1, 35);
        square.SetSquare(number, mSprites[id]);
    }

}
