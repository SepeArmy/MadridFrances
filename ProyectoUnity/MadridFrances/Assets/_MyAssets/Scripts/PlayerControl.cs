using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerControl : MonoBehaviour
{

    NavMeshAgent agent;
    Animator anim;

    [SerializeField] Text mouseText;
    [SerializeField] GameObject objectOptions;
    [SerializeField] GameObject objectOptions2;
    [SerializeField] GameObject soltarMacarons;
    [SerializeField] GameObject tirarPelota;
    [SerializeField] GameObject inventario;
    [SerializeField] GameObject bigote;
    [SerializeField] GameObject background;
    [SerializeField] GameObject HUD;

    [SerializeField] Texture2D arrowTexture;
    [SerializeField] Texture2D cursorTexture;

    [SerializeField] Rigidbody macaronsFinal;
    [SerializeField] Rigidbody pelotaFinal;

    public GameObject bloqueo_Actual;

    public Transform objectSelected;
    public string nombreObjeto;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MouseRaycast();

        if (Input.GetMouseButtonDown(0))
        {
            ClickInput();              
        }

        Animations();
        
    }

    void ClickInput()
    {
        if (GameManager.THIS.state == GameStates.Playing)
        {
            ClickRaycast();
        }
        else if (GameManager.THIS.state == GameStates.NPC_Chat)
        {
            GameManager.THIS.actualNPC.GetComponent<NPCText>().OnClickContinue();
        }
        else if (GameManager.THIS.state == GameStates.ObjectChat)
        {
            objectSelected.GetComponent<ObjectText>().OnClickContinue();
        }
        else if (GameManager.THIS.state == GameStates.Blocking)
        {
            
            bloqueo_Actual.GetComponent<BloqueoText>().OnClickContinue();

        }
    }

    void MouseRaycast()
    {
        //Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
        mouseText.gameObject.SetActive(false);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 15) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            if (hit.transform.CompareTag("NPC") && GameManager.THIS.state == GameStates.Playing)
            {
                if (PlayerDataManager.THIS.checkpoints[hit.transform.GetComponentInParent<NPCControl>().ownCheckpoint])
                {
                    mouseText.text = hit.transform.GetComponentInParent<NPCControl>().npcName;
                }
                else
                {
                    mouseText.text = hit.transform.GetComponentInParent<NPCControl>().npcNickname;
                }
                mouseText.gameObject.SetActive(true);
                mouseText.transform.position = Input.mousePosition + Vector3.right * 70;
            }

            else if (hit.transform.CompareTag("Object"))
            {
                mouseText.text = hit.transform.GetComponentInParent<Object>().objectName;
                mouseText.gameObject.SetActive(true);
                mouseText.transform.position = Input.mousePosition + Vector3.right * 70;
            }
            else if (hit.transform.CompareTag("ChangeScene") && PlayerDataManager.THIS.checkpoints[4])
            {
                UnityEngine.Cursor.SetCursor(arrowTexture, Vector2.zero, CursorMode.ForceSoftware);
            }
            else if (hit.transform.CompareTag("Palomas"))
            {
                mouseText.text = "PALOMAS";
                mouseText.gameObject.SetActive(true);
                mouseText.transform.position = Input.mousePosition + Vector3.right * 70;
            }
            else if (hit.transform.CompareTag("Pinceles"))
            {
                mouseText.text = hit.transform.GetComponentInParent<Object>().objectName;
                mouseText.gameObject.SetActive(true);
                mouseText.transform.position = Input.mousePosition + Vector3.right * 70;
            }

        }
    }

    void ClickRaycast()
    {
         
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 200) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        { 
            if (hit.transform.CompareTag("Floor")) //movimiento
            {
                ClickFloor(hit.point);
            }
        }

        if (Physics.Raycast(ray, out hit, 15) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            if (agent.velocity == Vector3.zero)
            {
                if (hit.transform.CompareTag("NPC"))
                {
                    ClickNPC(hit.transform);
                }
                if (hit.transform.CompareTag("Object"))
                {
                    ClickObject(hit.transform);
                }
                if (hit.transform.CompareTag("Pinceles"))
                {
                    ClickPinceles(hit.transform);
                }

            }

            if (hit.transform.CompareTag("ChangeScene") && PlayerDataManager.THIS.checkpoints[4])
            {
                hit.transform.GetComponent<ChangeScene>().GoToScene();
            }

            else if (hit.transform.CompareTag("Palomas") && PlayerDataManager.THIS.checkpoints[2])
            {
                GameManager.THIS.SetState(GameStates.ObjectOptions);
                soltarMacarons.transform.position = Input.mousePosition;
                soltarMacarons.SetActive(true);
                
            }
            else if (hit.transform.CompareTag("Pinceles") && PlayerDataManager.THIS.checkpoints[6])
            {
                GameManager.THIS.SetState(GameStates.ObjectOptions);
                tirarPelota.transform.position = Input.mousePosition;
                tirarPelota.SetActive(true);
            }
        }

    }

    void ClickFloor(Vector3 targetPoint)
    {

        agent.SetDestination(targetPoint);

    }

    void ClickNPC(Transform npc)
    {
        GameManager.THIS.actualNPC = npc.parent;//coge el npc
        GameManager.THIS.nombreNPC = npc.name;
        //print(npc.name);
        GameManager.THIS.actualNPC.GetComponent<NPCControl>().NPCAction();
        
    }

    void ClickObject(Transform _object)
    {
        
        objectSelected = _object;
        nombreObjeto = _object.name;      
        GameManager.THIS.SetState(GameStates.ObjectOptions);
        objectOptions.transform.position = Input.mousePosition;
        objectOptions2.transform.position = Input.mousePosition;

        if (objectSelected.GetComponent<Object>().objectoCogible)
        {
                objectOptions.SetActive(true);
        }
          else
          {
                objectOptions2.SetActive(true);
          }
        
        
    }
    void ClickPinceles(Transform _pinceles)
    {
        if (PlayerDataManager.THIS.checkpoints[6])
        {
           print ("Tirar pelota");
        }
        else
        {
            objectSelected = _pinceles;
            GameManager.THIS.SetState(GameStates.ObjectOptions);
            objectOptions2.transform.position = Input.mousePosition;
            if (objectSelected.GetComponent<Object>().objectoCogible)
            {
                objectOptions.SetActive(true);
            }
            else
            {
                objectOptions2.SetActive(true);
            }
            //print("Te habla Antonio");
        }

    }

    public void OnClickVer()
    {
        objectSelected.GetComponent<ObjectText>().StartObjectText(0);
        GameManager.THIS.SetState(GameStates.ObjectChat);
        objectOptions.SetActive(false);
        objectOptions2.SetActive(false);

    }

    public void OnClickCoger()
    {
        objectSelected.GetComponent<ObjectText>().StartObjectText(1);
        GameManager.THIS.SetState(GameStates.ObjectChat);
        objectOptions.SetActive(false);
        
        if (objectSelected.GetComponent<Object>().objectoCogible)
        {
            inventario.GetComponent<Inventario>().objetos[objectSelected.GetComponent<Object>().objectID].SetActive(true);
            objectSelected.GetChild(0).gameObject.SetActive(false);
            if (objectSelected.GetComponent<Object>().objectID == 0)
            {
                PlayerDataManager.THIS.checkpoints[2] = true;

            }
            PlayerDataManager.THIS.checkpoints[objectSelected.GetComponent<Object>().owncheckpoint] = true;
            objectSelected.GetComponent<BoxCollider>().enabled = false;
        }
        if (nombreObjeto == "BIGOTE DE ANTUAN")
        {
            PlayerDataManager.THIS.checkpoints[17] = true;
            

        }
    }
    public void onClickNoCogerPelota()
    { 
        print("No puedes coger la pelota aun");
        objectSelected.GetComponent<ObjectText>().StartObjectText(2);
        GameManager.THIS.SetState(GameStates.ObjectChat);      
        objectOptions2.SetActive(false);
    }

    public void OnClickFuera()
    {
        objectOptions.SetActive(false);
        soltarMacarons.SetActive(false);
        GameManager.THIS.SetState(GameStates.Playing);
    }

    public void OnClickSoltarMacarons(Transform palomas)
    {
        soltarMacarons.SetActive(false);
        GameManager.THIS.SetState(GameStates.Playing);
        Rigidbody clone = Instantiate(macaronsFinal, transform.position + Vector3.up * 2, transform.rotation);
        clone.AddForce((palomas.position - transform.position) * 100);
        inventario.GetComponent<Inventario>().objetos[0].SetActive(false);
        //objectSelected.GetChild(0).gameObject.SetActive(false);
        PlayerDataManager.THIS.checkpoints[2] = false;
        PlayerDataManager.THIS.checkpoints[3] = true;



    }
    public void OnCliclTirarPelota(Transform pinceles)
    {
        tirarPelota.SetActive(false);
        GameManager.THIS.SetState(GameStates.Playing);
        Rigidbody clone = Instantiate(pelotaFinal, transform.position + Vector3.up * 2, transform.rotation);
        clone.AddForce((pinceles.position - transform.position) * 100);
        inventario.GetComponent<Inventario>().objetos[3].SetActive(false);
        PlayerDataManager.THIS.checkpoints[6] = false;
        PlayerDataManager.THIS.checkpoints[16] = true;
        //Destroy(clone.gameObject, 3f);
        SpawnBigote();

    }
     public void SpawnBigote()
    {
        if (PlayerDataManager.THIS.checkpoints[16])
        {
            //hacer que antonio haga la animación de agacharse y recoger los pinceles
            print("Aparece bigote");
            bigote.SetActive(true);
            

        }
    }
    

    public void OnClickInventario()
    {
        if(GameManager.THIS.state == GameStates.Playing)
        {
            //inventario.SetActive(true);
            background.SetActive(true);
            HUD.SetActive(false);
            GameManager.THIS.SetState(GameStates.Inventory);
        }

    }

    public void OnClickBack()
    {
        //inventario.SetActive(false);
        background.SetActive(false);
        HUD.SetActive(true);
        GameManager.THIS.SetState(GameStates.Playing);
    }

    void Animations()
    {
        if(agent.velocity == Vector3.zero)
        {
            anim.SetBool("walking", false);
        }
        else
        {
            anim.SetBool("walking", true);
        }

        if (agent.velocity.x > 0) transform.GetChild(0).transform.localScale = new Vector3(-1,1,1);
        if (agent.velocity.x < 0) transform.GetChild(0).transform.localScale = new Vector3(1, 1, 1);


    }
}