using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MessageDisplayer : MonoBehaviour
{
    [SerializeField] private GameObject messageObject;
    [SerializeField] private Text messageText;

    public void ShowMessage(string message, float duration = 3f)
    {
        StopAllCoroutines(); // ���� �޽��� ����� ����
        messageText.text = message;
        messageObject.SetActive(true);
        StartCoroutine(HideMessageAfterDelay(duration));
    }

    private IEnumerator HideMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        messageObject.SetActive(false);
    }
}
