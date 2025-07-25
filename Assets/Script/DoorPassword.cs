/*using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class DoorPassword : MonoBehaviour
{

    public Door door;

    [SerializeField] private GameObject Crosshair;
    [SerializeField] private GameObject MessageObject;      // �ȳ� �޽��� ������Ʈ ��ü
    [SerializeField] private Text MessageText;              // �⺻ Text (�ȳ� �޽���)

    // �ڹ��� ���� (TMP)
    [SerializeField] private TextMeshProUGUI Room1text1;
    [SerializeField] private TextMeshProUGUI Room1text2;
    [SerializeField] private TextMeshProUGUI Room1text3;
    [SerializeField] private TextMeshProUGUI Room1text4;

    private int answer1 = 3;
    private int answer2 = 1;
    private int answer3 = 2;
    private int answer4 = 0;

    [SerializeField] private GameObject Room1_DoorQ;

    private bool isSolved = false;
    public bool Solved => isSolved; // �ܺο��� ���� �� �ֵ��� �Ӽ����� ����
    void Update()
    {
        Door1PassWord();
    }

    private void Door1PassWord()
    {
        if (isSolved) return;

        int num1 = int.Parse(Room1text1.text);
        int num2 = int.Parse(Room1text2.text);
        int num3 = int.Parse(Room1text3.text);
        int num4 = int.Parse(Room1text4.text);

        if (num1 == answer1 && num2 == answer2 && num3 == answer3 && num4 == answer4)
        {
            isSolved = true;
            door.Solve1 = true;
            Room1_DoorQ.SetActive(false);
            Crosshair.SetActive(true);

            ShowMessage("���� ���Ƚ��ϴ�");
        }
        else
        {
            door.Solve1 = false;
        }
    }

    private void ShowMessage(string message)
    {
        MessageText.text = message;
        MessageObject.SetActive(true);
        StartCoroutine(HideMessageAfterDelay(3f));
    }

    private IEnumerator HideMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        MessageObject.SetActive(false);
    }
}*/