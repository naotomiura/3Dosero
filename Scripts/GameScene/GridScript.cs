using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class GridScript : MonoBehaviour
{
    GameObject stone_;//そのグリッドに置いてある架空の石
    GameObject blackStonePrefab_, whiteStonePrefab_;
    BoardScript boardScript_;
    int colNo_, rowNo_;
    int colNum_, rowNum_;
    int dirNum_ = 8; // 8方向
    int[] dirCol_ = new int[8] { -1, 0, 1, -1, 1, -1, 0, 1 }; // 各方向の移動量
    int[] dirRow_ = new int[8] { -1, -1, -1, 0, 0, 1, 1, 1 }; // 各方向の移動量

    public GameObject E1;
    public GameObject E2;
    public GameObject E3;
    public GameObject E4;
    public GameObject E5;
    public GameObject E6;
    public GameObject E7;
    public GameObject E8;
    public GameObject E9;

    //public AudioClip sound1;
    //AudioSource audioSource;

    //void Start()
    //{audioSource = GetComponent<AudioSource>();}

    public void SetColNo(int colNo)
    {
        colNo_ = colNo;
    }

    public void SetRowNo(int rowNo)
    {
        rowNo_ = rowNo;
    }

    public void SetBlackStonePrefab(GameObject blackStonePrefab)
    {
        blackStonePrefab_ = blackStonePrefab;
    }

    public void SetWhiteStonePrefab(GameObject whiteStonePrefab)
    {
        whiteStonePrefab_ = whiteStonePrefab;
    }

    public GameObject GetStone()
    {
        return stone_;
    }

    public void SetBoardScript(BoardScript boardScript)
    {
        boardScript_ = boardScript;
    }

    bool SearchSameColorStone(bool isBlackTurn, int dirNum, int colNo, int rowNo)//同じ色のコマがあるかどうか
    {
        if (colNo >= 0 && colNo < boardScript_.GetColNum() && rowNo >= 0 && rowNo < boardScript_.GetRowNum())
        {
            

            GameObject grid = boardScript_.GetGrid(colNo, rowNo);
            GameObject stone = grid.GetComponent<GridScript>().GetStone();

            if (stone && stone.GetComponent<StoneScript>().IsBlack() == isBlackTurn)//挟むためのコマがあるかどうか
            {
                //Debug.Log("SearchSameColorStone=OK");

                return true;
            }
            else if(stone && stone.GetComponent<StoneScript>().IsBlack() != isBlackTurn)
            {
                return SearchSameColorStone(isBlackTurn, dirNum, colNo + dirCol_[dirNum], rowNo + dirRow_[dirNum]);
            }
            else
            {
                return false;

            }
        }
       

        return false;
    }

    bool JudgeStonePutableDir(bool isBlackTurn, int dir)//各方向のマスにコマが置けるかどうか
    {
        // 1個目が自分と異なる色か確認
        int colNo = colNo_ + dirCol_[dir];
        int rowNo = rowNo_ + dirRow_[dir];
        //Debug.Log("rowNo" + rowNo_ + "colNo" + colNo_);

        if (colNo >= 0 && colNo < boardScript_.GetColNum() && rowNo >= 0 && rowNo < boardScript_.GetRowNum())//−１行目、９行目とかを除外
        {
            
            GameObject grid = boardScript_.GetGrid(colNo, rowNo);
            GameObject stone = grid.GetComponent<GridScript>().GetStone();

            if (stone && stone.GetComponent<StoneScript>().IsBlack() != isBlackTurn)//自分と違う色
            {
                //Debug.Log("JudgeStonePutableDir=OK"); 
                // 自分と同じ色の石を探索していく
                //Debug.Log("置ける");
                return SearchSameColorStone(isBlackTurn, dir, colNo + dirCol_[dir], rowNo + dirRow_[dir]);
            }

        }
        
        return false;
    }

    public bool JudgeStonePutable(bool isBlackTurn)//周りに置ける場所があるかどうか
    {
        for (int d = 0; d < 8; ++d)//8方向
        {
            if (JudgeStonePutableDir(isBlackTurn, d))
            {
                return true;
            }
        }
        
        return false;
    }

    void TurnStoneDir(bool isBlackTurn, int dir, int colNo, int rowNo)
    {
        if (colNo >= 0 && colNo < boardScript_.GetColNum() && rowNo >= 0 && rowNo < boardScript_.GetRowNum())
        {
            GameObject grid = boardScript_.GetGrid(colNo, rowNo);
            GameObject stone = grid.GetComponent<GridScript>().GetStone();

            if (stone && stone.GetComponent<StoneScript>().IsBlack() != isBlackTurn)
            {
                Destroy(stone);

                grid.GetComponent<GridScript>().PutStone(isBlackTurn);

                TurnStoneDir(isBlackTurn, dir, colNo + dirCol_[dir], rowNo + dirRow_[dir]);
            }
            else
            {
                return;
            }
        }
    }

    public void TurnStone(bool isBlackTurn)
    {
        for (int d = 0; d < dirNum_; ++d)
        {
            if (JudgeStonePutableDir(isBlackTurn, d))
            {
                //Debug.Log("colNo_ + dirCol_[d]=" + (colNo_ + dirCol_[d]));//5-1
                //Debug.Log("rowNo_ + dirRow_[d]=" + (rowNo_ + dirRow_[d]));//4-0

                TurnStoneDir(isBlackTurn, d, colNo_ + dirCol_[d], rowNo_ + dirRow_[d]);
            }
        }
    }

    public void PutStone(bool isBlack)
    {
        // 黒か白のPrefabを設定
        GameObject stonePrefab;

        if (isBlack == true){ stonePrefab = blackStonePrefab_; }
        else { stonePrefab = whiteStonePrefab_; }

        GameObject[] E = new GameObject[9];
        E[0] = E1;
        E[1] = E2;
        E[2] = E3;
        E[3] = E4;
        E[4] = E5;
        E[5] = E6;
        E[6] = E7;
        E[7] = E8;
        E[8] = E9;

        int i = PlayerPrefs.GetInt("character") - 1;
        int j = PlayerPrefs.GetInt("character1") - 1;
        int k = PlayerPrefs.GetInt("character2") - 1;
        int l = PlayerPrefs.GetInt("Stage");
       


        // 石を置く
        stone_ = (GameObject)Instantiate(stonePrefab, transform.position+new Vector3(0,1.0f,0), Quaternion.identity);

        if (l == 1)
        {
            Instantiate(E[i], transform.position, Quaternion.identity);
        }
        else if (l == 2)
        {
            if (isBlack == true)
            {
                Instantiate(E[j], transform.position, Quaternion.identity);

            }
            else if (isBlack == false)
            {
                Instantiate(E[k], transform.position, Quaternion.identity);

            }
        }

        //audioSource.PlayOneShot(sound1);

        // 石の色を設定
        stone_.GetComponent<StoneScript>().IsBlack(isBlack);
    }

}