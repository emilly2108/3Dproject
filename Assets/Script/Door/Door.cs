using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Door : MonoBehaviour
{
    [SerializeField]
    PlayerController playerController;

    // 문 오브젝트 입력
    [SerializeField]
    private GameObject Room1_Door;
    [SerializeField]
    private GameObject Room2_Door;
    [SerializeField]
    private GameObject Room3_Door;
    [SerializeField]
    private GameObject Room4_Door;
    [SerializeField]
    private GameObject Room5_Door;
    [SerializeField]
    private GameObject Room6_Door;
    [SerializeField]
    private GameObject Room7_Door;

    [SerializeField]
    private GameObject Bath1_Door;
    [SerializeField]
    private GameObject Bath2_Door;
    [SerializeField]
    private GameObject Bath3_Door;
    [SerializeField]
    private GameObject Bath4_Door;
    [SerializeField]
    private GameObject Bath5_Door;
    [SerializeField]
    private GameObject Bath6_Door;

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

    // 문 열림 판단
    private bool Opening1 = false;
    private bool Opening2 = false;
    private bool Opening3 = false;
    private bool Opening4 = false;
    private bool Opening5 = false;
    private bool Opening6 = false;
    private bool Opening7 = false;

    private bool BOpening1 = false;
    private bool BOpening2 = false;
    private bool BOpening3 = false;
    private bool BOpening4 = false;
    private bool BOpening5 = false;
    private bool BOpening6 = false;

    // 문 퀴즈 해결 판단
    public bool Solve1 = false;
    public bool Solve3 = false;
    public bool Solve4 = false;
    public bool Solve5 = false;
    public bool Solve6 = false;
    public bool Solve7 = false;

    // 문 퀴즈 나타났는지 판단
    public bool Show1 = false;
    public bool Show3 = false;
    public bool Show4 = false;
    public bool Show5 = false;
    public bool Show6 = false;
    public bool Show7 = false;

    [SerializeField]
    private OpenDoor Room1_OpenDoor;
    [SerializeField]
    private OpenDoor Room2_OpenDoor;
    [SerializeField]
    private OpenDoor Room3_OpenDoor;
    [SerializeField]
    private OpenDoor Room4_OpenDoor;
    [SerializeField]
    private OpenDoor Room5_OpenDoor;
    [SerializeField]
    private OpenDoor Room6_OpenDoor;
    [SerializeField]
    private OpenDoor Room7_OpenDoor;


    [SerializeField]
    private OpenDoor Bath1_OpenDoor;
    [SerializeField]
    private OpenDoor Bath2_OpenDoor;
    [SerializeField]
    private OpenDoor Bath3_OpenDoor;
    [SerializeField]
    private OpenDoor Bath4_OpenDoor;
    [SerializeField]
    private OpenDoor Bath5_OpenDoor;
    [SerializeField]
    private OpenDoor Bath6_OpenDoor;
    // UI
    [SerializeField]
    private GameObject Crosshair;
    [SerializeField]
    private GameObject Text_UI;
    [SerializeField]
    private TextMeshProUGUI TextUI;

    //문 접촉 판단
    private bool IsTouch = false;
    [SerializeField]
    OpenDoor opendoor;
    void Start()
    {

    }


    void Update()
    {

        TryOpen();
    }

    public void TryOpen()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        IsTouch = Physics.Raycast(ray, out hit, 1.5f);
        if (!IsTouch || !hit.transform.CompareTag("Door")) return;

        string doorName = hit.transform.gameObject.name.Trim();

        switch (doorName)
        {
            case "Room1_Door":
                PuzzleDoor(ref Opening1, ref Show1, Solve1, Room1_DoorQ, Room1_OpenDoor);
                break;
            case "Room2_Door":
                door(ref Opening2, Room2_OpenDoor);
                break;
            case "Room3_Door":
                PuzzleDoor(ref Opening3, ref Show3, Solve3, Room3_DoorQ, Room3_OpenDoor);
                break;
            case "Room4_Door":
                PuzzleDoor(ref Opening4, ref Show4, Solve4, Room4_DoorQ, Room4_OpenDoor);
                break;
            case "Room5_Door":
                PuzzleDoor(ref Opening5, ref Show5, Solve5, Room5_DoorQ, Room5_OpenDoor);
                break;
            case "Room6_Door":
                PuzzleDoor(ref Opening6, ref Show6, Solve6, Room6_DoorQ, Room6_OpenDoor);
                break;
            case "Room7_Door":
                PuzzleDoor(ref Opening7, ref Show7, Solve7, Room7_DoorQ, Room7_OpenDoor);
                break;
            case "ToiletDoor1":
                door(ref BOpening1, Bath1_OpenDoor);
                break;
            case "ToiletDoor2":
                door(ref BOpening2, Bath2_OpenDoor);
                break;
            case "ToiletDoor3":
                door(ref BOpening3, Bath3_OpenDoor);
                break;
            case "ToiletDoor4":
                door(ref BOpening4, Bath4_OpenDoor);
                break;
            case "ToiletDoor5":
                door(ref BOpening5, Bath5_OpenDoor);
                break;
            case "ToiletDoor6":
                door(ref BOpening6, Bath6_OpenDoor);
                break;
        }
    }

    private void PuzzleDoor(ref bool isOpen, ref bool isShow, bool isSolved, GameObject quizUI, OpenDoor door)
    {
        if (!isOpen)
        {
            if (isShow)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    playerController.SetCanMove(true);
                    quizUI.SetActive(false);
                    isShow = false;
                    Text_UI.SetActive(true);
                    Crosshair.SetActive(true);
                }
            }
            TextUI.text = "문을 열려면 (Z)키를 누르세요";
            if (Input.GetKeyDown(KeyCode.Z))
            {
                playerController.SetCanMove(false);
                if (!isSolved)
                {
                    quizUI.SetActive(true);
                    isShow = true;
                    Text_UI.SetActive(false);
                    Crosshair.SetActive(false);
                }
                else
                {
                    playerController.SetCanMove(true);
                    door.StartCoroutine(door.DoorMoveOpen());
                    isOpen = true;
                }
            }
        }
        
        else
        {
            TextUI.text = "문을 닫으려면 (Z)키를 누르세요";
            if (Input.GetKeyDown(KeyCode.Z))
            {
                door.StartCoroutine(door.DoorMoveClose());
                isOpen = false;
            }
        }
    }

    private void door(ref bool isOpen, OpenDoor door)
    {
        if (!isOpen)
        {
            TextUI.text = "문을 열려면 (Z)키를 누르세요";
            if (Input.GetKeyDown(KeyCode.Z))
            {
                door.StartCoroutine(door.DoorMoveOpen());
                isOpen = true;
            }
        }
        else
        {
            TextUI.text = "문을 닫으려면 (Z)키를 누르세요";
            if (Input.GetKeyDown(KeyCode.Z))
            {
                door.StartCoroutine(door.DoorMoveClose());
                isOpen = false;
            }
        }
    }

}