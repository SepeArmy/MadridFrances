using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class I18nManager : MonoBehaviour
{

    public static I18nManager THIS;

    public string language;

    
    private void Awake()
    {
        THIS = this;
    }

    void Start()
    {
        SelectLanguageOnStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectLanguageOnStart()
    {
        //Lo primero que hago es comprobar si se ha guardado un idioma en la PlayerPrefs
        if (PlayerPrefs.HasKey("language"))
        {
            language = PlayerPrefs.GetString("language");
        }
        //Si no, y tampoco se ha especificado uno previamente, pongo el espa�ol
        else 
        {
            language = "es";
            //Lo guardo en las preferencias
            PlayerPrefs.SetString("language", "es");
        }
    }

    public string[] textosMainMenu_es =
     {
        "Comenzar",
        "Ajustes",
        "Galer�a",
        "Cr�ditos",
        "Salir",
        "AJUSTES",
        "M�sica" + "\n" + "\n" + "Volumen" + "\n" + "\n" + "Idioma",
        "Espa�ol" + "\n" + "\n" + "English",
        "Cr�ditos",
        "ARTE",
        "BOCETOS",
        "TR�ILER"
    };

    public string[] textosGameplay_es =
     {
        "MISI�N",
        "Sal de la cueva",
        "PAUSA",
        "Continuar",
        "Ajustes",
        "Reiniciar",
        "Salir",
        "AJUSTES",
        "M�sica" + "\n" + "\n" + "Volumen General" + "\n" + "\n" + "Idioma",
        "Espa�ol" + "\n" + "\n" + "English",
        "Para saltar, pulsa 'RB' o 'A'." + "\n" + "Puedes encadenar saltos para saltar m�s alto." + "\n" + "Usa el joystick izquierdo para desplazarte mientras saltas." + "\n" + "El joystick derecho sirve para mover la c�mara.",
        "Para 'Amurcar', pulsa 'LB' mientras saltas.",
        "Si ves un enemigo, puedes fijarle como objetivo presionando 'RS'" + "\n" + "as� te ser� m�s f�cil deshacerte de �l."


    };

    public string[] textosMainMenu_en =
    {
        "Start",
        "Settings",
        "Gallery",
        "Credits",
        "Quit",
        "SETTINGS",
        "Music" + "\n" + "\n" + "Volume" + "\n" + "\n" + "Language",
        "Espa�ol" + "\n" + "\n" + "English",
        "Credits",
        "ART",
        "SKETCHES",
        "TRAILER"
    };

    public string[] textosGameplay_en =
    {
        "TASK",
        "Get out of the cave",
        "PAUSE",
        "Resume",
        "Settings",
        "Restart",
        "Exit",
        "SETTINGS",
        "Music" + "\n" + "\n" + "Master Volume  " + "\n" + "\n" + "Language",
        "Espa�ol" + "\n" + "\n" + "English",
        "To jump, use 'RB' or 'A'." + "\n" + " You can chain jumps to jump higher. " + "\n" + "Use the left joystick to move while jumping." + "\n" + "The right joystick is used to move the camera.",
        "To 'Amurcar', press 'LB' while jumping.",
        "If you see an enemy, you can target it by pressing 'RS'" + "\n" + "so it will be easier for you to get rid of it."
    };

    public string[] textosMariposa_es =
     {
        "�Ey!",
        "�Eeey!",
        "S�, t�, despierta.",
        "Vaya, ya has vuelto en t�, me estaba empezando a preocupar.",
        "No parece que seas de por aqu�, as� que dejame darte la bienvenida a... �Magland!",
        ".   .   .   .   .",
        "No pareces muy hablador, �de d�nde has salido?",
        ".   .   .   .   .",
        "No, definitivamente no lo eres. Bueno, supongo que ya lo descubriremos",
        "Pero para eso, primero tendr�s que salir de esta cueva, �no crees?", 
        "Vamos, no pierdas m�s tiempo. �A saltar!", 

    };

    public string[] textosMariposa_en =
     {
        "Hey!",
        "Heeey!",
        "Yes, you, wake up.",
        "Wow, you've come to your senses, I was getting worried",
        "You don't look like you're from around here, so let me welcome you to... Magland!",
        ".   .   .   .   .",
        "You don't seem very talkative, where did you come from?",
        ".   .   .   .   .",
        "No, you're definitely not. Well, I guess we'll find out.",
        "But for that you'll have to get out of this cave first, don't you think?",
        "Come on, don't waste more time, let's jump!",
    };

    public string[] textosBosque_es =
    {
        "�Hola!",
        "Somos los desarrolladores de Arko, gracias por jugar la versi�n DEMO.",
        "Todo lo que ver�s a continuaci�n est� en fase de desarrollo",
        "(Una buena excusa para decirte que vas a encontrar 'bugs' por todas partes)",
        "Si sigues por el camino que tienes justo enfrente, te encontrar�s unos portales",
        "Solo sirven para ir de un lugar a otro mucho m�s r�pido, pero molan mogoll�n",
        "�Divi�rtete explorando este fant�stico mundo junto a Arko!",
    };

    public string[] textosBosque_en =
    {
        "Hello!",
        "We are the developers of Arko, thank you for playing the Demo.",
        "Everything you will see below is in the development phase.",
        "(A good excuse to tell you that you're going to find 'bugs' everywhere)",
        "If you follow the path right in front of you, you will find some portals.",
        "They're just to get from one place to another much faster, but they're really cool",
        "Have fun exploring this fantastic world together with Arko!",
    };

    public string[] textosRocaFinal_es =
    {
        "Wow",
        "�Has llegado verdaderamente lejos!",
        "Disfruta de las vistas :)",
    };

    public string[] textosRocaFinal_en =
    {
        "Wow",
        "You have really come a long way!",
        "Enjoy the views :)",
    };
}
