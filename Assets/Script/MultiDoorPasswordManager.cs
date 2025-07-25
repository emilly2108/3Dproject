using System.Collections.Generic;
using UnityEngine;

public class MultiDoorPasswordManager : MonoBehaviour
{
    [SerializeField] private List<DoorLockInfo> doorLocks;

    [SerializeField] private GameObject crosshair;
    [SerializeField] private MessageDisplayer messageDisplayer; // ✅ 추가

    void Update()
    {
        CheckAllLocks();
    }

    private void CheckAllLocks()
    {
        foreach (var lockInfo in doorLocks)
        {
            if (lockInfo.isSolved) continue;
            if (lockInfo.inputFields.Count != lockInfo.correctPasswordString.Length)
                continue;

            // ✅ 사용자 입력 문자열 만들기
            string userInputStr = "";
            for (int i = 0; i < lockInfo.inputFields.Count; i++)
            {
                userInputStr += lockInfo.inputFields[i].text.Trim(); // 공백 제거하고 이어붙이기
            }

            // ✅ 정답과 비교
            if (userInputStr == lockInfo.correctPasswordString)
            {
                lockInfo.isSolved = true;

                if (lockInfo.puzzleUI != null)
                    lockInfo.puzzleUI.SetActive(false);

                // 태그에 따라 문/서랍 처리
                if (lockInfo.doorObject != null)
                {
                    string tag = lockInfo.doorObject.tag;

                    if (tag == "Door" && lockInfo.openDoor != null)
                    {
                        StartCoroutine(lockInfo.openDoor.DoorMoveOpen());
                        lockInfo.openDoor.isOpen = true;
                        messageDisplayer?.ShowMessage("문이 열렸다.");
                    }
                    else if (tag == "Case")
                    {
                        messageDisplayer?.ShowMessage("서랍이 잠금 해제되었다. 열어보자.");
                        // InteractionDetector에서 비활성화 처리
                    }
                }

                if (crosshair != null)
                    crosshair.SetActive(true);
            }
        }
    }


    public DoorLockInfo GetLockInfoByName(string objectName)
    {
        return doorLocks.Find(d => d.objectName == objectName);
    }

    public void TryToggleDoor(DoorLockInfo lockInfo, MonoBehaviour caller)
    {
        if (lockInfo == null || lockInfo.openDoor == null)
            return; 

        if (!lockInfo.isSolved)
            return;

        lockInfo.openDoor.ToggleDoor(caller);
    }
}
