using UnityEngine;
using TMPro;
public class Chair : MonoBehaviour
{
    [SerializeField]
    PlayerController playerController;
    public Monitor monitor;

    [SerializeField]
    private GameObject Crosshair;
    [SerializeField]
    private GameObject Text_UI;
    [SerializeField]
    public TextMeshProUGUI TextUI;

    [SerializeField]
    private GameObject chair1;
    [SerializeField]
    private GameObject chair2;
    [SerializeField]
    private GameObject chair3;
    [SerializeField]
    private GameObject chair4;
    [SerializeField]
    private GameObject chair5;
    [SerializeField]
    private GameObject chair6;
    [SerializeField]
    private GameObject chair7;
    [SerializeField]
    private GameObject chair8;

    public bool Showing1 = false;
    public bool Showing2 = false;
    public bool Showing3 = false;
    public bool Showing4 = false;
    public bool Showing5 = false;
    public bool Showing6 = false;
    public bool Showing7 = false;
    public bool Showing8 = false;

    public bool ChairSolveing = false;
    void Start()
    {
        
    }

    void Update()
    {
        OpenChair();
    }
    public void OpenChair()
    {
        if(ChairSolveing == false)
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            monitor.IsTouch = Physics.Raycast(ray, out hit, 1.5f);

            if (!monitor.IsTouch || !hit.transform.CompareTag("Chair")) return;

            monitor.TextUI.text = "의자를 보려면 (Z)키를 누르세요";

            string chairName = hit.transform.gameObject.name.Trim();
            GameObject ChairObject = null;
            ref bool isShowing = ref Showing1;

            switch (chairName)
            {
                case "Chair1":
                    ChairObject = chair1;
                    isShowing = ref Showing1;
                    break;
                case "Chair2":
                    ChairObject = chair2;
                    isShowing = ref Showing2;
                    break;
                case "Chair3":
                    ChairObject = chair3;
                    isShowing = ref Showing3;
                    break;
                case "Chair4":
                    ChairObject = chair4;
                    isShowing = ref Showing4;
                    break;
                case "Chair5":
                    ChairObject = chair5;
                    isShowing = ref Showing5;
                    break;
                case "Chair6":
                    ChairObject = chair6;
                    isShowing = ref Showing6;
                    break;
                case "Chair7":
                    ChairObject = chair7;
                    isShowing = ref Showing7;
                    break;
                case "Chair8":
                    ChairObject = chair8;
                    isShowing = ref Showing8;
                    break;
            }

            if (Input.GetKeyDown(KeyCode.Z) && !isShowing)
            {
                playerController.SetCanMove(false);
                ChairObject.SetActive(true);
                isShowing = true;
                Text_UI.SetActive(false);
                Crosshair.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.R) && isShowing)
            {
                playerController.SetCanMove(true);
                ChairObject.SetActive(false);
                isShowing = false;
                Text_UI.SetActive(true);
                Crosshair.SetActive(true);
            }
        }
    }
        
}
