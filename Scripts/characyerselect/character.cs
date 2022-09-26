using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class character : MonoBehaviour
{
    public GameObject c1;
    public GameObject c2;
    public GameObject c3;
    public GameObject c4;
    public GameObject c5;
    public GameObject c6;
    public GameObject c7;
    public GameObject c8;
    public GameObject c9;
    public GameObject start;
    public GameObject back;
    public GameObject characterbutton;

    int C1 = 0;
    int C2 = 0;
    int C3 = 0;
    int C4 = 0;
    int C5 = 0;
    int C6 = 0;
    int C7 = 0;
    int C8 = 0;
    int C9 = 0;

    public AudioClip sound1;
    AudioSource audioSource;



    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Onclick1()
    {
        C1++;
        audioSource.PlayOneShot(sound1);
        C2 = 0;C3 = 0;C4 = 0;C5 = 0;C6 = 0;C7 = 0;C8 = 0;C9 = 0;

        if (C1 == 1)
        {
            c1.SetActive(true);
            c2.SetActive(false);
            c3.SetActive(false);
            c4.SetActive(false);
            c5.SetActive(false);
            c6.SetActive(false);
            c7.SetActive(false);
            c8.SetActive(false);
            c9.SetActive(false);
            characterbutton.SetActive(true);

            PlayerPrefs.SetInt("character", 1);
            PlayerPrefs.Save();
        }
        else if(C1==2)
        {
            start.SetActive(true);
            back.SetActive(true);
            characterbutton.SetActive(false);


        }
    }

    public void Onclick2()   
    {
        C2++;
        audioSource.PlayOneShot(sound1);
        C1 = 0; C3 = 0; C4 = 0; C5 = 0; C6 = 0; C7 = 0; C8 = 0; C9 = 0;


        if (C2 == 1)
        {
            c1.SetActive(false);
            c2.SetActive(true);
            c3.SetActive(false);
            c4.SetActive(false);
            c5.SetActive(false);
            c6.SetActive(false);
            c7.SetActive(false);
            c8.SetActive(false);
            c9.SetActive(false);
            characterbutton.SetActive(true);

            PlayerPrefs.SetInt("character", 2);
            PlayerPrefs.Save();
            
        }
        else if (C2 == 2)
        {
            start.SetActive(true);
            back.SetActive(true);
            characterbutton.SetActive(false);


        }
    }

    public void Onclick3()
    {
        C3 ++;
        audioSource.PlayOneShot(sound1);
        C1 = 0; C2 = 0; C4 = 0; C5 = 0; C6 = 0; C7 = 0; C8 = 0; C9 = 0;


        if (C3 == 1)
        {
            c1.SetActive(false);
            c2.SetActive(false);
            c3.SetActive(true);
            c4.SetActive(false);
            c5.SetActive(false);
            c6.SetActive(false);
            c7.SetActive(false);
            c8.SetActive(false);
            c9.SetActive(false);
            characterbutton.SetActive(true);

            PlayerPrefs.SetInt("character",3);
            PlayerPrefs.Save();
           
        }
        else if (C3 == 2)
        {
            start.SetActive(true);
            back.SetActive(true);
            characterbutton.SetActive(false);


        }
    }

    public void Onclick4()
    {
        C4++;
        audioSource.PlayOneShot(sound1);
        C1 = 0; C2 = 0; C3 = 0; C5 = 0; C6 = 0; C7 = 0; C8 = 0; C9 = 0;


        if (C4== 1)
        {
            c1.SetActive(false);
            c2.SetActive(false);
            c3.SetActive(false);
            c4.SetActive(true);
            c5.SetActive(false);
            c6.SetActive(false);
            c7.SetActive(false);
            c8.SetActive(false);
            c9.SetActive(false);
            characterbutton.SetActive(true);

            PlayerPrefs.SetInt("character",4);
            PlayerPrefs.Save();
            
        }
        else if (C4 == 2)
        {
            start.SetActive(true);
            back.SetActive(true);
            characterbutton.SetActive(false);


        }
    }

    public void Onclick5()
    {
        C5++;
        audioSource.PlayOneShot(sound1);
        C1 = 0; C2 = 0; C3 = 0; C4 = 0;  C6 = 0; C7 = 0; C8 = 0; C9 = 0;


        if (C5 == 1)
        {
            c1.SetActive(false);
            c2.SetActive(false);
            c3.SetActive(false);
            c4.SetActive(false);
            c5.SetActive(true);
            c6.SetActive(false);
            c7.SetActive(false);
            c8.SetActive(false);
            c9.SetActive(false);
            characterbutton.SetActive(true);

            PlayerPrefs.SetInt("character",5);
            PlayerPrefs.Save();
            
        }
        else if (C5 == 2)
        {
            start.SetActive(true);
            back.SetActive(true);
            characterbutton.SetActive(false);


        }
    }

    public void Onclick6()
    {
        C6++;
        audioSource.PlayOneShot(sound1);
        C1 = 0; C2 = 0; C3 = 0; C4 = 0; C5 = 0; C7 = 0; C8 = 0; C9 = 0;


        if (C6 == 1)
        {
            c1.SetActive(false);
            c2.SetActive(false);
            c3.SetActive(false);
            c4.SetActive(false);
            c5.SetActive(false);
            c6.SetActive(true);
            c7.SetActive(false);
            c8.SetActive(false);
            c9.SetActive(false);
            characterbutton.SetActive(true);

            PlayerPrefs.SetInt("character",6);
            PlayerPrefs.Save();
            
        }
        else if (C6== 2)
        {
            start.SetActive(true);
            back.SetActive(true);
            characterbutton.SetActive(false);


        }
    }

    public void Onclick7()
    {
        C7++;
        audioSource.PlayOneShot(sound1);
        C1 = 0; C2 = 0; C3 = 0; C4 = 0; C5 = 0; C6 = 0; C8 = 0; C9 = 0;


        if (C7 == 1)
        {
            c1.SetActive(false);
            c2.SetActive(false);
            c3.SetActive(false);
            c4.SetActive(false);
            c5.SetActive(false);
            c6.SetActive(false);
            c7.SetActive(true);
            c8.SetActive(false);
            c9.SetActive(false);
            characterbutton.SetActive(true);

            PlayerPrefs.SetInt("character",7);
            PlayerPrefs.Save();
            
        }
        else if (C7 == 2)
        {
            start.SetActive(true);
            back.SetActive(true);
            characterbutton.SetActive(false);


        }
    }

    public void Onclick8()
    {
        C8++;
        audioSource.PlayOneShot(sound1);
        C1 = 0; C2 = 0; C3 = 0; C4 = 0; C5 = 0; C6 = 0; C7 = 0;  C9 = 0;


        if (C8 == 1)
        {
            c1.SetActive(false);
            c2.SetActive(false);
            c3.SetActive(false);
            c4.SetActive(false);
            c5.SetActive(false);
            c6.SetActive(false);
            c7.SetActive(false);
            c8.SetActive(true);
            c9.SetActive(false);
            characterbutton.SetActive(true);

            PlayerPrefs.SetInt("character",8);
            PlayerPrefs.Save();
           
        }
        else if (C8 == 2)
        {
            start.SetActive(true);
            back.SetActive(true);
            characterbutton.SetActive(false);


        }
    }

    public void Onclick9()
    {
        C9++;
        audioSource.PlayOneShot(sound1);
        C1 = 0; C2 = 0; C3 = 0; C4 = 0; C5 = 0; C6 = 0; C7 = 0; C8 = 0; 


        if (C9== 1)
        {
            c1.SetActive(false);
            c2.SetActive(false);
            c3.SetActive(false);
            c4.SetActive(false);
            c5.SetActive(false);
            c6.SetActive(false);
            c7.SetActive(false);
            c8.SetActive(false);
            c9.SetActive(true);
            characterbutton.SetActive(true);

            PlayerPrefs.SetInt("character",9);
            PlayerPrefs.Save();
            
        }
        else if (C9== 2)
        {
            start.SetActive(true);
            back.SetActive(true);
            characterbutton.SetActive(false);


        }
    }

    public void OnClickcharacer()
    {
        audioSource.PlayOneShot(sound1);

        start.SetActive(true);
        back.SetActive(true);
        characterbutton.SetActive(false);
    }




    public void SceneButton()
    {
        audioSource.PlayOneShot(sound1);

        SceneManager.LoadScene("GameScene");

    }

    public void Back()
    {
        start.SetActive(false);
        back.SetActive(false);
        audioSource.PlayOneShot(sound1);
        C1 = 0;
        C2 = 0;
        C3 = 0;
        C4 = 0;
        C5 = 0;
        C6 = 0;
        C7 = 0;
        C8 = 0;
        C9 = 0;
    }
}
