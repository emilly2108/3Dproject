using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InteractionDetector : MonoBehaviour
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
    private string currentTargetTag = ""; // 🔥 현재 오브젝트 태그 기억용

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
                    if (currentTargetTag == "Door")
                    {
                        var lockInfo = passwordManager.GetLockInfoByName(currentTargetInfo.objectName);
                        if (lockInfo != null)
                        {
                            passwordManager.TryToggleDoor(lockInfo, this);
                            if (!lockInfo.isSolved && !targetUI.activeSelf)
                                targetUI.SetActive(true);
                        }
                    }
                    else if (currentTargetTag == "Case")
                    {
                        var lockInfo = passwordManager.GetLockInfoByName(currentTargetInfo.objectName);
                        if (lockInfo != null)
                        {
                            if (!lockInfo.isSolved && !targetUI.activeSelf)
                            {
                                targetUI.SetActive(true); // 퍼즐 UI 띄우기
                            }
                            else if (lockInfo.isSolved)
                            {
                                // 🔥 케이스는 문처럼 열지 않고 비활성화 처리
                                if (lockInfo.doorObject != null && lockInfo.doorObject.activeSelf)
                                {
                                    lockInfo.doorObject.SetActive(false);
                                }
                            }
                        }
                    }

                    else if (currentTargetTag == interactableTag)
                    {

                        if (index >= 0 && index < quizUI.Count && !targetUI.activeSelf)
                        {
                            targetUI.SetActive(true); // 퀴즈 UI 표시
                        }
                    }
                }


                if (Input.GetKeyDown(KeyCode.R))
                {
                    if (targetUI.activeSelf)
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
            if (hit.collider.CompareTag(interactableTag) || hit.collider.CompareTag("Door") || hit.collider.CompareTag("Case"))
            {
                string hitName = hit.collider.name;
                string tag = hit.collider.tag;

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
                    currentTargetTag = tag; // 현재 감지된 오브젝트의 태그 저장
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
        currentTargetTag = "";
    }
}
