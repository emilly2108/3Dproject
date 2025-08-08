using UnityEngine;

public class openBox_Door : MonoBehaviour
{
    //�����̴� �ð�
    public float moveDuration1 = 1f;
    //�����̴� ����
    public Transform doorHinge1;

    //���� ����= 0
    private Quaternion closedRotation1;
    //���� ����= 60
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
