using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Object : MonoBehaviour
{
    public string objectName;
    public int objectID;

    /*
    Macarron    = 0
    Cromo       = 1
    Bigote      = 2
    Pelota      = 3
    Billete     = 4
    Gazpacho    = 5
    Pinceles    = 6
    */
    public int owncheckpoint;

    public Sprite image;

    public string verText;
    public string cojerText;
    

    public bool objectoCogible;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
