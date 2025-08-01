using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LifeSystem : MonoBehaviour
{
    [SerializeField] private int maxHP = 3;
    private int currentHP;

    [SerializeField] private Image[] heartImages;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;

    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration = 1f;
    [SerializeField] private GameObject holeObject;

    private void Start()
    {
        currentHP = maxHP;
        UpdateHeartUI();

    }


    public void ChangeHP(int amount)
    {
        currentHP = Mathf.Clamp(currentHP + amount, 0, maxHP);
        UpdateHeartUI();

        if (currentHP == 0)
        {
            Debug.Log("Game Over");
            // 게임 오버 로직 추가 가능
        }
    }

    private void UpdateHeartUI()
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            heartImages[i].sprite = i < currentHP ? fullHeart : emptyHeart;
        }
    }
    //구멍(함정) 추락시
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hole"))
        {
            Debug.Log("Hole에 떨어졌다");
            ChangeHP(-1);
            StartCoroutine(FadeSequence(holeObject)); 
        }
    }

    // 화면 페이드 + 위치 초기화 + Hole 비활성화(중복처리 방지)
    private IEnumerator FadeSequence(GameObject holeObject)
    {
        holeObject.SetActive(false); 

        yield return StartCoroutine(FadeOut());
        transform.position = new Vector3(22.21f, 0.188f, -15.93f);
        yield return new WaitForSeconds(2f); 
        yield return StartCoroutine(FadeIn());

        holeObject.SetActive(true); 
    }


    private IEnumerator FadeOut()
    {
        float timer = 0f;
        Color color = fadeImage.color;
        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            fadeImage.color = new Color(color.r, color.g, color.b, alpha);
            timer += Time.deltaTime;
            yield return null;
        }
        fadeImage.color = new Color(color.r, color.g, color.b, 1f);
    }

    private IEnumerator FadeIn()
    {
        float timer = 0f;
        Color color = fadeImage.color;
        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            fadeImage.color = new Color(color.r, color.g, color.b, alpha);
            timer += Time.deltaTime;
            yield return null;
        }
        fadeImage.color = new Color(color.r, color.g, color.b, 0f);
    }
}
