using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCText : MonoBehaviour
{

    public string[] actualText;
    public int[] actualTextouner;
    
    
    //faceProta = 0; faceNPC = 1
    public Image faceNPC;
    public Image faceProta;

    public int npcCheckpoints; //alamacena el owncheckpoint

    [SerializeField] GameObject dialogo;

    public Text phrase;

    public int currentPhrase;

    Coroutine typePhraseCoro;

    public float textFastSpeed;
    public float textSlowSpeed;

    public string[] text0;
    public string[] text1;
    public string[] text2;
    public string[] text3;
    public string[] text4;

    public int[] textouner0;
    public int[] textouner1;
    public int[] textouner2;
    public int[] textouner3;
    public int[] textouner4;




    private void Awake()
    {
        //inputActions.Player_Ball.JumpBola.started += ctx => OnClickContinue();
        
    }

    void Start()
    {
        //stfaces = new Sprite[2];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNPCText(int text)
    {
        
        switch (text)
        {
            case 0:
                actualText = text0;
                actualTextouner = textouner0;
                break;
            case 1:
                actualText = text1;
                actualTextouner = textouner1;
                break;
            case 2:
                actualText = text2;
                actualTextouner = textouner2;

                break;
            case 3:
                actualText = text3;
                actualTextouner = textouner3;
                break;
            case 4:
                actualText = text4;
                actualTextouner = textouner4;
                break;
            default:
                break;
        }

        dialogo.SetActive(true);  
        faceNPC.gameObject.SetActive(true);
        faceProta.gameObject.SetActive(true);
        typePhraseCoro = StartCoroutine(TypePhraseCoro());
        //SoundManager.THIS.PlaySound(15);
    }


    public void OnClickContinue()  
    {
        if (typePhraseCoro != null) AutoComplete_Npc_CurrentPhrase();
        else
        {
            faceNPC.gameObject.SetActive(false);
            //faceProta.gameObject.SetActive(true);

            currentPhrase++;
            if (currentPhrase < actualText.Length)
            {
                typePhraseCoro = StartCoroutine(TypePhraseCoro());
                //faces.sprite = stfaces[currentPhrase];
            }
            else
            {
                if (PlayerDataManager.THIS.checkpoints[1])
                {
                    dialogo.SetActive(false);
                    faceNPC.gameObject.SetActive(false);
                    GameManager.THIS.actualNPC = null;
                    GameManager.THIS.SetState(GameStates.Playing);
                    currentPhrase = 0;
                }
                else if(GameManager.THIS.actualNPC.GetComponent<NPCControl>().ownCheckpoint == 1)
                {
                    GetComponent<NPCControl>().jeanPierreAction.SetActive(true);
                    currentPhrase = 0;
                }                               
                else
                {
                    faceNPC.gameObject.SetActive(false);
                    //faceProta.gameObject.SetActive(false);

                    dialogo.SetActive(false);
                    GameManager.THIS.actualNPC = null;
                    GameManager.THIS.SetState(GameStates.Playing);
                    currentPhrase = 0;
                }
                if ((GameManager.THIS.nombreNPC == "Niña") && (currentPhrase == 0) && (actualText == text2))
                {

                    GameObject.Find("Inventario").transform.GetChild(0).gameObject.SetActive(true);
                    GameManager.THIS.SetState(GameStates.Inventario_Chat);


                }
                if ((GameManager.THIS.nombreNPC == "Fan") && (currentPhrase == 0) && (actualText == text2))
                {

                    GameObject.Find("Inventario").transform.GetChild(0).gameObject.SetActive(true);
                    GameManager.THIS.SetState(GameStates.Inventario_Chat);


                }

            }
        }
    }

    IEnumerator TypePhraseCoro()
    {
        //faceProta = 0; faceNPC = 1
        if (actualTextouner[currentPhrase] == 0) 
        {
            faceProta.gameObject.SetActive(true);
            faceNPC.gameObject.SetActive(false);

        }
        if (actualTextouner[currentPhrase] == 1)
        {
            faceProta.gameObject.SetActive(false);
            faceNPC.gameObject.SetActive(true);

        }

        phrase.text = string.Empty; // el texto con la frase del npc comienza vacio 
        foreach (char currentCharacterOfCurrentPhrase in actualText[currentPhrase].ToCharArray())
        {
            phrase.text += currentCharacterOfCurrentPhrase;

            yield return new WaitForSeconds(textFastSpeed);
        }
            //npcCheckpoints = GetComponent<NPCControl>().ownCheckpoint;
           //PlayerDataManager.THIS.checkpoints[npcCheckpoints] = true;
        Stop_Npc_LineChat();
    }

    void Stop_Npc_LineChat()
    {
        if (typePhraseCoro != null)
        {
            StopCoroutine(typePhraseCoro);
            typePhraseCoro = null;
            
        }
    }

    void AutoComplete_Npc_CurrentPhrase()
    {

        // PASOS
        // PASO 1) Paro el subproceso de ir completando character a character la oracion actual segun el valor de la variable 'currentPhrase'
        Stop_Npc_LineChat();

        // PASO 2) el texto donde estaba completando la oracion actual se limpia de texto previo
        phrase.text = string.Empty; // el texto con la frase del npc comienza vacio

        // PASO 3) se asigna al texto la frase actual
        phrase.text = actualText[currentPhrase].ToString();
    }

    


}
