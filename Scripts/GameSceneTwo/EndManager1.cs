using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndManager1 : MonoBehaviour
{
    public GameObject WIN;
    public GameObject LOSE;
    public GameObject DROW;

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

    public void END()
    {
        audioSource.PlayOneShot(sound1);
        SceneManager.LoadScene("StartScene");
    }

    public void RETRY()
    {
        audioSource.PlayOneShot(sound1);
        SceneManager.LoadScene("characterselect1");
    }
}
