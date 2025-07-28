using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Monitor : MonoBehaviour
{
    //필요한 컴포넌트
    
    [SerializeField]
    private GameObject Room1MQ;
    [SerializeField]
    private GameObject Room3MQ;
    [SerializeField]
    public GameObject Crosshair;
    [SerializeField]
    public GameObject Text_UI;
    [SerializeField]
    public TextMeshProUGUI TextUI;

    // bool값
    public bool Openscreen1 = false;
    public bool Openscreen2 = false;
    public bool IsTouch = false;

    public Door door;
    public Paper paper;
    public Case Case;
    public Metal metal;
    [SerializeField]
    PlayerController playerController;
    void Start()
    {

    }

    void Update()
    {
        TryOpenScreen();
        CloseText();
        TryOpenMetal();
    }


    //모니터 보기
    private void TryOpenScreen()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        IsTouch = Physics.Raycast(ray, out hit, 1.5f);
        if (IsTouch)
        {
            if (hit.transform.CompareTag("PC"))
            {
                TextUI.text = " 화면을 보려면 (Z)키를 누르세요";
                if (hit.transform.gameObject.name == ("PC_Monitor"))
                {
                    if (Input.GetKeyDown(KeyCode.Z))
                    {
                        playerController.SetCanMove(false);
                        Text_UI.SetActive(false);
                        Crosshair.SetActive(false);
                        Room1MQ.SetActive(true);
                        Openscreen1 = true;
                    }
                    else if (Openscreen1 == true)
                    {
                        if (Input.GetKeyDown(KeyCode.R))
                        {
                            playerController.SetCanMove(true);
                            Text_UI.SetActive(true);
                            Crosshair.SetActive(true);
                            Room1MQ.SetActive(false);
                            Openscreen1 = false;
                        }
                    }

                }

                else if (hit.transform.gameObject.name == ("TV_Retro"))
                {
                    if (Input.GetKeyDown(KeyCode.Z))
                    {
                        playerController.SetCanMove(false);
                        Text_UI.SetActive(false);
                        Crosshair.SetActive(false);
                        Room3MQ.SetActive(true);
                        Openscreen2 = true;
                    }
                    else if (Openscreen2 == true)
                    {
                        if (Input.GetKeyDown(KeyCode.R))
                        {
                            playerController.SetCanMove(true);
                            Text_UI.SetActive(true);
                            Crosshair.SetActive(true);
                            Room3MQ.SetActive(false);
                            Openscreen2 = false;
                        }
                    }

                }
            }
        }
    }

   
    //상호작용키 지우기
    public void CloseText()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        IsTouch = Physics.Raycast(ray, out hit, 1.5f);
        if (IsTouch)
        {
            if (!hit.transform.CompareTag("PC") && !hit.transform.CompareTag("Door") && !hit.transform.CompareTag("Paper") && !hit.transform.CompareTag("Case") && !hit.transform.CompareTag("Case") && !hit.transform.CompareTag("Item") && !hit.transform.CompareTag("Case") && !hit.transform.CompareTag("Metal"))
            {
                TextUI.text = " ";
            }
        }
        else
        {
            TextUI.text = "";
        }
    }


    private void TryOpenMetal()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        Debug.DrawRay(ray.origin, ray.direction * 1.5f, Color.yellow);
        RaycastHit hit;
        IsTouch = Physics.Raycast(ray, out hit, 1.5f);
        if (IsTouch)
        {
            if (hit.transform.CompareTag("Metal"))
            {
                metal.OpenMetal();

            }
        }
    }
}

