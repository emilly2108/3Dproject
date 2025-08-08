using UnityEngine;

public class openBox_Door : MonoBehaviour
{
    //움직이는 시간
    public float moveDuration1 = 1f;
    //움직이는 기준
    public Transform doorHinge1;

    //닫힐 각도= 0
    private Quaternion closedRotation1;
    //열릴 각도= 60
    private Quaternion openRotation1;

    private void Start()
    {
        closedRotation1 = doorHinge1.rotation;
        openRotation1 = closedRotation1 * Quaternion.Euler(0, -60f, 0);
    }

    public System.Collections.IEnumerator DoorMoveOpen()
    {
        float elapsedTime = 0f;
        while (elapsedTime < moveDuration1)
        {
            doorHinge1.rotation = Quaternion.Lerp(closedRotation1, openRotation1, elapsedTime / moveDuration1);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        doorHinge1.rotation = openRotation1;
    }


    public System.Collections.IEnumerator DoorMoveClose()
    {
        float elapsedTime = 0f;
        while (elapsedTime < moveDuration1)
        {
            doorHinge1.rotation = Quaternion.Lerp(openRotation1,closedRotation1,  elapsedTime / moveDuration1);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        doorHinge1.rotation = closedRotation1;
    }
}
