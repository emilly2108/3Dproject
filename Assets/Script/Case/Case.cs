using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Case : MonoBehaviour
{
    [SerializeField]
    PlayerController playerController;
    [SerializeField]
    private GameObject case1;
    [SerializeField]
    private GameObject case2;
    [SerializeField]
    private GameObject case3;
    [SerializeField]
    private GameObject case4;
    [SerializeField]
    private GameObject case5;


    [SerializeField]
    private GameObject Crosshair;
    [SerializeField]
    private GameObject Text_UI;
    [SerializeField]
    public TextMeshProUGUI TextUI;
    private bool IsTouch = false;

    //자물쇠 화면
    public bool Showing1 = false;
    public bool Showing2 = false;
    public bool Showing3 = false;
    public bool Showing4 = false;
    public bool Showing5 = false;


    // 퀴즈 해결 판단
    public bool Solve1 = false;
    public bool Solve2 = false;
    public bool Solve3 = false;
    public bool Solve4 = false;
    public bool Solve5 = false;
    private bool Solve6 = false;

    // 문 열림 판단
    private bool Opening1 = false;
    private bool Opening2 = false;
    private bool Opening3 = false;
    private bool Opening4 = false;
    private bool Opening5 = false;
    private bool Opening6 = false;
    private bool Opening7 = false;

    //case열기스크립트 받기
    [SerializeField]
    private OpenCase Room1_OpenCase1;
    [SerializeField]
    private OpenCase Room1_OpenCase2;
    [SerializeField]
    private OpenCase Room3_OpenCase1;
    [SerializeField]
    private OpenCase Room3_OpenCase2;
    [SerializeField]
    private OpenCase Room3_OpenCase3;
    void Start()
    {

    }


    void Update()
    {
        OpenCase();
        CloseShow();
    }
    public void OpenCase()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        IsTouch = Physics.Raycast(ray, out hit, 1.5f);
        if (IsTouch)
        {
            if (hit.transform.CompareTag("Case"))
            {
                if (hit.transform.gameObject.name == ("Room1_Case1"))
                {
                    if (Opening1 == false)
                    {
                        TextUI.text = "서랍을 열려면 (Z)키를 누르세요";
                        if (Input.GetKeyDown(KeyCode.Z))
                        {
                            playerController.SetCanMove(false);
                            if (Solve1 == false)
                            {
                                case1.SetActive(true);
                                Showing1 = true;
                                Text_UI.SetActive(false);
                                Crosshair.SetActive(false);
                            }

                            else if (Solve1 == true)
                            {
                                Room1_OpenCase1.StartCoroutine(Room1_OpenCase1.CaseOpen());
                                Opening1 = true;
                                playerController.SetCanMove(true);
                            }
                        }
                    }

                    else if (Opening1 == true)
                    {
                        TextUI.text = "서랍을 닫으려면 (Z)키를 누르세요";
                        if (Input.GetKeyDown(KeyCode.Z))
                        {
                            Room1_OpenCase1.StartCoroutine(Room1_OpenCase1.CaseClose());
                            Opening1 = false;
                        }
                    }


                }

                else if (hit.transform.gameObject.name == ("Room1_Case2"))
                {
                    if (Opening2 == false)
                    {
                        TextUI.text = "서랍을 열려면 (Z)키를 누르세요";
                        if (Input.GetKeyDown(KeyCode.Z))
                        {
                            if (Solve2 == false)
                            {
                                playerController.SetCanMove(false);
                                case2.SetActive(true);
                                Showing2 = true;
                                Text_UI.SetActive(false);
                                Crosshair.SetActive(false);
                            }

                            else if (Solve2 == true)
                            {
                                Room1_OpenCase2.StartCoroutine(Room1_OpenCase2.CaseOpen());
                                Opening2 = true;
                                playerController.SetCanMove(true);
                            }
                        }
                    }

                    else if (Opening2 == true)
                    {
                        TextUI.text = "서랍을 닫으려면 (Z)키를 누르세요";
                        if (Input.GetKeyDown(KeyCode.Z))
                        {
                            Room1_OpenCase2.StartCoroutine(Room1_OpenCase2.CaseClose());
                            Opening2 = false;
                        }
                    }

                }

                else if (hit.transform.gameObject.name == ("Room3_case1"))
                {

                    if (Opening3 == false)
                    {
                        TextUI.text = "서랍을 열려면 (Z)키를 누르세요";
                        if (Input.GetKeyDown(KeyCode.Z))
                        {
                            playerController.SetCanMove(false);
                            if (Solve3 == false)
                            {
                                
                                case3.SetActive(true);
                                Showing3 = true;
                                Text_UI.SetActive(false);
                                Crosshair.SetActive(false);
                            }

                            else if (Solve3 == true)
                            {
                                Room3_OpenCase1.StartCoroutine(Room3_OpenCase1.CaseOpen());
                                Opening3 = true;
                                playerController.SetCanMove(true);
                            }
                        }
                    }

                    else if (Opening3 == true)
                    {
                        TextUI.text = "서랍을 닫으려면 (Z)키를 누르세요";
                        if (Input.GetKeyDown(KeyCode.Z))
                        {
                            Room3_OpenCase1.StartCoroutine(Room3_OpenCase1.CaseClose());
                            Opening3 = false;
                        }
                    }

                }
                else if (hit.transform.gameObject.name == ("Room3_case2"))
                {

                    if (Opening4 == false)
                    {
                        TextUI.text = "서랍을 열려면 (Z)키를 누르세요";
                        if (Input.GetKeyDown(KeyCode.Z))
                        {
                            playerController.SetCanMove(false);
                            if (Solve4 == false)
                            {
                                
                                case4.SetActive(true);
                                Showing4 = true;
                                Text_UI.SetActive(false);
                                Crosshair.SetActive(false);
                            }

                            else if (Solve4 == true)
                            {
                                Room3_OpenCase2.StartCoroutine(Room3_OpenCase2.CaseOpen());
                                Opening4 = true;
                                playerController.SetCanMove(true);
                            }
                        }
                    }

                    else if (Opening4 == true)
                    {
                        TextUI.text = "서랍을 닫으려면 (Z)키를 누르세요";
                        if (Input.GetKeyDown(KeyCode.Z))
                        {
                            Room3_OpenCase2.StartCoroutine(Room3_OpenCase2.CaseClose());
                            Opening4 = false;
                        }
                    }

                }
                else if (hit.transform.gameObject.name == ("Room3_case3"))
                {

                    if (Opening5 == false)
                    {
                        TextUI.text = "서랍을 열려면 (Z)키를 누르세요";
                        if (Input.GetKeyDown(KeyCode.Z))
                        {
                            if (Solve5 == false)
                            {
                                playerController.SetCanMove(false);
                                case5.SetActive(true);
                                Showing5 = true;
                                Text_UI.SetActive(false);
                                Crosshair.SetActive(false);
                            }

                            else if (Solve5 == true)
                            {
                                Room3_OpenCase3.StartCoroutine(Room3_OpenCase3.CaseOpen());
                                Opening5 = true;
                                playerController.SetCanMove(true);
                            }
                        }
                    }

                    else if (Opening5 == true)
                    {
                        TextUI.text = "서랍을 닫으려면 (Z)키를 누르세요";
                        if (Input.GetKeyDown(KeyCode.Z))
                        {
                            Room3_OpenCase3.StartCoroutine(Room3_OpenCase3.CaseClose());
                            Opening5 = false;
                        }
                    }

                }
            }
        }
    }
        

    private void CloseShow()
    {
        if (Showing1 == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                playerController.SetCanMove(true);
                case1.SetActive(false);
                Showing1 = false;
                Text_UI.SetActive(true);
                Crosshair.SetActive(true);
            }
        }

        else if (Showing2 == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                playerController.SetCanMove(true);
                case2.SetActive(false);
                Showing2 = false;
                Text_UI.SetActive(true);
                Crosshair.SetActive(true);
            }
        }
        else if (Showing3 == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                playerController.SetCanMove(true);
                case3.SetActive(false);
                Showing3 = false;
                Text_UI.SetActive(true);
                Crosshair.SetActive(true);
            }
        }
        else if (Showing4 == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                playerController.SetCanMove(true);
                case4.SetActive(false);
                Showing4 = false;
                Text_UI.SetActive(true);
                Crosshair.SetActive(true);
            }
        }
        else if (Showing5 == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                playerController.SetCanMove(true);
                case5.SetActive(false);
                Showing5 = false;
                Text_UI.SetActive(true);
                Crosshair.SetActive(true);
            }
        }
    }


}
