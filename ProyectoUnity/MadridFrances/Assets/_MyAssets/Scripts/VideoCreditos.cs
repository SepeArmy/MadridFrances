using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class VideoCreditos : MonoBehaviour
{
    [SerializeField] VideoClip win;
    [SerializeField] VideoClip lose;

    void Start()
    {
        if (GameManager.THIS.win)
        {
            GetComponent<VideoPlayer>().clip = win;
        }
        else
        {
            GetComponent<VideoPlayer>().clip = lose;
        }

        GetComponent<VideoPlayer>().Play();

        Invoke("NextScene", 21f);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void NextScene()
    {
        SceneManager.LoadScene(0);
    }
}
