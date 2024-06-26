using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimGato : MonoBehaviour
{
    bool animado;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !animado && PlayerDataManager.THIS.checkpoints[1])
        {
            GameObject.FindGameObjectWithTag("Gato").GetComponent<GatoController>().run = true;
        }
    }
}
