using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cinemachine;

public class GameScript : MonoBehaviour
{

    bool isBlackTurn;
    public BoardScript boardScript_;
    int count = 0;
    GameObject[] black;
    GameObject[] white;
    public int blacknum = 0;
    public int whitenum = 0;
    //public GameObject Black = null;
    //public GameObject White = null;
    public GameObject Light;
    bool isCalledOnce = false;
    bool Judge = false;
    bool time = false;
    float Timer = 0;
    float timer = 0;

    public GameObject camera1;
    //public GameObject camera2;
    public GameObject camara3;

    public GameObject JoyStickLeft;
    public GameObject JoyStickRight;

    public GameObject StartText;

    public GameObject TURN;
    public GameObject TURN2;

    public GameObject Score;
    public GameObject WIN;
    public GameObject LOSE;
    public GameObject DROW;

    public AudioClip sound1;
    AudioSource audioSource;






    // タップを検知し、GridScriptを取得する
    bool DetectTap(out GridScript gridScript)
    {
        gridScript = null;
        
        
            if (Input.GetMouseButtonDown(0)) {// タップ検知
        
             if (((Input.mousePosition.x >= Screen.width / 4)&(Input.mousePosition.x <= Screen.width*3 / 4))| (Input.mousePosition.y >= Screen.height / 4))
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


    bool SelectGrid(out GridScript gridScript)
    {
        bool[] isPutableGrid;//配列
        SearchPutableGrid(out isPutableGrid);

        int colNum = boardScript_.GetColNum();
        int rowNum = boardScript_.GetRowNum();
        int[] AnswerPutable = new int[64];
        int count = 0;
        int r, c;

            for (r = 0; r < 8; ++r)
        {
            for (c = 0; c < 8; ++c)
            {
                int index = r * 8 + c;//Gridの番号付け
                if (isPutableGrid[index] == true)
                {
                    count = 1;
                    AnswerPutable[count] = index;
                    count++;
                }
            }
        }
        if (count == 0)
        {
            gridScript = null;
            return false;
        }
        else
        {
            int a = AnswerPutable[Random.Range(1, count)];
            r = a / 8;
            c = a - r*8;
            gridScript = boardScript_.GetGrid(c, r).GetComponent<GridScript>();
            return true;
        }
    }

        // Use this for initialization
        void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isBlackTurn = true;

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
            StartText.SetActive(true);
        }
        if (timer > 5)
        {
            StartText.SetActive(false);
            TURN.SetActive(true);
            JoyStickRight.SetActive(true);
            JoyStickLeft.SetActive(true);
          
        }
        if (timer > 6)
        {
            StartText.SetActive(false);

        }

        black = GameObject.FindGameObjectsWithTag("black");
        white = GameObject.FindGameObjectsWithTag("white");

        blacknum = black.Length;
        whitenum = white.Length;

        //Text Blackcount = Black.GetComponent<Text>();
        //Text Whitecount = White.GetComponent<Text>();
        //Blackcount.text = "Black:"+blacknum.ToString();
        //Whitecount.text = "White:"+whitenum.ToString();

        if (isBlackTurn == true)
        {
            if (timer > 5)
            {
                TURN.SetActive(true);
                TURN2.SetActive(false);
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
                            Judge=true;
                           
                        }
                    }
                }

                isCalledOnce = true; 
            }

            if (Judge== false)//自分が置けなくなった時
            {
                //Debug.Log("置けなくなったよー！");
                isBlackTurn = !isBlackTurn;
                isCalledOnce = false;
                //notPut.SetActive(true);
                //Invoke("NouPut", 2);

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

                            time = false;


                        }
                    }
                }
            }

        }

        if (isBlackTurn == false)
        {
           
            TURN.SetActive(false);
            TURN2.SetActive(true);

            GridScript gridScript;

            SelectGrid(out gridScript);

            if (SelectGrid(out gridScript) == false)
            {
                //notPut.SetActive(true);
                //Invoke("NouPut", 2);

                isBlackTurn = !isBlackTurn;

                if (Judge == false &&Timer==0)
                {
                    JoyStickRight.SetActive(true);
                    JoyStickLeft.SetActive(true);
                    
                    TURN2.SetActive(false);


                    PlayerPrefs.SetInt("BLACKSCORE", blacknum);
                    PlayerPrefs.SetInt("WHITESCORE", whitenum);
                    PlayerPrefs.Save();


                    Timer += Time.deltaTime;

                    camara3.SetActive(false);

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
            else
            {

                StartCoroutine("Coroutine");
                // 石を置く

                if (time == true)
                {
           
                    gridScript.PutStone(isBlackTurn);
                    audioSource.PlayOneShot(sound1);

                    // ひっくり返す
                    gridScript.TurnStone(isBlackTurn);

                    count++;
                    //Debug.Log(count);

                    

                    // 相手のターンに変更
                    isBlackTurn = !isBlackTurn;


                }
            }


        }

        if (count == 60)
        {

            JoyStickRight.SetActive(true);
            JoyStickLeft.SetActive(true);
            
            TURN2.SetActive(false);

            PlayerPrefs.SetInt("BLACKSCORE", blacknum);
            PlayerPrefs.SetInt("WHITESCORE", whitenum);
            PlayerPrefs.Save();

            Timer += Time.deltaTime;

            camara3.SetActive(false);

            

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

    private IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(3.0f);
        time = true;
    }

}