using UnityEngine;

public class Metal : MonoBehaviour
{
    public Monitor monitor;
    [SerializeField]
    private GameObject before;
    [SerializeField]
    private GameObject after;

    public bool Clear;
    private bool Show_before;
    private bool Show_After;
    [SerializeField]
    PlayerController playerController;
    void Start()
    {

    }
    void Update()
    {

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
                }
                else if (Show_before == true)
                {
                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        playerController.SetCanMove(true);
                        before.SetActive(false);
                        Show_before = false;
                        monitor.Text_UI.SetActive(true);
                        monitor.Crosshair.SetActive(true);
                    }
                }
            }
    }
}
