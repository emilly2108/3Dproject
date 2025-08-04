using UnityEngine;
using TMPro;

public class Case : MonoBehaviour
{
    [SerializeField] 
    PlayerController playerController;

    [SerializeField] 
    private GameObject case1;
    [SerializeField]
    private GameObject case2;
    [SerializeField] 
    private GameObject case3;
    [SerializeField] 
    private GameObject case4;
    [SerializeField] 
    private GameObject case5;
    [SerializeField] 
    private GameObject case6;
    [SerializeField] 
    private GameObject case7;
    [SerializeField] 
    private GameObject case8;
    [SerializeField] 
    private GameObject case9;

    [SerializeField] 
    private GameObject Crosshair;
    [SerializeField] 
    private GameObject Text_UI;
    [SerializeField] 
    public TextMeshProUGUI TextUI;

    [SerializeField] 
    private OpenCase Room1_OpenCase1;
    [SerializeField] 
    private OpenCase Room1_OpenCase2;
    [SerializeField] 
    private OpenCase Room3_OpenCase1;
    [SerializeField] 
    private OpenCase Room3_OpenCase2;
    [SerializeField] 
    private OpenCase Room3_OpenCase3;
    [SerializeField] 
    private OpenCase Room5_OpenCase1;
    [SerializeField] 
    private OpenCase Room5_OpenCase2;
    [SerializeField] 
    private OpenCase Room5_OpenCase3;
    [SerializeField] 
    private OpenCase Room5_OpenCase4;
    [SerializeField] 
    private OpenCase Room5_OpenCase5;

    public bool Solve1 = false;
    public bool Solve2 = false;
    public bool Solve3 = false;
    public bool Solve4 = false;
    public bool Solve5 = false;
    public bool Solve6 = false;
    public bool Solve7 = false;
    public bool Solve8 = false;
    public bool Solve9 = false;
    public bool Solve10 = false;

    public bool Showing1 = false;
    public bool Showing2 = false;
    public bool Showing3 = false;
    public bool Showing4 = false;
    public bool Showing5 = false;
    public bool Showing6 = false;
    public bool Showing7 = false;
    public bool Showing8 = false;
    public bool Showing9 = false;

    private bool[] opening = new bool[9];
    private bool opening10 = false;
    private bool IsTouch = false;

    void Update()
    {
        OpenCase();
        CloseShow();
        Case_Open10();
    }

    void OpenCase()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        IsTouch = Physics.Raycast(ray, out hit, 1.5f);

        if (!IsTouch || !hit.transform.CompareTag("Case"))
            return;

        string caseName = hit.transform.name.Trim();
        TextUI.text = "서랍을 열려면 (Z)키를 누르세요";

        switch (caseName)
        {
            case "Room1_Case1":
                HandleCaseInteraction(0, Solve1, ref Showing1, Room1_OpenCase1, case1);
                break;
            case "Room1_Case2":
                HandleCaseInteraction(1, Solve2, ref Showing2, Room1_OpenCase2, case2);
                break;
            case "Room3_case1":
                HandleCaseInteraction(2, Solve3, ref Showing3, Room3_OpenCase1, case3);
                break;
            case "Room3_case2":
                HandleCaseInteraction(3, Solve4, ref Showing4, Room3_OpenCase2, case4);
                break;
            case "Room3_case3":
                HandleCaseInteraction(4, Solve5, ref Showing5, Room3_OpenCase3, case5);
                break;
            case "Room5_case1":
                HandleCaseInteraction(5, Solve6, ref Showing6, Room5_OpenCase1, case6);
                break;
            case "Room5_case2":
                HandleCaseInteraction(6, Solve7, ref Showing7, Room5_OpenCase2, case7);
                break;
            case "Room5_case3":
                HandleCaseInteraction(7, Solve8, ref Showing8, Room5_OpenCase3, case8);
                break;
            case "Room5_case4":
                HandleCaseInteraction(8, Solve9, ref Showing9, Room5_OpenCase4, case9);
                break;
        }
    }

    void HandleCaseInteraction(int index, bool solve, ref bool showing, OpenCase caseScript, GameObject caseUI)
    {
        if (!opening[index])
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (!solve)
                {
                    playerController.SetCanMove(false);
                    caseUI.SetActive(true);
                    showing = true;
                    Text_UI.SetActive(false);
                    Crosshair.SetActive(false);
                }
                else
                {
                    caseScript.StartCoroutine(caseScript.CaseOpen());
                    opening[index] = true;
                    playerController.SetCanMove(true);
                }
            }
        }
        else
        {
            TextUI.text = "서랍을 닫으려면 (Z)키를 누르세요";

            if (Input.GetKeyDown(KeyCode.Z))
            {
                caseScript.StartCoroutine(caseScript.CaseClose());
                opening[index] = false;
            }
        }
    }

    void CloseShow()
    {
        if (Showing1 && Input.GetKeyDown(KeyCode.R)) CloseCase(ref Showing1, case1);
        if (Showing2 && Input.GetKeyDown(KeyCode.R)) CloseCase(ref Showing2, case2);
        if (Showing3 && Input.GetKeyDown(KeyCode.R)) CloseCase(ref Showing3, case3);
        if (Showing4 && Input.GetKeyDown(KeyCode.R)) CloseCase(ref Showing4, case4);
        if (Showing5 && Input.GetKeyDown(KeyCode.R)) CloseCase(ref Showing5, case5);
        if (Showing6 && Input.GetKeyDown(KeyCode.R)) CloseCase(ref Showing6, case6);
        if (Showing7 && Input.GetKeyDown(KeyCode.R)) CloseCase(ref Showing7, case7);
        if (Showing8 && Input.GetKeyDown(KeyCode.R)) CloseCase(ref Showing8, case8);
        if (Showing9 && Input.GetKeyDown(KeyCode.R)) CloseCase(ref Showing9, case9);
    }

    void CloseCase(ref bool showing, GameObject caseUI)
    {
        playerController.SetCanMove(true);
        caseUI.SetActive(false);
        showing = false;
        Text_UI.SetActive(true);
        Crosshair.SetActive(true);
    }

    private void Case_Open10()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        IsTouch = Physics.Raycast(ray, out hit, 1.5f);
        if (hit.transform != null && hit.transform.gameObject.name == "Room5_case5")
        {
            if (Solve10 == true)
            {
                if (opening10 == false)
                {
                    TextUI.text = "서랍을 열려면 (Z)키를 누르세요";
                    if (Input.GetKeyDown(KeyCode.Z))
                    {
                        opening10 = true;
                        Room5_OpenCase5.StartCoroutine(Room5_OpenCase5.CaseOpen());
                    }
                }
                else if(opening10 == true)
                {
                    TextUI.text = "서랍을 닫으려면 (Z)키를 누르세요";
                    if (Input.GetKeyDown(KeyCode.Z))
                    {
                        Room5_OpenCase5.StartCoroutine(Room5_OpenCase5.CaseClose());
                        opening10 = false;
                    }
                }
            }
        }
    }
}
