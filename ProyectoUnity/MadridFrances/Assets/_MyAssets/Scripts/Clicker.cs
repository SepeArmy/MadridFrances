using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class Clicker : MonoBehaviour
{
    [SerializeField] float dificulty;
    [SerializeField] Sprite mouseLeft;
    [SerializeField] Sprite mouseRight;
    [SerializeField] SpriteRenderer mouse;
    [SerializeField] Texture2D cursorTexture;

    public TextMeshProUGUI cuenta;
    float time = 3;
    public bool cuentaAtras;
    public bool start;





    bool isMouseRight;

    void Start()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.ForceSoftware);
        StartCoroutine(CuentaAtras_Coro());

    }

    // Update is called once per frame
    void Update()
    {
        if (start == true)
        {
            transform.Translate(Vector3.up * dificulty * Time.deltaTime);

            if (Input.GetMouseButtonDown(0) && !isMouseRight)
            {
                transform.Translate(Vector3.down * 0.2f);
            }

            if (Input.GetMouseButtonDown(1) && isMouseRight)
            {
                transform.Translate(Vector3.down * 0.2f);
            }


            if (transform.position.x > 7.8f)
            {
                GameManager.THIS.win = true;
                SceneManager.LoadScene(4);
            }
            if (transform.position.x < -3f)
            {
                GameManager.THIS.win = false;
                SceneManager.LoadScene(4);
            }
        }
        
    }

    IEnumerator ChangeMouseButton() 
    {
        while (true)
        {
            if (isMouseRight)
            {
                isMouseRight = false;
                mouse.sprite = mouseLeft;
            }
            else
            {
                isMouseRight = true;
                mouse.sprite = mouseRight;
            }
            yield return new WaitForSeconds(Random.Range(1,4));
        }    
    }
    IEnumerator CuentaAtras_Coro()
    {
        //Si llegas a leer esto, no me juzgues, querría meter el cartelito
        //y no sabía como.
        cuenta.gameObject.SetActive(true);
        cuenta.text = 3.ToString();
        yield return new WaitForSeconds(1);
        cuenta.text = 2.ToString();
        yield return new WaitForSeconds(1);
        cuenta.text = 1.ToString();
        yield return new WaitForSeconds(1);



        cuenta.gameObject.SetActive(false);

        StopCoroutine(CuentaAtras_Coro());
        start = true;
        StartCoroutine(ChangeMouseButton());
       
    }
}
