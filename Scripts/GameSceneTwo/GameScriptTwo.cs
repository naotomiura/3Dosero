using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cinemachine;

public class GameScriptTwo : MonoBehaviour
{

    bool isBlackTurn;
    public BoardScript boardScript_;
    int count = 0;
    GameObject[] black;
    GameObject[] white;
    public int blacknum = 0;
    public int whitenum = 0;
    public GameObject Black = null;
    public GameObject White = null;
    public GameObject Light;
    bool isCalledOnce = false;
    bool isCalledOnce2 = false;
    bool Judge = false;
    bool judge = false;
   
    
    public GameObject camera1;
    public GameObject camera2;

    public CinemachineVirtualCamera camera3;
    public CinemachineVirtualCamera camera4;
    public GameObject CAMERASAN;
    public GameObject CAMERAYON;


    int Count = 0;

    float Timer = 0;

    public GameObject JoyStick;
    
    
    public GameObject TURN;
    public GameObject TURN2;

    public GameObject StartText;
    public GameObject Score;
    public GameObject WIN;
    public GameObject LOSE;
    public GameObject DROW;

    public AudioClip sound1;
    AudioSource audioSource;
    float timer = 0;

    public GameObject c1;
    public GameObject c2;
    public GameObject c3;
    public GameObject c4;
    public GameObject c5;
    public GameObject c6;
    public GameObject c7;
    public GameObject c8;
    public GameObject c9;
    GameObject[] c = new GameObject[9];
    int i = 0;
    int j = 0;




    // タップを検知し、GridScriptを取得する
    bool DetectTap(out GridScript gridScript)
    {
        gridScript = null;

        if (Input.GetMouseButtonDown(0)) // タップ検知
        {
            if (((Input.mousePosition.x >= Screen.width / 4) & (Input.mousePosition.x <= Screen.width * 3 / 4)) | (Input.mousePosition.y >= Screen.height / 4))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit = new RaycastHit();
                if (Physics.Raycast(ray, out hit))
                {
                    GameObject obj = hit.collider.gameObject; // タップしたGameObjectを取得
                    gridScript = obj.GetComponent<GridScript>(); // [重要]GridScriptを取得
                    return true;
                }
            }
        }
        
        return false;
    }

    void SearchPutableGrid(out bool[] isPutableGrid)
    {
        int colNum = boardScript_.GetColNum();//8
        int rowNum = boardScript_.GetRowNum();//8

        isPutableGrid = new bool[colNum * rowNum];//isPutableGridをcolNum * rowNum個作る

        for (int r = 0; r < rowNum; ++r)
        {
            for (int c = 0; c < colNum; ++c)
            {
                GridScript gridScript = boardScript_.GetGrid(c, r).GetComponent<GridScript>();

                if (!gridScript.GetStone() && gridScript.JudgeStonePutable(isBlackTurn))
                {
                    isPutableGrid[r * colNum + c] = true;
                    //Debug.Log(r * colNum + c);
                }
                else
                {
                    isPutableGrid[r * colNum + c] = false;
                }
            }
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isBlackTurn = true;

        c[0] = c1;
        c[1] = c2;
        c[2] = c3;
        c[3] = c4;
        c[4] = c5;
        c[5] = c6;
        c[6] = c7;
        c[7] = c8;
        c[8] = c9;

        i = PlayerPrefs.GetInt("character1") - 1;
        j = PlayerPrefs.GetInt("character2") - 1;

        c[i].SetActive(true);

        camera3.Follow = c[i].GetComponent<Transform>();
        camera3.LookAt = c[i].GetComponent<Transform>();

        camera4.Follow = c[j].GetComponent<Transform>();
        camera4.LookAt = c[j].GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 1 && timer < 2)
        {
            camera1.SetActive(false);
        }

        if (timer > 3 && timer < 4)
        {
            camera2.SetActive(false);
        }
        if (timer > 5)
        {
            StartText.SetActive(true);
            JoyStick.SetActive(true);
            
        }
        if (timer > 6)
        {
            StartText.SetActive(false);

        }


        black = GameObject.FindGameObjectsWithTag("black");
        white = GameObject.FindGameObjectsWithTag("white");

        blacknum = black.Length;
        whitenum = white.Length;

        Text Blackcount = Black.GetComponent<Text>();
        Text Whitecount = White.GetComponent<Text>();
        Blackcount.text = "Black:" + blacknum.ToString();
        Whitecount.text = "White:" + whitenum.ToString();


        if (isBlackTurn == true)
        {
            if (Count == 1)
            {
                camera3.Priority += 2;
            }
            Count = 2;

            if (timer > 5)
            {
                TURN.SetActive(true);
                TURN2.SetActive(false);
            }

            if (i == j)
            {
                c[i].SetActive(true);

            }
            else
            {
                c[i].SetActive(true);
                c[j].SetActive(false);
               
            }

            // タップ検知
            GridScript gridScript;

            //アシスト、自分が置けなくなった時
            bool[] IsPutableGrid;//配列
            SearchPutableGrid(out IsPutableGrid);

            if (!isCalledOnce)
            {
                int r, c;
                Judge = false;

                for (r = 0; r < 8; ++r)
                {
                    for (c = 0; c < 8; ++c)
                    {
                        int index = r * 8 + c;//Gridの番号付け

                        if (IsPutableGrid[index] == true)
                        {
                            Instantiate(Light, new Vector3(10 * c - 35, 5, 35 - 10 * r), Quaternion.Euler(90f, 0f, 0f));
                            //アシスト
                            Judge = true;

                        }
                    }
                }

                isCalledOnce = true;
            }

            if (Judge == false)//自分が置けなくなった時
            {
                //Debug.Log("置けなくなったよー！");
                //notPut.SetActive(true);

                //Invoke("NouPut", 2.0f);

                isBlackTurn = !isBlackTurn;
                isCalledOnce = false;

            }
            else
            {

                if (DetectTap(out gridScript))
                {
                    // グリッドをタップしており、かつ、そこに石が無いなら
                    if (gridScript && !gridScript.GetStone())
                    {
                        //Debug.Log("石ない");
                        // そこに石を置けるなら

                        if (gridScript.JudgeStonePutable(isBlackTurn))
                        {
                            //Debug.Log("石置ける");
                            //// 石を置く


                            
                                gridScript.PutStone(isBlackTurn);
                            
                            //Debug.Log("石置く");
                            audioSource.PlayOneShot(sound1);

                            count++;

                            // ひっくり返す
                            gridScript.TurnStone(isBlackTurn);
                            //Debug.Log("ひっくり返した");

                            GameObject[] obj = GameObject.FindGameObjectsWithTag("LIGHT");
                            foreach (GameObject Object in obj)
                            {
                                Destroy(Object);
                            }

                            isCalledOnce = false;
                            //アシスト再開

                            // 相手のターンに変更
                            isBlackTurn = !isBlackTurn;

                            
                        }
                    }
                }
            }

        }






        if (isBlackTurn == false)
        {
            if (Count == 2)
            {
                camera4.Priority += 2;
            }
            Count = 1;

            TURN.SetActive(false);
            TURN2.SetActive(true);

            if (i == j)
            {
                c[i].SetActive(true);
            }
            else
            {
                c[i].SetActive(false);
                c[j].SetActive(true);
                
            }


            // タップ検知
            GridScript gridScript;

            //アシスト、自分が置けなくなった時
            bool[] ISPutableGrid;//配列
            SearchPutableGrid(out ISPutableGrid);

            if (!isCalledOnce2)
            {
                int a, b;
                judge = false;

                for (a = 0; a < 8; ++a)
                {
                    for (b = 0; b < 8; ++b)
                    {
                        int index = a * 8 + b;//Gridの番号付け
                        if (ISPutableGrid[index] == true)
                        {
                            Instantiate(Light, new Vector3(10 * b - 35, 5, 35 - 10 * a), Quaternion.Euler(90f, 0f, 0f));
                            //アシスト
                            judge = true;

                        }
                    }
                }

                isCalledOnce2 = true;
            }

            if (judge == false)//自分が置けなくなった時
            {
                //Debug.Log("置けなくなったよー！");
                //notPut.SetActive(true);

                //Invoke("NouPut", 2);
                isBlackTurn = !isBlackTurn;

            }
            else
            {

                if (DetectTap(out gridScript))
                {
                    // グリッドをタップしており、かつ、そこに石が無いなら
                    if (gridScript && !gridScript.GetStone())
                    {
                        //Debug.Log("石ない");
                        // そこに石を置けるなら

                        if (gridScript.JudgeStonePutable(isBlackTurn))
                        {
                            //Debug.Log("石置ける");
                            //// 石を置く

                            
                                gridScript.PutStone(isBlackTurn);
                            

                            //Debug.Log("石置く");
                            audioSource.PlayOneShot(sound1);

                            count++;

                            // ひっくり返す
                            gridScript.TurnStone(isBlackTurn);
                            //Debug.Log("ひっくり返した");

                            GameObject[] obj = GameObject.FindGameObjectsWithTag("LIGHT");
                            foreach (GameObject Object in obj)
                            {
                                Destroy(Object);
                            }

                            isCalledOnce2 = false;
                            //アシスト再開

                            // 相手のターンに変更
                            isBlackTurn = !isBlackTurn;

                            
                        }
                    }
                }
            }

        }

        if (count == 60||(Judge==false&&judge==false))
        {

            JoyStick.SetActive(false);
            
            TURN2.SetActive(false);

            CAMERASAN.SetActive(false);
            CAMERAYON.SetActive(false);

            PlayerPrefs.SetInt("BLACKSCORE", blacknum);
            PlayerPrefs.SetInt("WHITESCORE", whitenum);
            PlayerPrefs.Save();

            Timer += Time.deltaTime;
            //Debug.Log(Timer);

            if (Timer > 5)
            {
                if (blacknum > whitenum)
                {
                    Score.SetActive(true);
                    WIN.SetActive(true);
                }
                else if (blacknum < whitenum)
                {
                    Score.SetActive(true);
                    LOSE.SetActive(true);
                }
                else
                {
                    Score.SetActive(true);
                    DROW.SetActive(true);
                }
                //SceneManager.LoadScene("EndScene");
            }
        }
    }

}