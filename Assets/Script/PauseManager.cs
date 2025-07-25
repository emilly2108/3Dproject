using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI;
    private bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        pauseUI.SetActive(true);
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
    }

    public void GoToHomeScene()
    {
        Debug.Log("홈으로 돌아가기 버튼 눌림");

        // 나중에 실제 씬 이름으로 교체
        // SceneManager.LoadScene("HomeScene");
    }
}
