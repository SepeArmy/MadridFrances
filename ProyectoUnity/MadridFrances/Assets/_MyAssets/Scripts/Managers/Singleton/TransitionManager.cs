using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    public static TransitionManager THIS;

    Animator anim;
    CanvasGroup canvasGroup;

    public GameStates newStateAfterTransition;
    public int targetSceneIndexAfterTransition;

    public bool transitioning = false;

    void Awake()
    {
        THIS = this;

        // almacenamos el componente Animator de "TransitionManager" en la variable "anim" y la desactivamos
        anim = GetComponent<Animator>();
        anim.enabled = false;

        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void TransitionOnStarts(GameStates newState, int newSceneIndex)
    {
        Time.timeScale = 1f;
        transitioning = true;
        StartCoroutine(MusicManager.THIS.FadeOut(1f));
        if (!anim.enabled)
        {
            newStateAfterTransition = newState;
            targetSceneIndexAfterTransition = newSceneIndex;

            anim.Rebind();
            anim.enabled = true;
        }
    }

    // El estado "Transition_On" finaliza
    public void TransitionOnEnds()
    {
        anim.SetTrigger("transit");
        SceneManager.LoadScene(targetSceneIndexAfterTransition);
        Invoke("RespawnInvoke", 0.05f);
    }

    public void TransitionOffEnds()
    {
        anim.enabled = false;
        canvasGroup.blocksRaycasts = false;

        transitioning = false;
        GameManager.THIS.SetState(newStateAfterTransition);
        
    }

    public int GetActiveSceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    private void RespawnInvoke()
    {
        RespawnManager.THIS.CheckRespawn();
    }
}
