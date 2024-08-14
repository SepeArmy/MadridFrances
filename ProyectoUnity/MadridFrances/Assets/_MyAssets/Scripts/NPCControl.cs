using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCControl : MonoBehaviour
{

    public string npcNickname;
    public string npcName;

    public int ownCheckpoint;
    public int checkpointNeeded;

    public GameObject jeanPierreAction;
    public GameObject billete;
    
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void NPCAction()
    {
        if (ownCheckpoint == 1 && !PlayerDataManager.THIS.checkpoints[ownCheckpoint])
        {
            GameManager.THIS.SetState(GameStates.NPC_Chat);
            GetComponent<NPCText>().StartNPCText(3);
        }

        else if (PlayerDataManager.THIS.checkpoints[checkpointNeeded] && PlayerDataManager.THIS.checkpoints[ownCheckpoint])
        {
            GameManager.THIS.SetState(GameStates.NPC_Chat);
            GetComponent<NPCText>().StartNPCText(2);
            
        }
        else if (PlayerDataManager.THIS.checkpoints[checkpointNeeded])
        {
            GameManager.THIS.SetState(GameStates.NPC_Chat);
            GetComponent<NPCText>().StartNPCText(1);
            PlayerDataManager.THIS.checkpoints[ownCheckpoint] = true;
            
        }
        else
        {
            GameManager.THIS.SetState(GameStates.NPC_Chat);
            GetComponent<NPCText>().StartNPCText(0);
        }
        ticket();

    }

    public void OnJeanPierreAction(int answer)
    {
        jeanPierreAction.SetActive(false);
        GameManager.THIS.SetState(GameStates.NPC_Chat);
        GetComponent<NPCText>().StartNPCText(answer);
        PlayerDataManager.THIS.checkpoints[ownCheckpoint] = true;     
    }
    public void ticket()
    {
        if ((PlayerDataManager.THIS.checkpoints[ownCheckpoint] == true) && (PlayerDataManager.THIS.checkpoints[checkpointNeeded] == true))
        {
            Debug.Log("Obtienes el billete");
            Inventario.THIS.objetos[4].SetActive(true);
            PlayerDataManager.THIS.checkpoints[12] = true;

        }
    }


   
}
