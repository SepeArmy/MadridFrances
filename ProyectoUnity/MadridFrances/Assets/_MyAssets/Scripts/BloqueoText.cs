using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class BloqueoText : MonoBehaviour
{
    public string[] languageText;

    [SerializeField] GameObject dialogo;

    [SerializeField] Text phrase;

    [SerializeField] int currentPhrase;

    Coroutine typePhraseCoro;

    [SerializeField] float textFastSpeed;
    [SerializeField] float textSlowSpeed;

    [SerializeField] float direccion; // 1f -> derecha, -1f -> izquierda
    
    [SerializeField] float distancia;
    [SerializeField] float tiempodebloqueo;

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

    public void StartObjectText(int text)
    {
        currentPhrase = 0;
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
        print("hola");
        dialogo.SetActive(true);
        typePhraseCoro = StartCoroutine(TypePhraseCoro());
        //SoundManager.THIS.PlaySound(15);
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
            else if(GameManager.THIS.state == GameStates.Blocking)
            {
                if (dialogo.activeSelf)
                {
                    print("Caminar hacia atrás");
                    dialogo.SetActive(false);
                    currentPhrase = 0;
                    //direccion = -1f;
                    //transform.right = Vector3.right * direccion;
                    //GameObject.Find("Player").transform.Translate(Vector3.right * velocidad * direccion * distancia * Time.deltaTime, Space.World);
                    //GameManager.THIS.SetState(GameStates.Playing);
                    StartCoroutine(Caminar_Atrás_Coro());
                    //if (distancia == 10) GameMana.THIS.SetState(GameStates.Playing);
                }

            }
            else
            {
                print("eyyyyyyyy");
                dialogo.SetActive(false);              
                GameManager.THIS.SetState(GameStates.Playing);
                currentPhrase = 0;
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
    /*IEnumerator Caminar_Atrás_Coro()
    {
        Transform player = GameObject.Find("Player").transform;
        player.GetComponent<NavMeshAgent>().isStopped= true;
        player.GetComponent<NavMeshAgent>().ResetPath();

        while (distancia < 10f)
        {
            player.Translate(Vector3.right * velocidad * direccion  * Time.deltaTime, Space.World);
            distancia += velocidad * Time.deltaTime; //distancia que recorres cada frame
            yield return new WaitForSeconds(0);
        }
        GameManager.THIS.SetState(GameStates.Playing);
        player.GetComponent<NavMeshAgent>().isStopped = false;

        
        distancia = 0f;
        StopCoroutine(Caminar_Atrás_Coro());
        

    }*/
    IEnumerator Caminar_Atrás_Coro()
    {
        
      


        NavMeshAgent playerAgent = GameObject.Find("Player").GetComponent<NavMeshAgent>();
        Transform playerTr = GameObject.Find("Player").transform;
        playerAgent.SetDestination(playerTr.position + Vector3.right * direccion * distancia);

        yield return new WaitForSeconds(tiempodebloqueo);
        GameManager.THIS.SetState(GameStates.Playing);
          
        StopCoroutine(Caminar_Atrás_Coro());
        

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
