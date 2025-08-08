using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Alphabet_Button1 : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI alphabet1;

    private int currentNumber1 = 0;
    private string currentAlphabet1 = "A";
    void Start()
    {
        currentNumber1 = 0;
        alphabet1.text = currentAlphabet1.ToString();
    }

    void Update()
    {
        Alphabet1();
    }

    public void OnButtonPressed()
    {
        currentNumber1++;
        if (currentNumber1 >= 11)
        {
            currentNumber1 = 0;
        }
    }

    private void Alphabet1()
    {
        if (currentNumber1  == 0)
        {
            currentAlphabet1 = "A";
            alphabet1.text = currentAlphabet1.ToString();
        }
        else if (currentNumber1 == 1)
        {
            currentAlphabet1 = "D";
            alphabet1.text = currentAlphabet1.ToString();
        }
        else if (currentNumber1 == 2)
        {
            currentAlphabet1 = "E";
            alphabet1.text = currentAlphabet1.ToString();
        }
        else if (currentNumber1 == 3)
        {
            currentAlphabet1 = "K";
            alphabet1.text = currentAlphabet1.ToString();
        }
        else if (currentNumber1 == 4)
        {
            currentAlphabet1 = "N";
            alphabet1.text = currentAlphabet1.ToString();
        }
        else if (currentNumber1 == 5)
        {
            currentAlphabet1 = "O";
            alphabet1.text = currentAlphabet1.ToString();
        }
        else if (currentNumber1 == 6)
        {
            currentAlphabet1 = "P";
            alphabet1.text = currentAlphabet1.ToString();
        }
        else if (currentNumber1 == 7)
        {
            currentAlphabet1 = "R";
            alphabet1.text = currentAlphabet1.ToString();
        }
        else if (currentNumber1 == 8)
        {
            currentAlphabet1 = "W";
            alphabet1.text = currentAlphabet1.ToString();
        }
        else if (currentNumber1 == 9)
        {
            currentAlphabet1 = "L";
            alphabet1.text = currentAlphabet1.ToString();
        }
        else if (currentNumber1 == 10)
        {
            currentAlphabet1 = "V";
            alphabet1.text = currentAlphabet1.ToString();
        }
    }
}
