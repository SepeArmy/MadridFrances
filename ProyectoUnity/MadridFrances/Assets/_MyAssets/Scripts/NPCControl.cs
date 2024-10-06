using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCControl : MonoBehaviour
{

    public string npcNickname;
    public string npcName;

    [SerializeField]  public int ownCheckpoint;
    public int checkpointNeeded; 

    public int checkPointCromo;//para la niña: se activa cuando se complete la acción conjunto cromo
    public int checkpointFan; //hablar con el fan
    public int checkpointNiña2; //hablar con la niña despues de hablar con el fan

    public GameObject jeanPierreAction;
    public GameObject billete;
    public GameObject objectos;//almacena los objetos
    
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
            if (GameManager.THIS.actualNPC.name == "Vieja")
            {
                Debug.Log("Obtienes el billete");
                Inventario.THIS.objetos[4].SetActive(true);
                PlayerDataManager.THIS.checkpoints[12] = true;
                PlayerDataManager.THIS.checkpoints[checkpointNeeded] = false;
            }
            /*if (GameManager.THIS.actualNPC.name == "Niña")
            {
                GetComponent<NPCText>().StartNPCText(2);

            }*/
            /*if(GameManager.THIS.nombreNPC == "Fan")
            {
                GetComponent<NPCText>().StartNPCText(2);

            }*/

        }      
        else if (PlayerDataManager.THIS.checkpoints[ownCheckpoint])
        {
            GameManager.THIS.SetState(GameStates.NPC_Chat);
            GetComponent<NPCText>().StartNPCText(3);
        }
        else if (PlayerDataManager.THIS.checkpoints[checkpointNeeded])
        {
            GameManager.THIS.SetState(GameStates.NPC_Chat);
            GetComponent<NPCText>().StartNPCText(1);
            


            //PlayerDataManager.THIS.checkpoints[ownCheckpoint] = true;
        }
        else
        {
            GameManager.THIS.SetState(GameStates.NPC_Chat);
            GetComponent<NPCText>().StartNPCText(0);
            if (GameManager.THIS.actualNPC.name == "Fan")
            {

                PlayerDataManager.THIS.checkpoints[ownCheckpoint] = true;

            }
            if (GameManager.THIS.actualNPC.name == "Vieja")
            {

                PlayerDataManager.THIS.checkpoints[ownCheckpoint] = true;

            }

        }
        
        Gazpacho();
        ConjuntoCromo();
    }

    public void OnJeanPierreAction(int answer)
    {
        jeanPierreAction.SetActive(false);
        GameManager.THIS.SetState(GameStates.NPC_Chat);
        GetComponent<NPCText>().StartNPCText(answer);
        PlayerDataManager.THIS.checkpoints[ownCheckpoint] = true;     
    }
    public void Gazpacho()
    {
        if (GameManager.THIS.actualNPC.name == "Baity")
        {
            Inventario.THIS.objetos[5].SetActive(true);
            PlayerDataManager.THIS.checkpoints[checkpointNeeded] = true;
        }

            
    }
    public void ConjuntoCromo()
    {
        if ((GameManager.THIS.actualNPC.name == "Fan") && (PlayerDataManager.THIS.checkpoints[13] == true))
        {
            print("Es el fan");
            PlayerDataManager.THIS.checkpoints[ownCheckpoint] = true;
            ownCheckpoint = 18;
            PlayerDataManager.THIS.checkpoints[ownCheckpoint] = true;

        }

    }
    


   
}
