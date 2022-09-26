using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{
    public GameObject Howto;
    public GameObject Select;
    //public GameObject Setting;
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

    public void OnClick()
    {
        //Select.SetActive(true);
        SceneManager.LoadScene("GameScene");
        audioSource.PlayOneShot(sound1);
    }

    public void OnClickCPU()
    {
        audioSource.PlayOneShot(sound1);
        PlayerPrefs.SetInt("Stage", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene("characterselect");
    }

    public void OnClickTwo()
    {
        audioSource.PlayOneShot(sound1);
        PlayerPrefs.SetInt("Stage", 2);
        PlayerPrefs.Save();
        SceneManager.LoadScene("characterselect 1");
    }



    public void OnClickHowto()
    {
        Howto.SetActive(true);
        audioSource.PlayOneShot(sound1);
        
    }

    public void OnClickback()
    {
        audioSource.PlayOneShot(sound1);
        Howto.SetActive(false);

    }
    public void OnClickback2()
    {
        audioSource.PlayOneShot(sound1);
        Select.SetActive(false);

    }
}
