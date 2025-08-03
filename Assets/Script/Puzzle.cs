using UnityEngine;

public class Puzzle : MonoBehaviour
{
    [SerializeField]
    private GameObject puzzle1;
    [SerializeField]
    private GameObject puzzle2;
    [SerializeField]
    private GameObject puzzle3;
    [SerializeField]
    private GameObject puzzle4;

    //퍼즐 UI
    [SerializeField]
    private GameObject puzzle1_UI;
    [SerializeField]
    private GameObject puzzle2_UI;
    [SerializeField]
    private GameObject puzzle3_UI;
    [SerializeField]
    private GameObject puzzle4_UI;

    [SerializeField]
    private GameObject puzzle_UI;

    public bool Showing = false;
    private bool FullPuzzle = false;
    public Monitor monitor;
    public PlayerController playerController;
    void Start()
    {
        
    }

    void Update()
    {
        TryPuzzle();
    }

    public void Puzzle1()
    {
        puzzle1.SetActive(true);
        puzzle1_UI.SetActive(true);
    }
    public void Puzzle2()
    {
        puzzle2.SetActive(true);
        puzzle2_UI.SetActive(true);
    }
    public void Puzzle3()
    {
        puzzle3.SetActive(true);
        puzzle3_UI.SetActive(true);
    }
    public void Puzzle4()
    {
        puzzle4.SetActive(true);
        puzzle4_UI.SetActive(true);
    }

    private void  TryPuzzle()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        monitor.IsTouch = Physics.Raycast(ray, out hit, 1.5f);
        if (monitor.IsTouch)
            if (hit.transform.CompareTag("Puzzle") && FullPuzzle == false)
            {
                monitor.TextUI.text = "퍼즐을 맞추려면 (Z)키를 누르세요";
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    playerController.SetCanMove(false);
                    puzzle_UI.SetActive(true);
                    monitor.Text_UI.SetActive(false);
                    monitor.Crosshair.SetActive(false);
                    Showing = true;
                    
                }
                else if (Showing == true)
                {
                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        playerController.SetCanMove(true);
                        puzzle_UI.SetActive(false);
                        Showing = false;
                        monitor.Text_UI.SetActive(true);
                        monitor.Crosshair.SetActive(true);
                    }
                }
            }
    }
}
