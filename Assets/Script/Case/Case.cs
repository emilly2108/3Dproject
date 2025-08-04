using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Case : MonoBehaviour
{
    [SerializeField] 
    PlayerController playerController;
    public Monitor monitor;

    [SerializeField] 
    private GameObject[] cases;
    [SerializeField] 
    private OpenCase[] openCases;
    public int numberofCase = 10;

    private bool opening9 = false;

    public bool[] Showing;
    public bool[] Solve;
    public bool[] opening;

    [SerializeField] 
    private GameObject Crosshair;
    [SerializeField] 
    private GameObject Text_UI;
    [SerializeField] 
    public TextMeshProUGUI TextUI;

    [SerializeField]
    private string caseTag = "Case";

    private Dictionary<string, int> caseNameIndex;
    void Start()
    {
        Showing = new bool[numberofCase];
        Solve = new bool[numberofCase];
        opening = new bool[numberofCase];
        caseNameIndex = new Dictionary<string, int>();

        for (int i = 0; i < cases.Length; i++)
        {
            string key = cases[i].name.Trim();
            caseNameIndex[key] = i;
        }
    }

    void Update()
    {
        OpenCase();
        CloseShow();
        HandleCase10();
    }
    
    void OpenCase()
    {

        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        monitor.IsTouch = Physics.Raycast(ray, out hit, 1.5f);
        if (!Physics.Raycast(ray, out hit, 1.5f)) return;  
        string caseName = hit.transform.name.Trim();

        if (!caseNameIndex.TryGetValue(caseName, out int index)) return;
       
        if (!monitor.IsTouch || !hit.transform.CompareTag("Case")) return;

        monitor.IsTouch = true;
        if (opening[index])
        {
            TextUI.text = "서랍을 닫으려면 (Z)키를 누르세요";
        }
        else
        {
            TextUI.text = "서랍을 열려면 (Z)키를 누르세요";
        }
        if (!opening[index])
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (!Solve[index])
                {
                    playerController.SetCanMove(false);
                    cases[index].SetActive(true);
                    Showing[index] = true;
                    Text_UI.SetActive(false);
                    Crosshair.SetActive(false);
                }
                else
                {
                    openCases[index].StartCoroutine(openCases[index].CaseOpen());
                    opening[index] = true;
                    playerController.SetCanMove(true);
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                openCases[index].StartCoroutine(openCases[index].CaseClose());
                opening[index] = false;
            }
        }
    }

    void CloseShow()
    {
        for (int i = 0; i < numberofCase - 1; i++)
        {
            if (Showing[i] && Input.GetKeyDown(KeyCode.R))
            {
                CloseCase(i);
            }
        }
    }

    void CloseCase(int index)
    {
        playerController.SetCanMove(true);
        cases[index].SetActive(false); 
        Showing[index] = false;
        Text_UI.SetActive(true);
        Crosshair.SetActive(true);
    }
    private void HandleCase10()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        if (!Physics.Raycast(ray, out RaycastHit hit, 1.5f)) return;
        if (hit.transform.name != "Room5_case5") return;

        if (!Solve[9]) return; 

        TextUI.text = opening9 ? "서랍을 닫으려면 (Z)키를 누르세요" : "서랍을 열려면 (Z)키를 누르세요";

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (!opening9)
            {
                openCases[9].StartCoroutine(openCases[9].CaseOpen());
            }
            else
            {
                openCases[9].StartCoroutine(openCases[9].CaseClose());
            }
            opening9 = !opening9;
        }

    }
}
