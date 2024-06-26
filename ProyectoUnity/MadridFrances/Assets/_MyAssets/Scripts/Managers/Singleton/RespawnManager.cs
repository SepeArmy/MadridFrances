using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// DESCRIPCION: Gestor del respawn del jugador
/// 
/// </summary>
/// 

public class RespawnManager : MonoBehaviour
{

    public static RespawnManager THIS;

    public bool cuevaCheckPoint_0;
    public bool cuevaCheckPoint_1;
    public bool cuevaCheckPoint_2;
    [SerializeField] private bool[] bosqueInfo;

    void Awake()
    {
        THIS = this;

        

    }

    void Start()
    {
        cuevaCheckPoint_0 = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn_LoadScene()
    {
        TransitionManager.THIS.TransitionOnStarts(GameStates.Playing, TransitionManager.THIS.GetActiveSceneIndex());
    }

    public void CheckRespawn()
    {
        if(TransitionManager.THIS.GetActiveSceneIndex() == 1)
        {
            if (cuevaCheckPoint_0 && cuevaCheckPoint_1 && cuevaCheckPoint_2)
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.transform.position = new Vector3(0f, -0.5f, 1.22f);
                player.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                Destroy(GameObject.FindGameObjectWithTag("Arte"));
                print("CHECKPOINT -> 2");
            }
            else if (cuevaCheckPoint_0 && cuevaCheckPoint_1)
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.transform.position = new Vector3(52f, -1.5f, -1.6f);
                player.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                Destroy(GameObject.FindGameObjectWithTag("Arte"));
                print("CHECKPOINT -> 1");
            }
            else if (cuevaCheckPoint_0)
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                player.transform.position = new Vector3(0f, -0.5f, 1.22f);
                player.transform.eulerAngles = new Vector3(0f, -90f, 0f);
                print("CHECKPOINT -> 0");
            }
        }
    }

    public void RestartRespawns()
    {
        cuevaCheckPoint_1 = false;
        cuevaCheckPoint_2 = false;
    }
}
