using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class VideoIntro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("NextScene", 15f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void NextScene()
    {
        SceneManager.LoadScene(2);
    }
}
