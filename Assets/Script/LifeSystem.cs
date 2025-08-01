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
            // ���� ���� ���� �߰� ����
        }
    }

    private void UpdateHeartUI()
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            heartImages[i].sprite = i < currentHP ? fullHeart : emptyHeart;
        }
    }
    //����(����) �߶���
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hole"))
        {
            Debug.Log("Hole�� ��������");
            ChangeHP(-1);
            StartCoroutine(FadeSequence(holeObject)); 
        }
    }

    // ȭ�� ���̵� + ��ġ �ʱ�ȭ + Hole ��Ȱ��ȭ(�ߺ�ó�� ����)
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
