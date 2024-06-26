using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Clicker : MonoBehaviour
{
    [SerializeField] float dificulty;
    [SerializeField] Sprite mouseLeft;
    [SerializeField] Sprite mouseRight;
    [SerializeField] SpriteRenderer mouse;
    [SerializeField] Texture2D cursorTexture;

    bool isMouseRight;

    void Start()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.ForceSoftware);    
        StartCoroutine(ChangeMouseButton());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * dificulty * Time.deltaTime);

        if (Input.GetMouseButtonDown(0) && !isMouseRight)
        {
            transform.Translate(Vector3.down * 0.2f);
        }

        if(Input.GetMouseButtonDown(1) && isMouseRight)
        {
            transform.Translate(Vector3.down * 0.2f);
        }


        if(transform.position.x > 7.8f)
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
}
