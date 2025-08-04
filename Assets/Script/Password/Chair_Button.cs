using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChairButton : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI alphabet2;

    private int currentNumber2 = 0;
    private string currentAlphabet2 = " ";
    void Start()
    {
        currentNumber2 = 0;
        alphabet2.text = currentAlphabet2.ToString();
    }

    void Update()
    {
        Alphabet2();
    }

    public void OnButtonPressed()
    {
        currentNumber2++;
        if (currentNumber2 >= 5)
        {
            currentNumber2 = 0;
        }
    }

    private void Alphabet2()
    {
        if (currentNumber2  == 0)
        {
            currentAlphabet2 = " ";
            alphabet2.text = currentAlphabet2.ToString();
        }
        else if (currentNumber2 == 1)
        {
            currentAlphabet2 = "D";
            alphabet2.text = currentAlphabet2.ToString();
        }
        else if (currentNumber2 == 2)
        {
            currentAlphabet2 = "T";
            alphabet2.text = currentAlphabet2.ToString();
        }
        else if (currentNumber2 == 3)
        {
            currentAlphabet2 = "L";
            alphabet2.text = currentAlphabet2.ToString();
        }
        else if (currentNumber2 == 4)
        {
            currentAlphabet2 = "N";
            alphabet2.text = currentAlphabet2.ToString();
        }
        
    }
}
