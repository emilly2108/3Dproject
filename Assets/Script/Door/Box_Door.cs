using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Box_Door : MonoBehaviour
{
    [SerializeField]
    PlayerController playerController;
    public Monitor monitor;

    [SerializeField]
    private GameObject[] Box_Doors;
    [SerializeField]
    private openBox_Door[] openBox_Door;
    public int numberofBox_Door = 4;

    public bool[] Show;
    public bool[] Solve;
    public bool[] opening;

    [SerializeField]
    private GameObject Crosshair;
    [SerializeField]
    private GameObject Text_UI;
    [SerializeField]
    public TextMeshProUGUI TextUI;

    [SerializeField]
    private string Box_DoorTag = "MorgueBox_Door";

    private Dictionary<string, int> Box_DoorNameIndex;
    void Start()
    {
        Show = new bool[numberofBox_Door];
        Solve = new bool[numberofBox_Door];
        opening = new bool[numberofBox_Door];
        Box_DoorNameIndex = new Dictionary<string, int>();

        for (int i = 0; i < Box_Doors.Length; i++)
        {
            string key = Box_Doors[i].name.Trim();
            Box_DoorNameIndex[key] = i;
        }
    }

    void Update()
    {
        OpenCase();
        CloseShow();
    }

    void OpenCase()
    {

        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        monitor.IsTouch = Physics.Raycast(ray, out hit, 1.5f);
        if (!Physics.Raycast(ray, out hit, 1.5f)) return;
        string Box_DoorName = hit.transform.name.Trim();

        if (!Box_DoorNameIndex.TryGetValue(Box_DoorName, out int index)) return;

        if (!monitor.IsTouch || !hit.transform.CompareTag("MorgueBox_Door")) return;

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
                    Box_Doors[index].SetActive(true);
                    Show[index] = true;
                    Text_UI.SetActive(false);
                    Crosshair.SetActive(false);
                }
                else
                {
                    openBox_Door[index].StartCoroutine(openBox_Door[index].DoorMoveOpen());
                    opening[index] = true;
                    playerController.SetCanMove(true);
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                openBox_Door[index].StartCoroutine(openBox_Door[index].DoorMoveClose());
                opening[index] = false;
            }
        }
    }

    void CloseShow()
    {
        for (int i = 0; i < numberofBox_Door - 1; i++)
        {
            if (Show[i] && Input.GetKeyDown(KeyCode.R))
            {
                CloseCase(i);
            }
        }
    }

    void CloseCase(int index)
    {
        playerController.SetCanMove(true);
        Box_Doors[index].SetActive(false);
        Show[index] = false;
        Text_UI.SetActive(true);
        Crosshair.SetActive(true);
    }
  
}