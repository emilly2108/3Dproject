using UnityEngine;

public class Metal : MonoBehaviour
{
    public Monitor monitor;
    [SerializeField]
    private GameObject before;
    [SerializeField]
    private GameObject after;

    public bool Clear;
    public bool Show_before;
    public bool Show_after;
    [SerializeField]
    PlayerController playerController;
    void Start()
    {

    }
    void Update()
    {
        OpenMetal();
    }

    public void OpenMetal()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        monitor.IsTouch = Physics.Raycast(ray, out hit, 1.5f);
        if (monitor.IsTouch)
            if (hit.transform.CompareTag("Metal"))
            {
                monitor.TextUI.text = "철판을 보려면 (Z)키를 누르세요";
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    if (Clear == false)
                    {
                        playerController.SetCanMove(false);
                        before.SetActive(true);
                        Show_before = true;
                        monitor.Text_UI.SetActive(false);
                        monitor.Crosshair.SetActive(false);

                    }
                    else if(Clear == true)
                    {
                        playerController.SetCanMove(false);
                        after.SetActive(true);
                        Show_after = true;
                        monitor.Text_UI.SetActive(false);
                        monitor.Crosshair.SetActive(false);
                    }
                }
                else if (Show_before == true || Show_after == true)
                {
                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        playerController.SetCanMove(true);
                        before.SetActive(false);
                        after.SetActive(false);
                        Show_before = false;
                        Show_after = false;
                        monitor.Text_UI.SetActive(true);
                        monitor.Crosshair.SetActive(true);
                    }
                }
            }
    }
    public void ClearMetal()
    {
        if(Show_before == true)
        {
            before.SetActive(false);
            Show_before = false;
            after.SetActive(true);
            Show_after = true;
            Clear = true;
        }
    }
}
