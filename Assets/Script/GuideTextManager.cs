using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GuideTextManager : MonoBehaviour
{
    public static GuideTextManager Instance { get; private set; } // 싱글톤 인스턴스

    public Text descText;

    // 인스펙터에서 입력받을 문자열 리스트
    [SerializeField]
    private List<string> messages; // 메시지 리스트

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
        // 씬 시작 시 메시지를 차례대로 보여줌
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
            yield return new WaitForSeconds(3f); // 메시지가 보여지는 시간 동안 대기
        }
    }
}
