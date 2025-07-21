using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpenDoor : MonoBehaviour
{
    // 문 오브젝트 입력
    [SerializeField]
    private GameObject Room1_Door;
    [SerializeField]
    private GameObject Room2_Door;
    [SerializeField]
    private GameObject Room3_Door;
    [SerializeField]
    private GameObject Room4_Door;
    [SerializeField]
    private GameObject Room5_Door;
    [SerializeField]
    private GameObject Room6_Door;
    [SerializeField]
    private GameObject Room7_Door;

    // 문 퀴즈 오브젝트 입력
    [SerializeField]
    private GameObject Room1_DoorQ;
    [SerializeField]
    private GameObject Room2_DoorQ;
    [SerializeField]
    private GameObject Room3_DoorQ;
    [SerializeField]
    private GameObject Room4_DoorQ;
    [SerializeField]
    private GameObject Room5_DoorQ;
    [SerializeField]
    private GameObject Room6_DoorQ;
    [SerializeField]
    private GameObject Room7_DoorQ;

    // 문열림 판단
    private bool Opening1=false;
    private bool Opening2 = false;
    private bool Opening3 = false;
    private bool Opening4 = false;
    private bool Opening5 = false;
    private bool Opening6 = false;
    private bool Opening7 = false;

    // 문열림 판단
    private bool Show1 = false;
    private bool Show2 = false;
    private bool Show3 = false;
    private bool Show4 = false;
    private bool Show5 = false;
    private bool Show6 = false;
    private bool Show7 = false;

    [SerializeField]
    private GameObject Crosshair;
    [SerializeField]
    private GameObject Text_UI;
    // 도움말 UI
    [SerializeField]
    private TextMeshProUGUI TextUI;

    private bool Opentext = false;
    private bool IsTouch = false;

    Monitor monitor;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Tryroom1();
    }

    //문 여는 자물쇠 띄우기
    
    public void OpenDoor1()
    {
        if(Opening1 == false)
        {
            Room1_DoorQ.SetActive(true);
            Show1 = true;
            Text_UI.SetActive(false);
            Crosshair.SetActive(false);
        }

        if (Opening1 == true)
        {
            DoorMove();
        }
    }

    //문 여는 자물쇠 끄기
    private void Tryroom1()
    {
        if(Show1 == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Room1_DoorQ.SetActive(false);
                Show1 = false;
                Text_UI.SetActive(true);
                Crosshair.SetActive(true);
            }
        }
    }

    public void OpenDoor2()
    {
        if (Opening2 == false)
        {

        }

        if (Opening2 == true)
        {
            DoorMove();
        }
    }

    public void OpenDoor3()
    {
        if (Opening3 == false)
        {

        }

        if (Opening3 == true)
        {
            DoorMove();
        }
    }
    public void OpenDoor4()
    {
        if (Opening4 == false)
        {

        }

        if (Opening4 == true)
        {
            DoorMove();
        }
    }
    public void OpenDoor5()
    {
        if (Opening5 == false)
        {

        }

        if (Opening5 == true)
        {
            DoorMove();
        }
    }
    public void OpenDoor6()
    {
        if (Opening6 == false)
        {

        }

        if (Opening6 == true)
        {
            DoorMove();
        }
    }
    public void OpenDoor7()
    {
        if (Opening7 == false)
        {

        }

        if (Opening7 == true)
        {
            DoorMove();
        }
    }

    private void DoorMove()
    {

    }
}

