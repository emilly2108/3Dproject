using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CasePassWord : MonoBehaviour
{
    [SerializeField]
    PlayerController playerController;
    public Case Case;
    [SerializeField]
    private GameObject Crosshair;
    [SerializeField]
    private GameObject Text_UI;

    // Case1의 자물쇠 숫자
    [SerializeField]
    private TextMeshProUGUI Case1text1;
    [SerializeField]
    private TextMeshProUGUI Case1text2;
    [SerializeField]
    private TextMeshProUGUI Case1text3;

    // Case2의 자물쇠 알파벳
    [SerializeField]
    private TextMeshProUGUI Case2text1;
    [SerializeField]
    private TextMeshProUGUI Case2text2;
    [SerializeField]
    private TextMeshProUGUI Case2text3;
    [SerializeField]
    private TextMeshProUGUI Case2text4;

    // Case3의 자물쇠 알파벳
    [SerializeField]
    private TextMeshProUGUI Case3text1;
    [SerializeField]
    private TextMeshProUGUI Case3text2;
    [SerializeField]
    private TextMeshProUGUI Case3text3;
    [SerializeField]
    private TextMeshProUGUI Case3text4;

    // Case4의 자물쇠 숫자
    [SerializeField]
    private TextMeshProUGUI Case4text1;
    [SerializeField]
    private TextMeshProUGUI Case4text2;
    [SerializeField]
    private TextMeshProUGUI Case4text3;

    // Case3의 자물쇠 알파벳
    [SerializeField]
    private TextMeshProUGUI Case5text1;
    [SerializeField]
    private TextMeshProUGUI Case5text2;
    [SerializeField]
    private TextMeshProUGUI Case5text3;
    [SerializeField]
    private TextMeshProUGUI Case5text4;

    //room1의 case1자물쇠의 정답
    private int C1_answer1 = 4;
    private int C1_answer2 = 1;
    private int C1_answer3 = 4;

    //room1의 case2자물쇠의 정답
    private string C2_answer1 = "S";
    private string C2_answer2 = "A";
    private string C2_answer3 = "L";
    private string C2_answer4 = "T";

    //room3의 case1자물쇠의 정답
    private string C3_answer1 = "R";
    private string C3_answer2 = "E";
    private string C3_answer3 = "S";
    private string C3_answer4 = "T";

    //room3의 case2자물쇠의 정답
    private int C4_answer1 = 3;
    private int C4_answer2 = 0;
    private int C4_answer3 = 2;

    //room3의 case2자물쇠의 정답
    private int C5_answer1 = 1;
    private int C5_answer2 = 0;
    private int C5_answer3 = 7;
    private int C5_answer4 = 5;

    // 케이스 퀴즈 오브젝트 입력
    [SerializeField]
    private GameObject Room1_Case1;
    [SerializeField]
    private GameObject Room1_Case2;
    [SerializeField]
    private GameObject Room3_Case1;
    [SerializeField]
    private GameObject Room3_Case2;
    [SerializeField]
    private GameObject Room3_Case3;
    void Start()
    {

    }

    void Update()
    {
        R1Case1PassWord();
        R1Case2PassWord();
        R3Case1PassWord();
        R3Case2PassWord();
        R3Case3PassWord();
    }

    private void R1Case1PassWord()
    {
        int R1num1 = int.Parse(Case1text1.text);
        int R1num2 = int.Parse(Case1text2.text);
        int R1num3 = int.Parse(Case1text3.text);
        if (R1num1 == C1_answer1 && R1num2 == C1_answer2 && R1num3 == C1_answer3)
        {
            Case.Solve1 = true;
            Room1_Case1.SetActive(false);
            Case.Showing1 = false;
            Text_UI.SetActive(true);
            Crosshair.SetActive(true);
            playerController.SetCanMove(true);
        }
        else
        {
            Case.Solve1 = false;
        }
    }

    private void R1Case2PassWord()
    {
        string R1text1 = Case2text1.text;
        string R1text2 = Case2text2.text;
        string R1text3 = Case2text3.text;
        string R1text4 = Case2text4.text;
        if (R1text1 == C2_answer1 && R1text2 == C2_answer2 && R1text3 == C2_answer3 && R1text4 == C2_answer4)
        {
            Case.Solve2 = true;
            Room1_Case2.SetActive(false);
            Case.Showing2 = false;
            Text_UI.SetActive(true);
            Crosshair.SetActive(true);
            playerController.SetCanMove(true);
        }
        else
        {
            Case.Solve2 = false;
        }
    }

    private void R3Case1PassWord()
    {
        string R3text1 = Case3text1.text;
        string R3text2 = Case3text2.text;
        string R3text3 = Case3text3.text;
        string R3text4 = Case3text4.text;
        if (R3text1 == C3_answer1 && R3text2 == C3_answer2 && R3text3 == C3_answer3 && R3text4 == C3_answer4)
        {
            Case.Solve3 = true;
            Room3_Case1.SetActive(false);
            Case.Showing3 = false;
            Text_UI.SetActive(true);
            Crosshair.SetActive(true);
            playerController.SetCanMove(true);
        }
        else
        {
            Case.Solve3 = false;
        }
    }
    private void R3Case2PassWord()
    {
        int R3num1 = int.Parse(Case4text1.text);
        int R3num2 = int.Parse(Case4text2.text);
        int R3num3 = int.Parse(Case4text3.text);
        if (R3num1 == C4_answer1 && R3num2 == C4_answer2 && R3num3 == C4_answer3)
        {
            Case.Solve4 = true;
            Room3_Case2.SetActive(false);
            Case.Showing4 = false;
            Text_UI.SetActive(true);
            Crosshair.SetActive(true);
            playerController.SetCanMove(true);
        }
        else
        {
            Case.Solve4 = false;
        }
    }
    
    private void R3Case3PassWord()
    {
        int R3_2num1 = int.Parse(Case5text1.text);
        int R3_2num2 = int.Parse(Case5text2.text);
        int R3_2num3 = int.Parse(Case5text3.text);
        int R3_2num4 = int.Parse(Case5text4.text);
        if (R3_2num1 == C5_answer1 && R3_2num2 == C5_answer2 && R3_2num3 == C5_answer3 && R3_2num4 == C5_answer4)
        {
            Case.Solve5 = true;
            Room3_Case3.SetActive(false);
            Case.Showing5 = false;
            Text_UI.SetActive(true);
            Crosshair.SetActive(true);
            playerController.SetCanMove(true);
        }
        else
        {
            Case.Solve5 = false;
        }
    }
}
