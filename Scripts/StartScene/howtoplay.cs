using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class howtoplay : MonoBehaviour
{
    public GameObject Game;
    public GameObject Transform;
    public GameObject Put;

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

    public void OnClickGame()
    {
        audioSource.PlayOneShot(sound1);

        Game.SetActive(true);
        Transform.SetActive(false);
        Put.SetActive(false);
    }

    public void OnClickTransform()
    {
        audioSource.PlayOneShot(sound1);

        Game.SetActive(false);
        Transform.SetActive(true);
        Put.SetActive(false);
    }

    public void OnClickPut()
    {
        audioSource.PlayOneShot(sound1);

        Game.SetActive(false);
        Transform.SetActive(false);
        Put.SetActive(true);
    }
}
