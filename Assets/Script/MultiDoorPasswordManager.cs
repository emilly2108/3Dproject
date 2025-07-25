using System.Collections.Generic;
using UnityEngine;

public class MultiDoorPasswordManager : MonoBehaviour
{
    [SerializeField] private List<DoorLockInfo> doorLocks;

    [SerializeField] private GameObject crosshair;
    [SerializeField] private MessageDisplayer messageDisplayer; // ✅ 추가

    void Update()
    {
        CheckAllDoors();
    }

    private void CheckAllDoors()
    {
        foreach (var lockInfo in doorLocks)
        {
            if (lockInfo.isSolved) continue;
            if (lockInfo.inputFields.Count != lockInfo.correctPasswordString.Length)
                continue;

            bool matched = true;

            for (int i = 0; i < lockInfo.inputFields.Count; i++)
            {
                if (!int.TryParse(lockInfo.inputFields[i].text, out int userInput))
                {
                    matched = false;
                    break;
                }

                int correctDigit = int.Parse(lockInfo.correctPasswordString[i].ToString());

                if (userInput != correctDigit)
                {
                    matched = false;
                    break;
                }
            }

            if (matched)
            {
                 lockInfo.isSolved = true;

                if (lockInfo.puzzleUI != null)
                    lockInfo.puzzleUI.SetActive(false);

                if (lockInfo.openDoor != null)
                    StartCoroutine(lockInfo.openDoor.DoorMoveOpen());
                else
                    Debug.LogWarning($"{lockInfo.doorObject.name}에 OpenDoor 컴포넌트가 연결되지 않았습니다.");

                if (crosshair != null)
                    crosshair.SetActive(true);

                // ✅ 분리된 메시지 호출
                messageDisplayer?.ShowMessage($"문이 열렸다.");
                lockInfo.openDoor.isOpen = true;
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
