using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCText : MonoBehaviour
{

    public string[] languageText;

    [SerializeField] GameObject dialogo;

    public Text phrase;

    public int currentPhrase;

    Coroutine typePhraseCoro;

    public float textFastSpeed;
    public float textSlowSpeed;

    private void Awake()
    { 
        //inputActions.Player_Ball.JumpBola.started += ctx => OnClickContinue();
    }

    void Start()
    {
            
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
                languageText = text0;
                break;
            case 1:
                languageText = text1;
                break;
            case 2:
                languageText = text2;
                break;
            case 3:
                languageText = text3;
                break;
            case 4:
                languageText = text4;
                break;

            default:
                break;
        }

        dialogo.SetActive(true);  
        typePhraseCoro = StartCoroutine(TypePhraseCoro());
        SoundManager.THIS.PlaySound(15);
    }


    public void OnClickContinue()  
    {
        if (typePhraseCoro != null) AutoComplete_Npc_CurrentPhrase();
        else
        {
            currentPhrase++;
            if (currentPhrase < languageText.Length)
            {
                typePhraseCoro = StartCoroutine(TypePhraseCoro());
            }
            else
            {
                if (PlayerDataManager.THIS.checkpoints[1])
                {
                    dialogo.SetActive(false);
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
                    dialogo.SetActive(false);
                    GameManager.THIS.actualNPC = null;
                    GameManager.THIS.SetState(GameStates.Playing);
                    currentPhrase = 0;
                }
               
            }
        }
    }

    IEnumerator TypePhraseCoro()
    {
        phrase.text = string.Empty; // el texto con la frase del npc comienza vacio 
        foreach (char currentCharacterOfCurrentPhrase in languageText[currentPhrase].ToCharArray())
        {
            phrase.text += currentCharacterOfCurrentPhrase;

            yield return new WaitForSeconds(textFastSpeed);
        }

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
        phrase.text = languageText[currentPhrase].ToString();
    }

    public string[] text0 =
    {
        "¡Ey!",
        "¡Eeey!",
        "Sí, tú, despierta.",
        "Vaya, ya has vuelto en tí, me estaba empezando a preocupar.",
    };

    public string[] text1 =
    {
        "¡Ey!",
        "¡Eeey!",
        "Sí, tú, despierta.",
        "Vaya, ya has vuelto en tí, me estaba empezando a preocupar.",
    };

    public string[] text2 =
    {
        "¡Ey!",
        "¡Eeey!",
        "Sí, tú, despierta.",
        "Vaya, ya has vuelto en tí, me estaba empezando a preocupar.",
    };

    public string[] text3 =
    {
        "¡Ey!",
        "¡Eeey!",
        "Sí, tú, despierta.",
        "Vaya, ya has vuelto en tí, me estaba empezando a preocupar.",
    };

    public string[] text4 =
    {
        "¡Ey!",
        "¡Eeey!",
        "Sí, tú, despierta.",
        "Vaya, ya has vuelto en tí, me estaba empezando a preocupar.",
    };
}
