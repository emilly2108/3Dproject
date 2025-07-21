using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Monitor : MonoBehaviour
{
    //�ʿ��� ������Ʈ
    [SerializeField]
    private GameObject Room1_Monitor;
    [SerializeField]
    private GameObject Room1MQ;
    [SerializeField]
    private GameObject Crosshair;
    [SerializeField]
    private GameObject Text_UI;
    [SerializeField]
    public TextMeshProUGUI TextUI;

    // bool��
    private bool Openscreen = false;
    private bool IsTouch = false;
    private bool Opentext = false;

    public OpenDoor opendoor;
    public Paper paper;
    public Case Case;
    void Start()
    {

    }

    void Update()
    {
        TryOpenScreen();
        CloseText();
        TryCloseScreen();
        OpenPaper();
        TryOpenCase();
        TryOpenDoor();
    }


    //����� ����
    private void TryOpenScreen()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        IsTouch = Physics.Raycast(ray, out hit, 0.7f);
            if (IsTouch)
            {
                if(hit.transform.CompareTag("PC"))
                {
                    TextUI.text = " ȭ���� ������ (Z)Ű�� ��������";
                    Opentext = true;
                    if (Input.GetKeyDown(KeyCode.Z))
                        {
                            Text_UI.SetActive(false);
                            Crosshair.SetActive(false);
                            Room1MQ.SetActive(true);
                            Openscreen = true;
                        }
                    
                }
            }
    }

    //����� �ݱ�
    private void TryCloseScreen()
    {
        if(Openscreen == true)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                Text_UI.SetActive(true);
                Crosshair.SetActive(true);
                Room1MQ.SetActive(false);
                Openscreen = false;
            }
        }

    }

    //��ȣ�ۿ�Ű �����
    public void CloseText()
    {
        if (Opentext == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            IsTouch = Physics.Raycast(ray, out hit, 0.7f);
            if (IsTouch)
            {
                if (!hit.transform.CompareTag("PC") && !hit.transform.CompareTag("Door")  && !hit.transform.CompareTag("Paper")&&!hit.transform.CompareTag("Case"))
                {
                    TextUI.text = " ";
                    Opentext = false;
                }
            }
            else
            {
                TextUI.text = "";
                Opentext = false;
            }
        }
    }

    //���̺��� ��ȣ�ۿ�Ű ����
    private void OpenPaper()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        IsTouch = Physics.Raycast(ray, out hit, 0.7f);
        if (IsTouch)
        {
            if (hit.transform.CompareTag("Paper"))
            {
                TextUI.text = "���̸� ������ (Z)Ű�� ��������";
                Opentext = true;
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    paper.OpenPaper();
                    Text_UI.SetActive(false);
                    Crosshair.SetActive(false);
                }

            }
        }
    }

    //�繰�� ����
    private void TryOpenCase()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        Debug.DrawRay(ray.origin, ray.direction * 5f, Color.yellow);
        RaycastHit hit;
        IsTouch = Physics.Raycast(ray, out hit, 0.7f);
        if (IsTouch)
        {
            if (hit.transform.CompareTag("Case"))
            {
                TextUI.text = "������ ������ (Z)Ű�� ��������";
                Opentext = true;
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    Case.OpenCase();
                    Text_UI.SetActive(false);
                    Crosshair.SetActive(false);
                }

            }
        }
    }

    private void TryOpenDoor()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        IsTouch = Physics.Raycast(ray, out hit, 0.7f);
        if (IsTouch)
        {
            if (hit.transform.CompareTag("Door"))
            {
                TextUI.text = "���� ������ (Z)Ű�� ��������";
                Opentext = true;
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    if (hit.transform.gameObject.name == ("Room1_Door"))
                    {
                        opendoor.OpenDoor1();
                    }

                    else if (hit.transform.gameObject.name == ("Room2_Door"))
                    {
                        opendoor.OpenDoor2();
                    }

                    else if (hit.transform.gameObject.name == ("Room3_Door"))
                    {
                        opendoor.OpenDoor3();
                    }

                    else if (hit.transform.gameObject.name == ("Room4_Door"))
                    {
                        opendoor.OpenDoor4();
                    }

                    else if (hit.transform.gameObject.name == ("Room5_Door"))
                    {
                        opendoor.OpenDoor5();
                    }

                    else if (hit.transform.gameObject.name == ("Room6_Door"))
                    {
                        opendoor.OpenDoor6();
                    }

                    else if (hit.transform.gameObject.name == ("Room7_Door"))
                    {
                        opendoor.OpenDoor7();
                    }
                }

            }
        }
    }
}

