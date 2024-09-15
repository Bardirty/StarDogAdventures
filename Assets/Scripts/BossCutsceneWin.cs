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
            "Ͳ��, ����� ��� ���� � ������ ������ �����!",
            "�����",
            "����� � ������, �� ������ ������� ",
            "�� �� ���, � ��� � ��� ������, ������� - �� ���� ���� � ������",
            "��� ��: ������ �� ����� � ��������, ���� ������ �� ������ ��, �� �������� ��� � ���� � ���..",
            "�� ����������"
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
