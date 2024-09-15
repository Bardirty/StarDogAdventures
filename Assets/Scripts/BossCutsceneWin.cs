using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossCutsceneWin : MonoBehaviour
{
    [SerializeField] private TextMeshPro text;
    [SerializeField] private GameObject boss;
    private string[] lines;
    [SerializeField] private float delay = 3f;
    private void Start()
    {
        lines = new string[] 
        {
            "НІІІ, залиш мені хоча б останнє дев’яте життя!",
            "Знаєш…",
            "тепер я розумію, що зробив помилку ",
            "Ти не той, з ким я маю битися, напроти - ми маємо бути в команді",
            "Ось що: знайди но Санса з Папірусом, вони знають де знайти те, що допоможе тобі у битві з ним..",
            "Ще побачимось"
        };
    }
    public IEnumerator yuyMonologue()
    {
        foreach (string line in lines)
        {
            text.text = line;
            yield return new WaitForSeconds(delay);
        }
        boss.SetActive(false);
    }
}
