using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndCutscene : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private Canvas back;
    [SerializeField] private float fadeSpeed = 2.0f;
    private bool isEntered = false;
    private void Start()
    {
        StartCoroutine(FadeTo(0));
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !isEntered)
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
        if(targetAlpha == 1) Application.Quit();

    }
}
