using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacaronsFinal : MonoBehaviour
{
    bool start;
    GameObject vieja;
    void Start()
    {
        vieja = GameObject.Find("Vieja");
        Invoke("GoToVieja", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            print((vieja.transform.position - transform.position).normalized);
            transform.Translate(((vieja.transform.position - transform.position).normalized) * 10 * Time.deltaTime, Space.World);
        }
        if (Vector3.Distance(vieja.transform.position, transform.position) < 1) Destroy(gameObject);
    }

    void GoToVieja()
    {
        start = true;
    }
}
