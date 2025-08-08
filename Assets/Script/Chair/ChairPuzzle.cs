using UnityEngine;
using TMPro;


public class ChairPuzzle : MonoBehaviour
{
    [SerializeField]
    PlayerController playerController;
    public Case Case;
    public Chair Chair;
    [SerializeField]
    private GameObject Crosshair;
    [SerializeField]
    private GameObject Text_UI;
    [SerializeField]
    private TextMeshProUGUI Chair1text1;
    [SerializeField]
    private TextMeshProUGUI Chair1text2;
    [SerializeField]
    private TextMeshProUGUI Chair1text3;
    [SerializeField]
    private TextMeshProUGUI Chair1text4;
    [SerializeField]
    private TextMeshProUGUI Chair1text5;
    [SerializeField]
    private TextMeshProUGUI Chair1text6;
    [SerializeField]
    private TextMeshProUGUI Chair1text7;
    [SerializeField]
    private TextMeshProUGUI Chair1text8;
    [SerializeField]
    private GameObject chair1;
    [SerializeField]
    private GameObject chair2;
    [SerializeField]
    private GameObject chair3;
    [SerializeField]
    private GameObject chair4;
    [SerializeField]
    private GameObject chair5;
    [SerializeField]
    private GameObject chair6;
    [SerializeField]
    private GameObject chair7;
    [SerializeField]
    private GameObject chair8;
    void Start()
    {
        
    }

    void Update()
    {
        ChairButton();
    }
    private void ChairButton()
    {
        string num1 = Chair1text1.text;
        string num2 = Chair1text2.text;
        string num3 = Chair1text3.text;
        string num4 = Chair1text4.text;
        string num5 = Chair1text5.text;
        string num6 = Chair1text6.text;
        string num7 = Chair1text7.text;
        string num8 = Chair1text8.text;
        if (num1 == "D" && num2 == ""&& num3 == "L" && num4 == "N" && num5 == "D"&& num6 == "T"&& num7 == ""&& num8 == "")
        {
            Case.Solve[9] = true;
            Chair.ChairSolveing = true;
            Text_UI.SetActive(true);
            Crosshair.SetActive(true);
            playerController.SetCanMove(true);
            chair1.SetActive(false);
            chair2.SetActive(false);
            chair3.SetActive(false);
            chair4.SetActive(false);
            chair5.SetActive(false);
            chair6.SetActive(false);
            chair7.SetActive(false);
            chair8.SetActive(false);
        }
        else
        {
            Case.Solve[9] = false;
        }
    }

}
