using UnityEngine;
using System.Collections;
public class OpenCase : MonoBehaviour
{
    public float moveDistance = 0.2f;
    public float moveDuration = 1f;

    public System.Collections.IEnumerator CaseOpen()
    {
        Debug.Log("¿­¸²");
        SoundManager.instance.PlaySE("case");
        Vector3 startPos = transform.position;
        Vector3 targetPos = startPos + -transform.forward * moveDistance;

        float elapsed = 0f;
        while (elapsed < moveDuration)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, elapsed / moveDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
    }


    public System.Collections.IEnumerator CaseClose()
    {
        Debug.Log("´ÝÈû");
        SoundManager.instance.PlaySE("case");
        Vector3 startPos = transform.position;
        Vector3 targetPos = startPos + transform.forward * moveDistance;

        float elapsed = 0f;
        while (elapsed < moveDuration)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, elapsed / moveDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
    }
}

