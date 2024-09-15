 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExcaliburEnd : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeSpeed = 2.0f;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
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
        SceneManager.LoadScene(3);
    }
}
