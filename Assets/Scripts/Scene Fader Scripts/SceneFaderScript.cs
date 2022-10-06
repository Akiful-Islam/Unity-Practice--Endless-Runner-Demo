using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFaderScript : MonoBehaviour
{
    public static SceneFaderScript instance;
    [SerializeField] private GameObject _fadePanel;
    [SerializeField] private Animator _fadeAnimator;

    private void Awake()
    {
        MakeSingleton();
    }

    private void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void FadeToLoadScene(string scene)
    {
        StartCoroutine(FadeInOut(scene));
    }

    IEnumerator FadeInOut(string scene)
    {
        _fadePanel.SetActive(true);

        _fadeAnimator.Play("FadeIn");
        yield return StartCoroutine(AnimationCoroutine.WaitForRealSeconds(1f));

        SceneManager.LoadScene(scene);

        _fadeAnimator.Play("FadeOut");
        yield return StartCoroutine(AnimationCoroutine.WaitForRealSeconds(0.7f));
        _fadePanel.SetActive(false);
    }
}
