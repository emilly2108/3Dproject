using UnityEngine;

public class Luminol_Paper : MonoBehaviour
{
    public Monitor monitor;
    [SerializeField]
    private GameObject before;
    [SerializeField]
    private GameObject after;

    public bool Clear_Paper;
    public bool Paper_before;
    public bool Paper_after;
    [SerializeField]
    PlayerController playerController;
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
            if (hit.transform.CompareTag("Luminol_Paper"))
            {
                monitor.TextUI.text = "종이을 보려면 (Z)키를 누르세요";
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    if (Clear_Paper == false)
                    {
                        playerController.SetCanMove(false);
                        before.SetActive(true);
                        Paper_before = true;
                        monitor.Text_UI.SetActive(false);
                        monitor.Crosshair.SetActive(false);

                    }
                    else if (Clear_Paper == true)
                    {
                        playerController.SetCanMove(false);
                        after.SetActive(true);
                        Paper_after = true;
                        monitor.Text_UI.SetActive(false);
                        monitor.Crosshair.SetActive(false);
                    }
                }
                else if (Paper_before == true || Paper_after == true)
                {
                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        playerController.SetCanMove(true);
                        before.SetActive(false);
                        after.SetActive(false);
                        Paper_before = false;
                        Paper_after = false;
                        monitor.Text_UI.SetActive(true);
                        monitor.Crosshair.SetActive(true);
                    }
                }
            }
    }
    public void ClearPaper()
    {
        if (Paper_before == true)
        {
            before.SetActive(false);
            Paper_before = false;
            after.SetActive(true);
            Paper_after = true;
            Clear_Paper = true;
        }
    }
}
