using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PortalController : MonoBehaviour
{
    public Image fadeImage;
    public float fadeSpeed = 2.0f;
    private void Start()
    {
        StartCoroutine(FadeTo(0));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            StartCoroutine(FadeTo(1));
    }
    private IEnumerator FadeTo(float targetAlpha)
    {
        Color currentColor = fadeImage.color;
        float timer = 0;

        while (timer < 1f)
        {
            timer += Time.deltaTime * fadeSpeed;
            currentColor.a = Mathf.Lerp(currentColor.a, targetAlpha, timer);
            fadeImage.color = currentColor;
            yield return null;
        }
        if(targetAlpha == 1) SceneManager.LoadScene(2);
    }
}