using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SansAndPapyrusScene : MonoBehaviour
{
    [SerializeField] private TextMeshPro sansText;
    [SerializeField] private TextMeshPro papyrusText;
    [SerializeField] private float talkingDelay = 3f;
    [SerializeField] private float waitingDelay = 1f;
    [SerializeField] private Image fadeImage;
    private string[] jokes;
    private string[] text;
    void Start()
    {
        StartCoroutine(FadeTo(0));
        jokes = new string[] { 
            "чому скелети втомлюютьс€ на робот≥?",
            "- бо вони виконують тону прац≥. — ≈Ћ≈“ќЌЌ”",
            "”люблений вихованець ус≥х скелет≥в це...",
            "- „≈–≈ѕаха",
        };
        text = new string[] {
            "о, ти вже тут!",
            "щоб подолати босса тоб≥ знадобитьс€ ≈кскал≥бур.",
            "пройди дал≥ ≥ одразу його знайдеш.",
            "в≥н точно придасть тоб≥ лег ≤—“№)))",
            "хай щайстить)",
        };

    }
    public IEnumerator Dialogue()
    {
        for(int i = 0; i < jokes.Length - 1; i+=2)
        {
            if (i / 2 % 2 == 0)
            {
                sansText.text = jokes[i];
                yield return new WaitForSeconds(talkingDelay);
                sansText.text = jokes[i + 1];
            }
            else
            {
                papyrusText.text = jokes[i];
                yield return new WaitForSeconds(talkingDelay);
                papyrusText.text = jokes[i + 1];
            }
            yield return new WaitForSeconds(talkingDelay);
            yield return new WaitForSeconds(waitingDelay);
        }
    }
    public void StartSansDialogue() => StartCoroutine(Dialogue2());
    public IEnumerator Dialogue2()
    {
        for(int i = 0; i < text.Length; i++)
        {
            sansText.text = text[i];
            yield return new WaitForSeconds(talkingDelay);
        }
    }
    private IEnumerator FadeTo(float targetAlpha)
    {
        Color currentColor = fadeImage.color;
        float timer = 0;

        while (timer < 1f)
        {
            timer += Time.deltaTime * 2f;
            currentColor.a = Mathf.Lerp(currentColor.a, targetAlpha, timer);
            fadeImage.color = currentColor;
            yield return null;
        }
    }
}
