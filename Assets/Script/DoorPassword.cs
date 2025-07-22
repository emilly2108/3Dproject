using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DoorPassword : MonoBehaviour
{
    public Door door;
    [SerializeField]
    private GameObject Crosshair;
    [SerializeField]
    private GameObject Text_UI;
    // room1�� �� �ڹ��� ����
    [SerializeField]
    private TextMeshProUGUI Room1text1;
    [SerializeField]
    private TextMeshProUGUI Room1text2;
    [SerializeField]
    private TextMeshProUGUI Room1text3;
    [SerializeField]
    private TextMeshProUGUI Room1text4;
    //room1�� �ڹ����� ����
    private int answer1 = 3;
    private int answer2 = 1;
    private int answer3 = 2;
    private int answer4 = 0;
    // �� ���� ������Ʈ �Է�
    [SerializeField]
    private GameObject Room1_DoorQ;
    void Start()
    {
        
    }

    
    void Update()
    {
        Door1PassWord();
    }
    private void Door1PassWord()
    {
        int num1 = int.Parse(Room1text1.text);
        int num2 = int.Parse(Room1text2.text);
        int num3 = int.Parse(Room1text3.text);
        int num4 = int.Parse(Room1text4.text);
        if (num1 == answer1 && num2 == answer2 && num3 == answer3 && num4 == answer4)
        {
            door.Solve1 = true;
            Room1_DoorQ.SetActive(false);
            door.Show1 = false;
            Text_UI.SetActive(true);
            Crosshair.SetActive(true);
        }
        else
        {
            door.Solve1 = false;
        }
    }


}