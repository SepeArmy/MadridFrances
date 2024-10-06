using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerDataManager : MonoBehaviour
{
    public static PlayerDataManager THIS;

    public bool[] checkpoints;
    /*
    checkpoint_empezarJuego         = 0;
    checkpoint_hablarJampiere       = 1;
    checkpoint_cogerMacaronsJamon   = 2;
    checkpoint_tirarMacaronsJamon   = 3;
    checkpoint_hablarVieja          = 4;
    checkpoint_cogerCromoCR7PSG     = 5;------
    checkpoint_cogerpelota          = 6;        
    checkpoint_hablarNinaBorde      = 7;
    checkpoint_robarAntonio         = 8;
    checkpoint_darBigoteFanAntonio  = 9;
    ckeckpoint_hablarAntonio        = 10;
    checkpoint_hablarAndaluz        = 11;
    checkpoint_billete              = 12;
    checkpoint_HablarFan            = 13;
    checkpoint_Niña                 = 14;
    checkpoint_TirarPelota          = 15;
    checkpoint_bigote               = 16;
    checkpoint_cogerBigote          = 17;
    checkpoint_despuesFan           = 18;
    



    */


    private void Awake()
    {
        THIS = this;
    }

    private void Start()
    {
       checkpoints[0] = true;
    }
    /*
    public void InicializarData()
    {
        checkpoints[0] = true;
        checkpoints[1] = false;
        checkpoints[2] = false;
        checkpoints[3] = false;
        checkpoints[4] = false;
        checkpoints[5] = false;
        checkpoints[6] = false;

    }
    */

}