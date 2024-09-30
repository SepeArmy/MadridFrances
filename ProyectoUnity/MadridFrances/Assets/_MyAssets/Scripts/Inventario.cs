using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;
//using UnityEngine.EventSystems;

public class Inventario : MonoBehaviour
{
    public static Inventario THIS;
    public GameObject[] objetos;
    GameObject pelota;


    private void Awake()
    {
        THIS = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            ClickInput();
        }*/
    }

   /* public void clickenInventario()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 15) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            print("eyyyyy");

            if (hit.transform.CompareTag("Cromo"))
            {
                objetos[1].SetActive(false);
                pelota =GameObject.Find("Pelota");
                pelota.GetComponent<Object>().objectoCogible = true;

                GameManager.THIS.SetState(GameStates.NPC_Chat);
                GameObject.Find("Niña").GetComponent<NPCText>().StartNPCText(4);
                transform.GetChild(0).gameObject.SetActive(false);

            }

        }
        
    }*/
    public void clickenCromo()
    {
        Transform actualNPC;

       if (GameManager.THIS.state == GameStates.Inventario_Chat)
       {
            objetos[1].SetActive(false);
            pelota = GameObject.Find("Pelota");
            pelota.GetComponent<Object>().objectoCogible = true;
            actualNPC = GameObject.Find("Niña").transform;
            GameManager.THIS.actualNPC = actualNPC;      
            GameManager.THIS.SetState(GameStates.NPC_Chat);      
            GameObject.Find("Niña").GetComponent<NPCText>().StartNPCText(4);
            PlayerDataManager.THIS.checkpoints[18] = true;
            PlayerDataManager.THIS.checkpoints[5] = false;
            transform.GetChild(0).gameObject.SetActive(false);


       }

    }
    public void clickenBigote()
    {
        Transform actualNPC;

        if (GameManager.THIS.state == GameStates.Inventario_Chat)
        {
            objetos[2].SetActive(false);                       
            actualNPC = GameObject.Find("Fan").transform;
            GameManager.THIS.actualNPC = actualNPC;

            GameManager.THIS.SetState(GameStates.NPC_Chat);


            GameObject fan = GameObject.Find("Fan");
            print(fan);
            Component[] allComponents = fan.GetComponents<Component>();

            // Iteramos sobre todos los componentes y los mostramos en consola
            foreach (Component comp in allComponents)
            {
                Debug.Log(comp.GetType().Name); // Muestra el tipo de componente en consola
            }
            NPCText texto = fan.GetComponent<NPCText>();
            print(texto);
            
            GameObject.Find("Fan").GetComponent<NPCText>().StartNPCText(4);
            transform.GetChild(0).gameObject.SetActive(false);
        }

    }


    /*void ClickInput()
    {
        if (GameManager.THIS.state == GameStates.Inventario_Chat)
        {
            clickenInventario();
        }
    }*/
}
