using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cameramanager1 : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;
    public GameObject camera3;

    public GameObject Turn;
    public GameObject JoyStick;
    public GameObject JoyStickr;
    public GameObject blackcount;
    public GameObject whitecount;

    public GameObject StartText;
    


    float timer = 0;


    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 1 && timer < 2) {
            camera1.SetActive(false);
        }

        if (timer >3  && timer < 4) {
            camera2.SetActive(false);
        }
        if (timer > 5 )
        {
            StartText.SetActive(true);
            Turn.SetActive(true);
            JoyStick.SetActive(true);
            JoyStickr.SetActive(true);
            blackcount.SetActive(true);
            whitecount.SetActive(true);
        }
        if (timer > 6)
        {
            StartText.SetActive(false);

        }
    }
}
