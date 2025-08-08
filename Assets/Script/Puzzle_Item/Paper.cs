using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Paper : MonoBehaviour
{
    [SerializeField]
    PlayerController playerController;
    public Monitor monitor;

    [SerializeField]
    private GameObject[] paper;
    public bool[] Showing;

    [SerializeField]
    private GameObject Crosshair;
    [SerializeField]
    private GameObject Text_UI;

    private Dictionary<string, int> paperNameIndex = new Dictionary<string, int>();

    void Start()
    {
        Showing = new bool[paper.Length];

        for (int i = 0; i < paper.Length; i++)
        {
            if (paper[i] != null)
            {
                string name = paper[i].name.Trim();
                if (!paperNameIndex.ContainsKey(name))
                {
                    paperNameIndex.Add(name, i);
                }
            }
        }
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

        monitor.TextUI.text = "종이를 볼려면 (Z)키를 누르세요";

        string paperName = hit.transform.gameObject.name.Trim();

        if (!paperNameIndex.TryGetValue(paperName, out int index)) return;

        if (Input.GetKeyDown(KeyCode.Z) && !Showing[index])
        {
            playerController.SetCanMove(false);
            paper[index].SetActive(true);
            Showing[index] = true;
            Text_UI.SetActive(false);
            Crosshair.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.R) && Showing[index])
        {
            playerController.SetCanMove(true);
            paper[index].SetActive(false);
            Showing[index] = false;
            Text_UI.SetActive(true);
            Crosshair.SetActive(true);
        }
    }
}