using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
    [System.Serializable]
    public class EndingElement
    {
        [TextArea] public string dialogue;
        public Sprite image;
    }

    [SerializeField] private TextMeshProUGUI endingText;
    [SerializeField] private Image endingImage;
    [SerializeField] private GameObject nextIndicator;
    [SerializeField] private List<EndingElement> elements = new List<EndingElement>();
    [SerializeField] private float startDelay = 3f;
    [SerializeField] private float typingSpeed = 0.05f;

    [SerializeField] private GameObject clearUI;

    private int currentIndex = -1;
    private bool isTyping = false;
    private Coroutine typingCoroutine;

    void Start()
    {
        if (endingText != null) endingText.gameObject.SetActive(false);
        if (endingImage != null) endingImage.gameObject.SetActive(false);
        if (nextIndicator != null) nextIndicator.SetActive(false);
        clearUI.SetActive(false);
        SettingManager.LoadSettings();
        SoundManager.instance.PlayBGM("endingBGM");
        StartCoroutine(StartSequence());
    }

    private IEnumerator StartSequence()
    {
        yield return new WaitForSeconds(startDelay);
        ShowNext();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return))
        {
            if (isTyping)
            {
                StopCoroutine(typingCoroutine);
                endingText.text = elements[currentIndex].dialogue;
                isTyping = false;
                if (nextIndicator != null) nextIndicator.SetActive(true);
            }
            else
            {
                ShowNext();
            }
        }
    }

    private void ShowNext()
    {
        currentIndex++;

        if (currentIndex >= elements.Count)
        {
            Debug.Log("엔딩끝");
            RealEnd();
            return;
        }

        if (nextIndicator != null) nextIndicator.SetActive(false);

        EndingElement element = elements[currentIndex];

        if (endingImage != null)
        {
            if (element.image != null)
            {
                Debug.Log("엔딩이미지");
                endingImage.sprite = element.image;
                endingImage.gameObject.SetActive(true);
            }
            else
            {
                endingImage.gameObject.SetActive(false);
                Debug.Log("엔딩이미지 없음");
            }
        }

        if (endingText != null)
        {
            if (!string.IsNullOrEmpty(element.dialogue))
            {
                endingText.gameObject.SetActive(true);
                if (typingCoroutine != null) StopCoroutine(typingCoroutine);
                typingCoroutine = StartCoroutine(TypeText(element.dialogue));
            }
            else
            {
                endingText.gameObject.SetActive(false);
                if (nextIndicator != null) nextIndicator.SetActive(true);
            }
        }
    }
    private void RealEnd()
    {
        clearUI.SetActive(true);
    }
    public void StartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void Show1Scene()
    {
        SceneManager.LoadScene("Show 1");
    }
    private IEnumerator TypeText(string dialogue)
    {
        isTyping = true;
        endingText.text = "";

        foreach (char c in dialogue)
        {
            endingText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
        if (nextIndicator != null) nextIndicator.SetActive(true);
    }
}
