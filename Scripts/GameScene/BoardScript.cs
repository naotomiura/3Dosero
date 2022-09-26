using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BoardScript : MonoBehaviour
{

    public GameObject gridPrefab_, blackStonePrefab_, whiteStonePrefab_,field1,field2, field3, field4;
    int colNum_ = 8, rowNum_ = 8; // 縦横のグリッド数
    int planeSize_ = 10; // 1グリッドの大きさ
    GameObject[] grids_ = new GameObject[64];

    public int GetColNum()
    {
        return colNum_;
    }

    public int GetRowNum()
    {
        return rowNum_;
    }



    public void SetGridPrefab(GameObject GridPrefab)
    {
        gridPrefab_ = GridPrefab;
    }

    public void SetWhiteStonePrefab(GameObject whiteStonePrefab)
    {
        whiteStonePrefab_ = whiteStonePrefab;
    }

    public void SetBlackStonePrefab(GameObject blackStonePrefab)
    {
        blackStonePrefab_ = blackStonePrefab;
    }

    public GameObject GetGrid(int colNo, int rowNo)
    {
        return grids_[rowNo * colNum_ + colNo];
    }




    // グリッド群（オセロ盤）の生成
    public void MakeGrids()
    {
        // 盤中心から端グリッド中心までの距離[グリッド分]
        float offsetX = colNum_ / 2 - 0.5f;
        float offsetZ = rowNum_ / 2 - 0.5f;

        for (int r = 0; r < rowNum_; ++r)
        {
            float posZ = (offsetZ - r) * planeSize_; // グリッド中心のz座標
            for (int c = 0; c < colNum_; ++c)
            {
                // グリッドの生成
                float posX = (c - offsetX) * planeSize_; // グリッド中心のx座標
                Vector3 pos = new Vector3(posX, 0, posZ); // グリッド中心の三次元座標
                GameObject grid = (GameObject)Instantiate(
                    gridPrefab_, pos, Quaternion.identity); // グリッドの生成
               
                // グリッドの登録
                GridScript gridScript = grid.GetComponent<GridScript>();
                gridScript.SetColNo(c);
                gridScript.SetRowNo(r);

                gridScript.SetBlackStonePrefab(blackStonePrefab_);
                gridScript.SetWhiteStonePrefab(whiteStonePrefab_);
                gridScript.SetBoardScript(this);
                grids_[r * colNum_ + c] = grid;
            }
        }

        // 初期配置の生成
        int right = colNum_ / 2;//4
        int left = right - 1;//3
        int bottom = rowNum_ / 2;//4
        int top = rowNum_ / 2 - 1;//3

        grids_[top * colNum_ + left].GetComponent<GridScript>().PutStone(false);
        grids_[bottom * colNum_ + right].GetComponent<GridScript>().PutStone(false);
        grids_[top * colNum_ + right].GetComponent<GridScript>().PutStone(true);
        grids_[bottom * colNum_ + left].GetComponent<GridScript>().PutStone(true);

        field1.SetActive(true);
        field2.SetActive(true);
        field3.SetActive(true);
        field4.SetActive(true);


    }

    public void NewMethod(int c,GridScript gridScript)
    {
        NewMethod(c, gridScript);
    }

    void Start()
    {
        MakeGrids();
    }
}