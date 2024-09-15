using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SansDialogueScript : MonoBehaviour
{
    private string[] lines;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Canvas messageImage;
    [SerializeField] private PlayerController player;
    [SerializeField] private Image cane;
    private void Start()
    {
        cane.gameObject.SetActive(false);
        lines = new string[] { 
            "���",
            "� ��� �����, �� �� ������ ���� �������",
            "����� �� � ����� �������� �����ʲ���(",
            "�����, ����� � ��� ������ �������?",
            "��� ������ ���� �����, ���",
            "����...",
            "����� ���� ���� ���� � �����, �� ��� ����������� �� �����",
            "����� �� ��������))",
            "�����, �� ���� � ������� ����� �������",
            "��� �������)"
        };
    }
    public IEnumerator DialogueLoop()
    {
        yield return new WaitForSeconds(4f);
        messageImage.gameObject.SetActive(true);
        for(int i = 0 ; i < lines.Length; i++) 
        {
            text.text = lines[i];
            yield return new WaitForSeconds(4f);
        }
        messageImage.gameObject.SetActive(false);
        player.isWeaponed = true;
        cane.gameObject.SetActive(true);
    }    

}
