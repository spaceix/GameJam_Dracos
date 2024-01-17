using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class SceneTransitionManager : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 0.5f;
    public float waitForSeconds = 5.0f;
    public GameObject targetImage;
    public string nextSceneName;
    public Timer timer;
    public GameObject[] elements;

    const string dieSceneName = "GameOver";

    private void Start()
    {
        StartCoroutine(StartScene());
    }

    private void Update()
    {
        if (timer != null)
        {
            if (timer.isDie)
            {
                StartCoroutine(GameOver());
            }
        }
    }

    IEnumerator GameOver()
    {
        yield return FadeOut();
        
        GameOverScene();
    }
    IEnumerator StartScene()
    {
        yield return FadeIn();

        targetImage.SetActive(true);

        yield return new WaitForSeconds(waitForSeconds);

        yield return FadeOut();

        targetImage.SetActive(false);

        yield return FadeIn();

        //foreach (GameObject Element in elements)
        //{
        //    Element.SetActive(true);
        //}
    }

    IEnumerator FadeIn()
    {
        float timer = 0f;

        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            SetImageAlpha(alpha);

            timer += Time.deltaTime;
            yield return null;
        }

        SetImageAlpha(0f);
    }

    IEnumerator FadeOut()
    {
        float timer = 0f;

        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            SetImageAlpha(alpha);

            timer += Time.deltaTime;
            yield return null;
        }

        foreach (GameObject Element in elements)
        {
            Element.SetActive(true);
        }

        SetImageAlpha(1f);
    }

    public void NextScene()
    {
        FadeIn();
        SceneManager.LoadScene(nextSceneName);
    }

    public void GameOverScene()
    {
        foreach (GameObject Element in elements)
        {
            Element.SetActive(false);
        }

        FadeIn();

        SceneManager.LoadScene(dieSceneName);
    }
    void SetImageAlpha(float alpha)
    {
        Color imageColor = fadeImage.color;
        imageColor.a = alpha;
        fadeImage.color = imageColor;
    }
}
