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
    checkpoint_cogerCromoCR7PSG     = 5;
    checkpoint_hablarFanAntonio     = 6;
    checkpoint_hablarNinaBorde      = 7;
    checkpoint_robarAntonio         = 8;
    checkpoint_darBigoteFanAntonio  = 9;
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