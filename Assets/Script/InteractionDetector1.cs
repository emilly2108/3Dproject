using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InteractionDetector1 : MonoBehaviour
{
    [SerializeField] private float interactRange = 3f;
    [SerializeField] private string interactableTag = "Interactable";

    [SerializeField] private GameObject descriptionUI;
    [SerializeField] private Text descriptionText;

    [SerializeField] private List<GameObject> quizUI;
    [SerializeField] private List<InteractableInfo> interactableInfos;
    [SerializeField] private MultiDoorPasswordManager passwordManager;

    private bool isDescriptionVisible = false;
    private InteractableInfo currentTargetInfo = null;

    void Update()
    {
        DetectInteractable();

        if (currentTargetInfo != null)
        {
            int index = currentTargetInfo.quizUIIndex;

            if (index >= 0 && index < quizUI.Count && quizUI[index] != null)
            {
                GameObject targetUI = quizUI[index];

                // Z 또는 Enter 입력 시
                if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return))
                {
                    var lockInfo = passwordManager.GetLockInfoByName(currentTargetInfo.objectName);

                    if (lockInfo != null)
                    {
                        passwordManager.TryToggleDoor(lockInfo, this);

                        if (!lockInfo.isSolved && !targetUI.activeSelf)
                        {
                            Debug.Log("자물쇠 표시됨");
                            Debug.Log($"[Detector] lockInfo.isSolved: {lockInfo.isSolved}, object: {lockInfo}");

                            targetUI.SetActive(true);
                        }
                    }

                }


                if (Input.GetKeyDown(KeyCode.R) && targetUI.activeSelf)
                {
                    targetUI.SetActive(false);
                }
            }
        }
    }

    private void DetectInteractable()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0));

        if (Physics.Raycast(ray, out RaycastHit hit, interactRange))
        {
            if (hit.collider.CompareTag(interactableTag) || hit.collider.CompareTag("Door"))
            {
                string hitName = hit.collider.name;

                InteractableInfo info = interactableInfos.Find(i => i.objectName == hitName);

                if (info != null)
                {
                    if (!isDescriptionVisible || currentTargetInfo != info)
                    {
                        descriptionUI.SetActive(true);
                        descriptionText.text = info.descriptionText;
                        isDescriptionVisible = true;
                    }

                    currentTargetInfo = info;
                    return;
                }
            }
        }

        // 감지 못함
        if (isDescriptionVisible)
        {
            descriptionUI.SetActive(false);
            isDescriptionVisible = false;
        }

        currentTargetInfo = null;
    }
}
