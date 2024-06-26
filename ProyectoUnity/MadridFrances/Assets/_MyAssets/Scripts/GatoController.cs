using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatoController : MonoBehaviour
{
    [SerializeField] float speed;
    public bool run;
    bool instanciado;

    [SerializeField] Rigidbody macarons;
    void Start()
    {
        
    }

    void Update()
    {
        if (run)
        {
            if (!instanciado)
            {
                macarons = GameObject.Find("Macarons").GetComponent<Rigidbody>();
                Invoke("InstantiateMacarons", 0.4f);
                instanciado = true;
            }
            RunAway();
            
        }
        
    }

    void RunAway()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        
    }

    void InstantiateMacarons()
    {
        macarons.gameObject.transform.position = transform.position;
        macarons.gameObject.SetActive(true);
        macarons.AddForce(new Vector3(-1f, 1f, 0f) * 8);
    }
        
    
}
