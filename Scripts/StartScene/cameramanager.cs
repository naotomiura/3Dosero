using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramanager : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;
    public GameObject camera3;
    public GameObject camera4;
    public GameObject camera5;
    public GameObject StartBotton;
    public GameObject Title;


    float timer = 0;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 1 && timer < 2) {
            camera1.SetActive(false);
        }

        if (timer >3  && timer < 4) {
            camera2.SetActive(false);
        }
        if (timer > 5 && timer < 6)
        {
            camera3.SetActive(false);
        }
        if (timer >7 && timer < 8)
        {
            camera4.SetActive(false);
        }
        if (timer > 9)
        {
            StartBotton.SetActive(true);
            Title.SetActive(true);

        }


    }
}
