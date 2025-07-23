using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InteractionDetector : MonoBehaviour
{
    [SerializeField]
    private float interactRange = 3f;

    [SerializeField]
    private string interactableTag = "Interactable";

    [SerializeField]
    private GameObject descriptionUI;
    [SerializeField]
    private Text descriptionText;

    [SerializeField]
    private List<GameObject> quizUI; // 퀴즈 UI 리스트

    [SerializeField]
    private List<InteractableInfo> interactableInfos; // 오브젝트 정보 리스트

    private bool isDescriptionVisible = false;
    private InteractableInfo currentTargetInfo = null;

    void Update()
    {
        DetectInteractable();

        // 현재 감지 중인 오브젝트가 있을 때
        if (currentTargetInfo != null)
        {
            int index = currentTargetInfo.quizUIIndex;

            if (index >= 0 && index < quizUI.Count && quizUI[index] != null)
            {
                GameObject targetUI = quizUI[index];

                //  Z 또는 Enter 키로 퀴즈 UI 켜기
                if ((Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return)) && !targetUI.activeSelf)
                {
                    targetUI.SetActive(true);
                }

                //  R 키로 퀴즈 UI 끄기
                if (Input.GetKeyDown(KeyCode.R) && targetUI.activeSelf)
                {
                    targetUI.SetActive(false);
                }
            }
        }
    }



    private void DetectInteractable()
    {
        // 카메라 화면 정중앙에서 화면 밖으로 향하는 레이 생성 (마우스가 아니라 중심 고정)
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0));

        RaycastHit hit; // 레이캐스트 충돌 정보를 저장할 변수

        // 레이를 발사하여 interactRange 거리 내의 오브젝트와 충돌했는지 검사
        if (Physics.Raycast(ray, out hit, interactRange))
        {
            // 충돌한 오브젝트가 "Interactable" 또는 "Door" 태그를 가지고 있는 경우에만 처리
            if (hit.collider.CompareTag(interactableTag) || hit.collider.CompareTag("Door"))
            {
                // 충돌한 오브젝트의 이름을 가져옴
                string hitName = hit.collider.name;

                // interactableInfos 리스트에서 오브젝트 이름이 일치하는 정보를 찾음
                InteractableInfo info = interactableInfos.Find(i => i.objectName == hitName);

                // 해당 정보를 찾았을 경우
                if (info != null)
                {
                    // 설명창이 꺼져 있거나, 감지 중인 대상이 바뀌었을 때만 텍스트 갱신
                    if (!isDescriptionVisible || currentTargetInfo != info)
                    {
                        // 설명 UI를 켜고 텍스트를 설정
                        descriptionUI.SetActive(true);
                        descriptionText.text = info.descriptionText;
                        isDescriptionVisible = true;
                    }

                    // 현재 타겟 정보를 갱신 (다음 프레임에서 퀴즈 UI 관련 처리 등에 사용됨)
                    currentTargetInfo = info;

                    // 감지 완료되었으므로 함수 종료
                    return;
                }
            }
        }

        // 위의 조건을 만족하지 못한 경우: 감지된 오브젝트 없음 → 설명창 끔
        if (isDescriptionVisible)
        {
            descriptionUI.SetActive(false);
            isDescriptionVisible = false;
        }

        // 현재 타겟 정보 초기화
        currentTargetInfo = null;
    }


}
