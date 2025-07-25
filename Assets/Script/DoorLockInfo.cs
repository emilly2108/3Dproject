using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class DoorLockInfo
{
    public string objectName;                 // 문 이름 (doorObject.name과 동일)
    public GameObject doorObject;             // 문 오브젝트
    public List<TextMeshProUGUI> inputFields; // 퍼즐 입력 UI
    public string correctPasswordString;      // 정답 문자열
    public GameObject puzzleUI;               // 퍼즐 UI 오브젝트
    public OpenDoor openDoor;                 // 문 애니메이션 스크립트
    public int quizUIIndex;                   // 퀴즈 UI 인덱스
    public string descriptionText;            // UI에 띄울 설명
    public bool isSolved = false;             // 푼 상태 여부

}
