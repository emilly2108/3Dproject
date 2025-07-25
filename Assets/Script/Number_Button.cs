using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Number_Button : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI number;

    private int currentNumber = 0;
    void Start()
    {
        currentNumber = 0;
        number.text = currentNumber.ToString();
    }

    void Update()
    {
        
    }

    public void OnButtonPressed()
    {
        Debug.Log("버튼1 눌림");
        currentNumber++;
        if (currentNumber >= 10)
        {
            currentNumber = 0;
        }

        number.text = currentNumber.ToString();
    }
}
