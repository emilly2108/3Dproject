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

    // room5의 방 자물쇠 문자
    [SerializeField]
    private TextMeshProUGUI Room5text1;
    [SerializeField]
    private TextMeshProUGUI Room5text2;
    [SerializeField]
    private TextMeshProUGUI Room5text3;
    [SerializeField]
    private TextMeshProUGUI Room5text4;

    // room6의 방 자물쇠 문자
    [SerializeField]
    private TextMeshProUGUI Room6text1;
    [SerializeField]
    private TextMeshProUGUI Room6text2;
    [SerializeField]
    private TextMeshProUGUI Room6text3;

    // room7의 방 자물쇠 문자
    [SerializeField]
    private TextMeshProUGUI Room7text1;
    [SerializeField]
    private TextMeshProUGUI Room7text2;
    [SerializeField]
    private TextMeshProUGUI Room7text3;

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

    //room5의 자물쇠의 정답
    private string R5answer1 = "D";
    private string R5answer2 = "A";
    private string R5answer3 = "E";
    private string R5answer4 = "N";

    //room6의 자물쇠의 정답
    private int R6answer1 = 9;
    private int R6answer2 = 5;
    private int R6answer3 = 2;

    //room7의 자물쇠의 정답
    private int R7answer1 = 8;
    private int R7answer2 = 4;
    private int R7answer3 = 9;

    // 문 퀴즈 오브젝트 입력
    [SerializeField]
    private GameObject Room1_DoorQ;
    [SerializeField]
    private GameObject Room3_DoorQ;
    [SerializeField]
    private GameObject Room4_DoorQ;
    [SerializeField]
    private GameObject Room5_DoorQ;
    [SerializeField]
    private GameObject Room6_DoorQ;
    [SerializeField]
    private GameObject Room7_DoorQ;

    public bool hasShownMessage1=false;
    public bool hasShownMessage2 = false;
    public bool hasShownMessage3 = false;
    public bool hasShownMessage4 = false;
    public bool hasShownMessage5 = false;
    public bool hasShownMessage6 = false;
    public bool hasShownMessage7 = false;
    void Start()
    {

    }


    void Update()
    {
        Door1PassWord();
        Door3PassWord();
        Door4PassWord();
        Door5PassWord();
        Door6PassWord();
        Door7PassWord();
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
            if (!hasShownMessage1)
            {
                SoundManager.instance.PlaySE("doorUnlock");
                GuideTextManager.Instance.ShowMessage("여기서 오른쪽으로 쭉 가면 화장실이 나온다. 들어가보자.");
                hasShownMessage1 = true; 
            }
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
            if (!hasShownMessage2)
            {
                SoundManager.instance.PlaySE("doorUnlock");
                GuideTextManager.Instance.ShowMessage("2번방 안내메세지");
                hasShownMessage2 = true;
            }
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
            if (!hasShownMessage3)
            {
                SoundManager.instance.PlaySE("doorUnlock");
                GuideTextManager.Instance.ShowMessage("3번방 안내메세지");
                hasShownMessage3 = true;
            }
        }
        else
        {
            door.Solve4 = false;
        }
    }
    private void Door5PassWord()
    {
        string R5str1 = (Room5text1.text);
        string R5str2 = (Room5text2.text);
        string R5str3 = (Room5text3.text);
        string R5str4 = (Room5text4.text);
        if (R5answer1 == Room5text1.text && R5answer2 == Room5text2.text && R5answer3 == Room5text3.text && R5answer4 == Room5text4.text)
        {
             
            playerController.SetCanMove(true);
            door.Solve5 = true;
            Room5_DoorQ.SetActive(false);
            door.Show5 = false;
            Text_UI.SetActive(true);
            Crosshair.SetActive(true);
            if (!hasShownMessage4)
            {
                SoundManager.instance.PlaySE("doorUnlock");
                GuideTextManager.Instance.ShowMessage("4번방 안내메세지");
                hasShownMessage4 = true;
            }
        }
        else
        {
            door.Solve5 = false;
        }
    }

    private void Door6PassWord()
    {
        
        int R6num1 = int.Parse(Room6text1.text);
        int R6num2 = int.Parse(Room6text2.text);
        int R6num3 = int.Parse(Room6text3.text);
        if (R6num1 == R6answer1 && R6num2 == R6answer2 && R6num3 == R6answer3 )

        {
            playerController.SetCanMove(true); 
            door.Solve6 = true;
            Room6_DoorQ.SetActive(false);
            door.Show6 = false;
            Text_UI.SetActive(true);
            Crosshair.SetActive(true);
            if (!hasShownMessage5)
            {
                SoundManager.instance.PlaySE("doorUnlock");
                GuideTextManager.Instance.ShowMessage("5번방 안내메세지");
                hasShownMessage5 = true;
            }
        }
        else
        {
            door.Solve6 = false;
        }
    }

    private void Door7PassWord()
    {

        int R7num1 = int.Parse(Room7text1.text);
        int R7num2 = int.Parse(Room7text2.text);
        int R7num3 = int.Parse(Room7text3.text);
        if (R7num1 == R7answer1 && R7num2 == R7answer2 && R7num3 == R7answer3)

        {
            playerController.SetCanMove(true);
            door.Solve7 = true;
            Room7_DoorQ.SetActive(false);
            door.Show7 = false;
            Text_UI.SetActive(true);
            Crosshair.SetActive(true);
            if (!hasShownMessage6)
            {
                SoundManager.instance.PlaySE("doorUnlock");
                GuideTextManager.Instance.ShowMessage("6번방 안내메세지");
                hasShownMessage6 = true;
            }
        }
        else
        {
            door.Solve7 = false;
        }
    }
}