using UnityEngine;

[System.Serializable]
public class InteractableInfo
{
    public string objectName;         // 오브젝트 이름 (GameObject.name)
    public string descriptionText;    // 화면에 띄울 설명
    public int quizUIIndex = -1;      // 퀴즈 UI 인덱스 (-1은 없음)
    public GameObject openObject;     // ✅ 열고 닫을 오브젝트 (예: 케이스)
    //public DoorLockInfo doorLockInfo; // 문 퍼즐 정보 (nullable)
}
