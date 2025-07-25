using System.Collections;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public float moveDuration = 1f;
    public Transform doorHinge;
    public MessageDisplayer messageDisplayer; // ✅ 메시지 출력기 참조 추가

    private Quaternion closedRotation;
    private Quaternion openRotation;

    public bool isOpen = false;

    private void Start()
    {
        closedRotation = doorHinge.rotation;
        openRotation = closedRotation * Quaternion.Euler(0, 60f, 0);
    }

    public void ToggleDoor(MonoBehaviour context)
    {
        if (isOpen)
        {
            context.StartCoroutine(DoorMoveClose());
        }
        else
        {
            context.StartCoroutine(DoorMoveOpen());
        }

        isOpen = !isOpen;
    }

    public IEnumerator DoorMoveOpen()
    {
        float elapsedTime = 0f;
        while (elapsedTime < moveDuration)
        {
            doorHinge.rotation = Quaternion.Lerp(closedRotation, openRotation, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        doorHinge.rotation = openRotation;

        // ✅ 문이 열림 메시지
        messageDisplayer?.ShowMessage("문이 열렸다.");
    }

    public IEnumerator DoorMoveClose()
    {
        float elapsedTime = 0f;
        while (elapsedTime < moveDuration)
        {
            doorHinge.rotation = Quaternion.Lerp(openRotation, closedRotation, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        doorHinge.rotation = closedRotation;

        // ✅ 문이 닫힘 메시지
        messageDisplayer?.ShowMessage("문이 닫혔다.");
    }
}
