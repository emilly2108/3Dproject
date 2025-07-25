/*using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class DoorPassword : MonoBehaviour
{

    public Door door;

    [SerializeField] private GameObject Crosshair;
    [SerializeField] private GameObject MessageObject;      // 안내 메시지 오브젝트 전체
    [SerializeField] private Text MessageText;              // 기본 Text (안내 메시지)

    // 자물쇠 숫자 (TMP)
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
    public bool Solved => isSolved; // 외부에서 읽을 수 있도록 속성으로 노출
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

            ShowMessage("문이 열렸습니다");
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