using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    [Header("��� ����")]
    [SerializeField] private int maxHP = 3;
    private int currentHP;

    [Header("��Ʈ UI ����")]
    [SerializeField] private Image[] heartImages; // ��Ʈ 3�� ����
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;

    private void Start()
    {
        currentHP = maxHP;
        UpdateHeartUI();
    }

    private void Update()
    {
        // ���� �ڸ� ��� - ���߿� ���ǿ� ���� ���̰ų� �ø� �� ����

        // �׽�Ʈ Ű(����1Ű, ����2Ű)
        if (Input.GetKeyDown(KeyCode.Alpha1)) // ����
            ChangeHP(-1);

        if (Input.GetKeyDown(KeyCode.Alpha2)) // ����
            ChangeHP(1);
    }

    public void ChangeHP(int amount)
    {
        currentHP = Mathf.Clamp(currentHP + amount, 0, maxHP);
        UpdateHeartUI();

        if (currentHP == 0)
        {
            Debug.Log("Game Over!");
            // ���� ���� ó�� ����
        }
    }

    private void UpdateHeartUI()
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            if (i < currentHP)
                heartImages[i].sprite = fullHeart;
            else
                heartImages[i].sprite = emptyHeart;
        }
    }
}
