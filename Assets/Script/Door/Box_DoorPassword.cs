using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Box_DoorPassword : MonoBehaviour
{
    [SerializeField] 
    PlayerController playerController;
    public Box_Door Box_door;
    [SerializeField]
    private GameObject Crosshair;
    [SerializeField]
    private GameObject Text_UI;

    [SerializeField]
    private TextMeshProUGUI Box_Door1text1;
    [SerializeField]
    private TextMeshProUGUI Box_Door1text2;
    [SerializeField]
    private TextMeshProUGUI Box_Door1text3;
    [SerializeField]
    private TextMeshProUGUI Box_Door1text4;

    [SerializeField]
    private TextMeshProUGUI Box_Door2text1;
    [SerializeField]
    private TextMeshProUGUI Box_Door2text2;
    [SerializeField]
    private TextMeshProUGUI Box_Door2text3;
    [SerializeField]
    private TextMeshProUGUI Box_Door2text4;

    [SerializeField]
    private TextMeshProUGUI Box_Door3text1;
    [SerializeField]
    private TextMeshProUGUI Box_Door3text2;
    [SerializeField]
    private TextMeshProUGUI Box_Door3text3;
    [SerializeField]
    private TextMeshProUGUI Box_Door3text4;

    [SerializeField]
    private TextMeshProUGUI Box_Door4text1;
    [SerializeField]
    private TextMeshProUGUI Box_Door4text2;
    [SerializeField]
    private TextMeshProUGUI Box_Door4text3;
    [SerializeField]
    private TextMeshProUGUI Box_Door4text4;

    [SerializeField]
    private TextMeshProUGUI Box_Door5text1;
    [SerializeField]
    private TextMeshProUGUI Box_Door5text2;
    [SerializeField]
    private TextMeshProUGUI Box_Door5text3;
    [SerializeField]
    private TextMeshProUGUI Box_Door5text4;

    //room1의 자물쇠의 정답
    private int B1answer1 = 3;
    private int B1answer2 = 8;
    private int B1answer3 = 1;
    private int B1answer4 = 0;


    //room3의 자물쇠의 정답
    private string B2answer1 = "L";
    private string B2answer2 = "O";
    private string B2answer3 = "V";
    private string B2answer4 = "E";

    //room4의 자물쇠의 정답
    private int B3answer1 = 2;
    private int B3answer2 = 6;
    private int B3answer3 = 8;
    private int B3answer4 = 4;

    //room5의 자물쇠의 정답
    private int B4answer1 = 1;
    private int B4answer2 = 0;
    private int B4answer3 = 2;
    private int B4answer4 = 3;

    //room3의 자물쇠의 정답
    private string B5answer1 = "V";
    private string B5answer2 = "A";
    private string B5answer3 = "L";
    private string B5answer4 = "E";

    // 문 퀴즈 오브젝트 입력
    [SerializeField]
    private GameObject BoxDoor1_DoorQ;
    [SerializeField]
    private GameObject BoxDoor2_DoorQ;    
    [SerializeField]
    private GameObject BoxDoor3_DoorQ;
    [SerializeField]
    private GameObject BoxDoor4_DoorQ;
    [SerializeField]
    private GameObject BoxDoor5_DoorQ;


    void Start()
    {

    }


    void Update()
    {
        Box_Door1PassWord();
        Box_Door2PassWord();
        Box_Door3PassWord();
        Box_Door4PassWord();
        Box_Door5PassWord();
    }
    private void Box_Door1PassWord()
    {
        int B1num1 = int.Parse(Box_Door1text1.text);
        int B1num2 = int.Parse(Box_Door1text2.text);
        int B1num3 = int.Parse(Box_Door1text3.text);
        int B1num4 = int.Parse(Box_Door1text4.text);
        if (B1num1 == B1answer1 && B1num2 == B1answer2 && B1num3 == B1answer3 && B1num4 == B1answer4)

        {
            playerController.SetCanMove(true); 
            Box_door.Solve[0] = true;
            BoxDoor1_DoorQ.SetActive(false);
            Box_door.Show[0] = false;
            Text_UI.SetActive(true);
            Crosshair.SetActive(true);
        }
        else
        {
            Box_door.Solve[0] = false;
        }
    }

    private void Box_Door2PassWord()
    {
        string B2str1 = (Box_Door2text1.text);
        string B2str2 = (Box_Door2text2.text);
        string B2str3 = (Box_Door2text3.text);
        string B2str4 = (Box_Door2text4.text);
        if (B2str1 == B2answer1 && B2str2 == B2answer2 && B2str3 == B2answer3 && B2str4 == B2answer4)
        {
            playerController.SetCanMove(true);
            Box_door.Solve[1] = true;
            BoxDoor2_DoorQ.SetActive(false);
            Box_door.Show[1] = false;
            Text_UI.SetActive(true);
            Crosshair.SetActive(true);
        }
        else
        {
            Box_door.Solve[1] = false;
        }
    }

    private void Box_Door3PassWord()
    {
        int B3num1 = int.Parse(Box_Door3text1.text);
        int B3num2 = int.Parse(Box_Door3text2.text);
        int B3num3 = int.Parse(Box_Door3text3.text);
        int B3num4 = int.Parse(Box_Door3text4.text);
        if (B3num1 == B3answer1 && B3num2 == B3answer2 && B3num3 == B3answer3 && B3num4 == B3answer4)

        {
            playerController.SetCanMove(true);
            Box_door.Solve[2] = true;
            BoxDoor3_DoorQ.SetActive(false);
            Box_door.Show[2] = false;
            Text_UI.SetActive(true);
            Crosshair.SetActive(true);
        }
        else
        {
            Box_door.Solve[2] = false;
        }
    }
    private void Box_Door4PassWord()
    {
        int B4num1 = int.Parse(Box_Door4text1.text);
        int B4num2 = int.Parse(Box_Door4text2.text);
        int B4num3 = int.Parse(Box_Door4text3.text);
        int B4num4 = int.Parse(Box_Door4text4.text);
        if (B4num1 == B4answer1 && B4num2 == B4answer2 && B4num3 == B4answer3 && B4num4 == B4answer4)

        {
            playerController.SetCanMove(true);
            Box_door.Solve[3] = true;
            BoxDoor4_DoorQ.SetActive(false);
            Box_door.Show[3] = false;
            Text_UI.SetActive(true);
            Crosshair.SetActive(true);
        }
        else
        {
            Box_door.Solve[3] = false;
        }
    }

    private void Box_Door5PassWord()
    {
        string B5str1 = (Box_Door5text1.text);
        string B5str2 = (Box_Door5text2.text);
        string B5str3 = (Box_Door5text3.text);
        string B5str4 = (Box_Door5text4.text);
        if (B5str1 == B5answer1 && B5str2 == B5answer2 && B5str3 == B5answer3 && B5str4 == B5answer4)
        {
            playerController.SetCanMove(true);
            Box_door.Solve[4] = true;
            BoxDoor5_DoorQ.SetActive(false);
            Box_door.Show[4] = false;
            Text_UI.SetActive(true);
            Crosshair.SetActive(true);
        }
        else
        {
            Box_door.Solve[4] = false;
        }
    }
}