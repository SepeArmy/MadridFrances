using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Bloqueos : MonoBehaviour
{
    public bool ID_1;
    public bool ID_2;
    public GameObject opcionesbloqueo2;
    public GameObject negroFake;
    public Transform tp_Target;
    public int transition_Time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        collider.GetComponent<PlayerControl>().bloqueo_Actual = gameObject;

        if(ID_1 == true)
        {
            print("Puedo pasar?");
            GameManager.THIS.SetState(GameStates.Blocking);
            print("comprobando checkpoint");
            if (PlayerDataManager.THIS.checkpoints[2] == true)
            {
                print("puedes pasar");
                GameManager.THIS.SetState(GameStates.Playing);

            }
            else
            {
                gameObject.GetComponent<BloqueoText>().StartObjectText(0);
            }
        }
        else if (ID_2 == true) 
        {

            print("Puedo pasar");
            GameManager.THIS.SetState(GameStates.Blocking);
            print("comprobando ticket"); //checkpoint 12
            //si tienes el ticket: preguntar por viajar
            //si no tienes el ticket: no puedes viajar
            if (PlayerDataManager.THIS.checkpoints[12] == true) 
            {
                //GameManager.THIS.SetState(GameStates.Fake_Transition);

                print("quieres viajar?");
                opcionesbloqueo2.SetActive(true);


            }
            else
            {
                gameObject.GetComponent<BloqueoText>().StartObjectText(0);

            }

        }
    }

    /*public void opcionesdebloqueo(int answer)
    {
        opcionesbloqueo2.SetActive(false);
        //GameManager.THIS.SetState(GameStates.NPC_Chat);
        GetComponent<BloqueoText>().StartObjectText(answer);
        //PlayerDataManager.THIS.checkpoints[ownCheckpoint] = true;
    }*/

    public void  SIviajar()
    { 
       print("Viajas");
       opcionesbloqueo2.SetActive(false);
        //GameManager.THIS.SetState(GameStates.Fake_Transition);
        StartCoroutine(Transición_Fake());



    }
    public void  NOviajar()
    {
        gameObject.GetComponent<BloqueoText>().StartObjectText(1);
        opcionesbloqueo2.SetActive(false);
        //GameManager.THIS.SetState(GameStates.Playing);




    }

    IEnumerator Transición_Fake()
    {
        Transform player_Position;        
        player_Position = GameObject.Find("Player").GetComponent<Transform>();        
        //-------------------------------
        negroFake.SetActive(true);
        yield return new WaitForSeconds(1f);


        NavMeshAgent playerAgent = GameObject.Find("Player").GetComponent<NavMeshAgent>();
        Transform playerTr = GameObject.Find("Player").transform;
        playerAgent.SetDestination(tp_Target.position);


        player_Position.position = tp_Target.position;       
        GameManager.THIS.SetState(GameStates.Playing);
        yield return new WaitForSeconds(transition_Time);
        negroFake.SetActive(false);
    }
}



