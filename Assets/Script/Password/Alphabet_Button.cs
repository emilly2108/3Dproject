using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Alphabet_Button : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI alphabet;

    private int currentNumber = 0;
    private string currentAlphabet = "A";
    void Start()
    {
        currentNumber = 0;
        alphabet.text = currentAlphabet.ToString();
    }

    void Update()
    {
        Alphabet();
    }

    public void OnButtonPressed()
    {
        currentNumber++;
        if (currentNumber >= 11)
        {
            currentNumber = 0;
        }
    }

    private void Alphabet()
    {
        if (currentNumber == 0)
        {
            currentAlphabet = "A";
            alphabet.text = currentAlphabet.ToString();
        }
        else if (currentNumber == 1)
        {
            currentAlphabet = "D";
            alphabet.text = currentAlphabet.ToString();
        }
        else if (currentNumber == 2)
        {
            currentAlphabet = "G";
            alphabet.text = currentAlphabet.ToString();
        }
        else if (currentNumber == 3)
        {
            currentAlphabet = "L";
            alphabet.text = currentAlphabet.ToString();
        }
        else if (currentNumber == 4)
        {
            currentAlphabet = "K";
            alphabet.text = currentAlphabet.ToString();
        }
        else if (currentNumber == 5)
        {
            currentAlphabet = "E";
            alphabet.text = currentAlphabet.ToString();
        }
        else if (currentNumber == 6)
        {
            currentAlphabet = "R";
            alphabet.text = currentAlphabet.ToString();
        }
        else if (currentNumber == 7)
        {
            currentAlphabet = "S";
            alphabet.text = currentAlphabet.ToString();
        }
        else if (currentNumber == 8)
        {
            currentAlphabet = "T";
            alphabet.text = currentAlphabet.ToString();
        }
        else if (currentNumber == 9)
        {
            currentAlphabet = "Y";
            alphabet.text = currentAlphabet.ToString();
        }
        else if (currentNumber == 10)
        {
            currentAlphabet = "M";
            alphabet.text = currentAlphabet.ToString();
        }
    }
}
