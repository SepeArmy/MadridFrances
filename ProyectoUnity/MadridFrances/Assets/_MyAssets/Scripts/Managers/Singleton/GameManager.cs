using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// DESCRIPCION: Gestor de los estados posibles del juego.
/// Coordina
/// 
/// </summary>

public class GameManager : MonoBehaviour
{
    public static GameManager THIS;

    public Transform actualNPC;

    public GameStates state; // estado actual del juego

    public bool win;

    private void Awake()
    {
        if (THIS == null)
        {
            THIS = this;
            DontDestroyOnLoad(gameObject);
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else Destroy(gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        if (TransitionManager.THIS.GetActiveSceneIndex() == 0)
        {
            SetState(GameStates.MainMenu);
        }
        else
        {
            SetState(GameStates.Playing);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetState (GameStates newState)
    {
        state = newState;
        Debug.Log("GameManager -> New State: " + state);

        // *****************************************************************
        switch (state)
        {

            // *****************************************************************
            case GameStates.MainMenu:
                //Cursor.visible = true;
                //Cursor.lockState = CursorLockMode.Confined;
                MusicManager.THIS.MusicPlay(true, TransitionManager.THIS.GetActiveSceneIndex());
                break;
            // *****************************************************************
            case GameStates.Transitioning:

                TransitionManager.THIS.TransitionOnStarts(GameStates.NPC_Chat, 3);
                break;
            // *****************************************************************
            case GameStates.NPC_Chat:

                break;
            // *****************************************************************
            case GameStates.ObjectOptions:

                break;
            // *****************************************************************
            case GameStates.ObjectChat:

                break;
            // *****************************************************************
            case GameStates.Playing:
                if(MusicManager.THIS.audioSource.isPlaying) MusicManager.THIS.MusicPause();
                MusicManager.THIS.MusicPlay(true, TransitionManager.THIS.GetActiveSceneIndex());
                    

                break;
            // *****************************************************************
            case GameStates.Inventory:
                Cursor.lockState = CursorLockMode.Confined;
                break;
            // *****************************************************************
            case GameStates.FinalLevel:
                break;
            // *****************************************************************
            case GameStates.GameOver:
                break;
            // *****************************************************************
        }
        // *****************************************************************
    }
}

public enum GameStates
{
    MainMenu,
    Transitioning,
    NPC_Chat,
    ObjectOptions,
    ObjectChat,
    Playing,
    Inventory,
    FinalLevel,
    GameOver
}
