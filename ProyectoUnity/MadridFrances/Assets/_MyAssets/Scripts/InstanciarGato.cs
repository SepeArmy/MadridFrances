using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarGato : MonoBehaviour
{
    [SerializeField] GameObject gato;
    [SerializeField] Transform instanciador;
    bool instanciado;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !instanciado && PlayerDataManager.THIS.checkpoints[1])
        {
            Instantiate(gato, instanciador.position, instanciador.rotation);
            instanciado = true;
        }
    }
}
