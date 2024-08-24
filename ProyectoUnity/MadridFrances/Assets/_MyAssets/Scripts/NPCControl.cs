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
            if (GameManager.THIS.nombreNPC == "Niña")
            {
                Inventario.THIS.objetos[1].SetActive(false);
                //ir a la variable "objeto cogible" de la pelota y activarlo
                objectos = GameObject.Find("Pelota");
                objectos.GetComponent<Object>().objectoCogible = true;

            }

        }      
        else if (PlayerDataManager.THIS.checkpoints[checkpointNeeded])
        {
            GameManager.THIS.SetState(GameStates.NPC_Chat);
            GetComponent<NPCText>().StartNPCText(1);
            
            if(GameManager.THIS.nombreNPC == "Fan")
            {
                //print("Dar bigote");
                Inventario.THIS.objetos[2].SetActive(false);

            }
            PlayerDataManager.THIS.checkpoints[ownCheckpoint] = true;
        }
        else
        {
            GameManager.THIS.SetState(GameStates.NPC_Chat);
            GetComponent<NPCText>().StartNPCText(0);
        }
        ticket();
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
        if (GameManager.THIS.nombreNPC == "Baity")
        {
            Inventario.THIS.objetos[5].SetActive(true);
        }

            
    }
    public void ConjuntoCromo()
    {
        if (GameManager.THIS.nombreNPC == "Fan")
        {
            //print("Es el fan");
            PlayerDataManager.THIS.checkpoints[ownCheckpoint] = true;
        }
       
    }
    public void ticket()
    {
        if(GameManager.THIS.nombreNPC == "Vieja")
        {
            if ((PlayerDataManager.THIS.checkpoints[ownCheckpoint] == true) && (PlayerDataManager.THIS.checkpoints[checkpointNeeded] == true))
            {
                Debug.Log("Obtienes el billete");
                Inventario.THIS.objetos[4].SetActive(true);
                PlayerDataManager.THIS.checkpoints[12] = true;
            }
        }
        
    }


   
}
