using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI;
    [SerializeField] PlayerController playerController;
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
        playerController.SetCanMove(false);  // �̵� ����
        isPaused = true;
        Time.timeScale = 0f;
        pauseUI.SetActive(true);
    }

    public void ResumeGame()
    {
        playerController.SetCanMove(true);  // �̵� ���
        isPaused = false;
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
    }

    public void GoToHomeScene()
    {
        playerController.SetCanMove(true);  // �̵� ���
        Debug.Log("Ȩȭ������ �̵�");


        // SceneManager.LoadScene("HomeScene");
    }
}