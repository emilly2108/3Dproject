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
        if (monitor.IsTouch)
        {
            if(hit.transform.CompareTag("Paper"))
            {
                monitor.TextUI.text = "종이를 보려면 (Z)키를 누르세요";

                if (hit.transform.gameObject.name == ("Room1_Paper1"))
                {
                    
                    if (Input.GetKeyDown(KeyCode.Z))
                    {
                        playerController.SetCanMove(false);
                        R1_Paper1.SetActive(true);
                        R1_Showing1 = true;
                        Text_UI.SetActive(false);
                        Crosshair.SetActive(false);
                    }
                    else if (R1_Showing1 == true)
                    {
                        if (Input.GetKeyDown(KeyCode.R))
                        {
                            playerController.SetCanMove(true);
                            R1_Paper1.SetActive(false);
                            R1_Showing1 = false;
                            Text_UI.SetActive(true);
                            Crosshair.SetActive(true);
                        }
                    }
                }

                else if (hit.transform.gameObject.name == ("Room3_Paper1 "))
                {
                    
                    if (Input.GetKeyDown(KeyCode.Z))
                    {

                        playerController.SetCanMove(false);
                        R3_Paper1.SetActive(true);
                        R3_Showing1 = true;
                        Text_UI.SetActive(false);
                        Crosshair.SetActive(false);
                    }
                    else if (R3_Showing1 == true)
                    {
                        if (Input.GetKeyDown(KeyCode.R))
                        {
                            playerController.SetCanMove(true);
                            R3_Paper1.SetActive(false);
                            R3_Showing1 = false;
                            Text_UI.SetActive(true);
                            Crosshair.SetActive(true);
                        }
                    }
                }

                else if (hit.transform.gameObject.name == ("Room3_Paper2"))
                {
                    
                    if (Input.GetKeyDown(KeyCode.Z))
                    {
                        playerController.SetCanMove(false);
                        R3_Paper2.SetActive(true);
                        R3_Showing2 = true;
                        Text_UI.SetActive(false);
                        Crosshair.SetActive(false);
                    }
                    else if (R3_Showing2 == true)
                    {
                        if (Input.GetKeyDown(KeyCode.R))
                        {
                            playerController.SetCanMove(true);
                            R3_Paper2.SetActive(false);
                            R3_Showing2 = false;
                            Text_UI.SetActive(true);
                            Crosshair.SetActive(true);
                        }
                    }
                }

                else if (hit.transform.gameObject.name == ("Room3_Paper3"))
                {
                    
                    if (Input.GetKeyDown(KeyCode.Z))
                    {
                        playerController.SetCanMove(false);
                        R3_Paper3.SetActive(true);
                        R3_Showing3 = true;
                        Text_UI.SetActive(false);
                        Crosshair.SetActive(false);
                    }
                    else if (R3_Showing3 == true)
                    {
                        if (Input.GetKeyDown(KeyCode.R))
                        {
                            playerController.SetCanMove(true);
                            R3_Paper3.SetActive(false);
                            R3_Showing3 = false;
                            Text_UI.SetActive(true);
                            Crosshair.SetActive(true);
                        }
                    }
                }
                else if (hit.transform.gameObject.name == ("Room3_Paper4"))
                {
                    
                    if (Input.GetKeyDown(KeyCode.Z))
                    {
                        playerController.SetCanMove(false);
                        R3_Paper4.SetActive(true);
                        R3_Showing4 = true;
                        Text_UI.SetActive(false);
                        Crosshair.SetActive(false);
                    }
                    else if (R3_Showing4 == true)
                    {
                        if (Input.GetKeyDown(KeyCode.R))
                        {
                            playerController.SetCanMove(true);
                            R3_Paper4.SetActive(false);
                            R3_Showing4 = false;
                            Text_UI.SetActive(true);
                            Crosshair.SetActive(true);
                        }
                    }
                }
                else if (hit.transform.gameObject.name == ("Room3_Paper5"))
                {
                    
                    if (Input.GetKeyDown(KeyCode.Z))
                    {
                        playerController.SetCanMove(false);
                        R3_Paper5.SetActive(true);
                        R3_Showing5 = true;
                        Text_UI.SetActive(false);
                        Crosshair.SetActive(false);
                    }
                    else if (R3_Showing5 == true)
                    {
                        if (Input.GetKeyDown(KeyCode.R))
                        {
                            playerController.SetCanMove(true);
                            R3_Paper5.SetActive(false);
                            R3_Showing5 = false;
                            Text_UI.SetActive(true);
                            Crosshair.SetActive(true);
                        }
                    }
                }
                else if (hit.transform.gameObject.name == ("Room3_Paper6"))
                {
                    if (Input.GetKeyDown(KeyCode.Z))
                    {
                        playerController.SetCanMove(false);
                        R3_Paper6.SetActive(true);
                        R3_Showing6 = true;
                        Text_UI.SetActive(false);
                        Crosshair.SetActive(false);
                    }
                    else if (R3_Showing6 == true)
                    {
                        if (Input.GetKeyDown(KeyCode.R))
                        {
                            playerController.SetCanMove(true);
                            R3_Paper6.SetActive(false);
                            R3_Showing6 = false;
                            Text_UI.SetActive(true);
                            Crosshair.SetActive(true);
                        }
                    }
                }
            }

        }
    }
            

    
}
