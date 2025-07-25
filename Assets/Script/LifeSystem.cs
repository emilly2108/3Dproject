using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    [Header("목숨 설정")]
    [SerializeField] private int maxHP = 3;
    private int currentHP;

    [Header("하트 UI 설정")]
    [SerializeField] private Image[] heartImages; // 하트 3개 연결
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;

    private void Start()
    {
        currentHP = maxHP;
        UpdateHeartUI();
    }

    private void Update()
    {
        // 조건 자리 비움 - 나중에 조건에 따라 줄이거나 늘릴 수 있음

        // 테스트 키(숫자1키, 숫자2키)
        if (Input.GetKeyDown(KeyCode.Alpha1)) // 감소
            ChangeHP(-1);

        if (Input.GetKeyDown(KeyCode.Alpha2)) // 증가
            ChangeHP(1);
    }

    public void ChangeHP(int amount)
    {
        currentHP = Mathf.Clamp(currentHP + amount, 0, maxHP);
        UpdateHeartUI();

        if (currentHP == 0)
        {
            Debug.Log("Game Over!");
            // 게임 오버 처리 가능
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
