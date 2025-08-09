using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GuideTextManager : MonoBehaviour
{
    public static GuideTextManager Instance { get; private set; } // �̱��� �ν��Ͻ�

    public Text descText;

    // �ν����Ϳ��� �Է¹��� ���ڿ� ����Ʈ
    [SerializeField]
    private List<string> messages; // �޽��� ����Ʈ

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // �� ���� �� �޽����� ���ʴ�� ������
        StartCoroutine(ShowMessagesSequentially());
    }

    public void ShowMessage(string message)
    {
        descText.text = message;
        descText.gameObject.SetActive(true);
        StartCoroutine(HideMessageAfterDelay(3f));
    }

    private IEnumerator HideMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        descText.gameObject.SetActive(false);
    }

    private IEnumerator ShowMessagesSequentially()
    {
        foreach (string message in messages)
        {
            ShowMessage(message);
            yield return new WaitForSeconds(3f); // �޽����� �������� �ð� ���� ���
        }
    }
}
