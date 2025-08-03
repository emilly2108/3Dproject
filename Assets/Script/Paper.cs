using UnityEngine;
using UnityEngine.UI;

public class Paper : MonoBehaviour
{
    [SerializeField] 
    PlayerController playerController;
    public Monitor monitor;

    [SerializeField]
    private GameObject R1_Paper1;
    [SerializeField]
    private GameObject R3_Paper1;
    [SerializeField]
    private GameObject R3_Paper2;
    [SerializeField]
    private GameObject R3_Paper3;
    [SerializeField]
    private GameObject R3_Paper4;
    [SerializeField]
    private GameObject R3_Paper5;
    [SerializeField]
    private GameObject R3_Paper6;
    [SerializeField]
    private GameObject R3_Paper7;
    [SerializeField]
    private GameObject R4_Paper1;
    [SerializeField]
    private GameObject R4_Paper2;
    [SerializeField]
    private GameObject R4_Paper3;
    [SerializeField]
    private GameObject R4_Paper4;
    [SerializeField]
    private GameObject R4_Paper5;
    [SerializeField]
    private GameObject R5_Paper1;
    [SerializeField]
    private GameObject R5_Paper2;
    [SerializeField]
    private GameObject R5_Paper3;
    [SerializeField]
    private GameObject R5_Paper4;
    [SerializeField]
    private GameObject R5_Paper5;

    [SerializeField]
    private GameObject Crosshair;
    [SerializeField]
    private GameObject Text_UI;


    private bool R1_Showing1 = false;
    private bool R3_Showing1 = false;
    private bool R3_Showing2 = false;
    private bool R3_Showing3 = false;
    private bool R3_Showing4 = false;
    private bool R3_Showing5 = false;
    private bool R3_Showing6 = false;
    private bool R3_Showing7 = false;
    private bool R4_Showing1 = false;
    private bool R4_Showing2 = false;
    private bool R4_Showing3 = false;
    private bool R4_Showing4 = false;
    private bool R4_Showing5 = false;
    private bool R5_Showing1 = false;
    private bool R5_Showing2 = false;
    private bool R5_Showing3 = false;
    private bool R5_Showing4 = false;
    private bool R5_Showing5 = false;

    void Start()
    {

    }

    void Update()
    {
        OpenPaper();
        
    }

    public void OpenPaper()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        monitor.IsTouch = Physics.Raycast(ray, out hit, 1.5f);

        if (!monitor.IsTouch || !hit.transform.CompareTag("Paper")) return;

        monitor.TextUI.text = "종이를 보려면 (Z)키를 누르세요";

        string paperName = hit.transform.gameObject.name.Trim();
        GameObject paperObject = null;
        ref bool isShowing = ref R1_Showing1; 

        switch (paperName)
        {
            case "Room1_Paper1":
                paperObject = R1_Paper1;
                isShowing = ref R1_Showing1;
                break;
            case "Room3_Paper1":
                paperObject = R3_Paper1;
                isShowing = ref R3_Showing1;
                break;
            case "Room3_Paper2":
                paperObject = R3_Paper2;
                isShowing = ref R3_Showing2;
                break;
            case "Room3_Paper3":
                paperObject = R3_Paper3;
                isShowing = ref R3_Showing3;
                break;
            case "Room3_Paper4":
                paperObject = R3_Paper4;
                isShowing = ref R3_Showing4;
                break;
            case "Room3_Paper5":
                paperObject = R3_Paper5;
                isShowing = ref R3_Showing5;
                break;
            case "Room3_Paper6":
                paperObject = R3_Paper6;
                isShowing = ref R3_Showing6;
                break;
            case "Room3_Paper7":
                paperObject = R3_Paper7;
                isShowing = ref R3_Showing7;
                break;
            case "Room4_Paper1":
                paperObject = R4_Paper1;
                isShowing = ref R4_Showing1;
                break;
            case "Room4_Paper2":
                paperObject = R4_Paper2;
                isShowing = ref R4_Showing2;
                break;
            case "Room4_Paper3":
                paperObject = R4_Paper3;
                isShowing = ref R4_Showing3;
                break;
            case "Room4_Paper4":
                paperObject = R4_Paper4;
                isShowing = ref R4_Showing4;
                break;
            case "Room4_Paper5":
                paperObject = R4_Paper5;
                isShowing = ref R4_Showing5;
                break;
            case "Room5_Paper1":
                paperObject = R5_Paper1;
                isShowing = ref R5_Showing1;
                break;
            case "Room5_Paper2":
                paperObject = R5_Paper2;
                isShowing = ref R5_Showing2;
                break;
            case "Room5_Paper3":
                paperObject = R5_Paper3;
                isShowing = ref R5_Showing3;
                break;
            case "Room5_Paper4":
                paperObject = R5_Paper4;
                isShowing = ref R5_Showing4;
                break;
            case "Room5_Paper5":
                paperObject = R5_Paper5;
                isShowing = ref R5_Showing5;
                break;
        }

        if (Input.GetKeyDown(KeyCode.Z) && !isShowing)
        {
            playerController.SetCanMove(false);
            paperObject.SetActive(true);
            isShowing = true;
            Text_UI.SetActive(false);
            Crosshair.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.R) && isShowing)
        {
            playerController.SetCanMove(true);
            paperObject.SetActive(false);
            isShowing = false;
            Text_UI.SetActive(true);
            Crosshair.SetActive(true);
        }
    }


}
