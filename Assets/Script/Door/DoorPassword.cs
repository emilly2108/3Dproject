using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DoorPassword : MonoBehaviour
{
    //✅
    [SerializeField] PlayerController playerController;
    public Door door;
    [SerializeField]
    private GameObject Crosshair;
    [SerializeField]
    private GameObject Text_UI;
    // room1의 방 자물쇠 숫자
    [SerializeField]
    private TextMeshProUGUI Room1text1;
    [SerializeField]
    private TextMeshProUGUI Room1text2;
    [SerializeField]
    private TextMeshProUGUI Room1text3;
    [SerializeField]
    private TextMeshProUGUI Room1text4;

    // room3의 방 자물쇠 문자
    [SerializeField]
    private TextMeshProUGUI Room3text1;
    [SerializeField]
    private TextMeshProUGUI Room3text2;
    [SerializeField]
    private TextMeshProUGUI Room3text3;
    [SerializeField]
    private TextMeshProUGUI Room3text4;

    // room4의 방 자물쇠 문자
    [SerializeField]
    private TextMeshProUGUI Room4text1;
    [SerializeField]
    private TextMeshProUGUI Room4text2;
    [SerializeField]
    private TextMeshProUGUI Room4text3;

    //room1의 자물쇠의 정답
    private int R1answer1 = 3;
    private int R1answer2 = 1;
    private int R1answer3 = 2;
    private int R1answer4 = 0;


    //room3의 자물쇠의 정답
    private string R3answer1 = "D";
    private string R3answer2 = "A";
    private string R3answer3 = "R";
    private string R3answer4 = "K";

    //room4의 자물쇠의 정답
    private string R4answer1 = "G";
    private string R4answer2 = "Y";
    private string R4answer3 = "M";

    // 문 퀴즈 오브젝트 입력
    [SerializeField]
    private GameObject Room1_DoorQ;
    [SerializeField]
    private GameObject Room3_DoorQ;
    [SerializeField]
    private GameObject Room4_DoorQ;

    void Start()
    {

    }


    void Update()
    {
        Door1PassWord();
        Door3PassWord();
    }
    private void Door1PassWord()
    {
        int R1num1 = int.Parse(Room1text1.text);
        int R1num2 = int.Parse(Room1text2.text);
        int R1num3 = int.Parse(Room1text3.text);
        int R1num4 = int.Parse(Room1text4.text);
        if (R1num1 == R1answer1 && R1num2 == R1answer2 && R1num3 == R1answer3 && R1num4 == R1answer4)

        {
            playerController.SetCanMove(true);  // 이동 허용
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

    private void Door3PassWord()
    {
        string R3str1 = (Room3text1.text);
        string R3str2 = (Room3text2.text);
        string R3str3 = (Room3text3.text);
        string R3str4 = (Room3text4.text);
        if (R3answer1 == Room3text1.text && R3answer2 == Room3text2.text && R3answer3 == Room3text3.text && R3answer4 == Room3text4.text)
        {
            playerController.SetCanMove(true);
            door.Solve3 = true;
            Room3_DoorQ.SetActive(false);
            door.Show3 = false;
            Text_UI.SetActive(true);
            Crosshair.SetActive(true);
        }
        else
        {
            door.Solve3 = false;
        }
    }

    private void Door4PassWord()
    {
        string R4str1 = (Room4text1.text);
        string R4str2 = (Room4text2.text);
        string R4str3 = (Room4text3.text);
        if (R4answer1 == Room4text1.text && R4answer2 == Room4text2.text && R4answer3 == Room4text3.text)
        {
            playerController.SetCanMove(true);
            door.Solve4 = true;
            Room4_DoorQ.SetActive(false);
            door.Show4 = false;
            Text_UI.SetActive(true);
            Crosshair.SetActive(true);
        }
        else
        {
            door.Solve4 = false;
        }
    }
}