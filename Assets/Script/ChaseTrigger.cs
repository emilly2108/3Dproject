using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChaseTrigger : MonoBehaviour
{
    public MonsterChaser monster;
    public Text descText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ChaseStart1"))
        {
            monster.StartChase(transform);
            ShowMessage("누군가 따라오고 있다..");
        }
        else if (other.CompareTag("ChaseEnd1"))
        {
            monster.StopChase();
            ShowMessage("추격이 멈춘 것 같다.");
        }
    }

    private void ShowMessage(string message)
    {
        descText.text = message;
        descText.gameObject.SetActive(true);
        StartCoroutine(HideMessageAfterDelay(3f));
    }

    private IEnumerator HideMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        descText.gameObject.SetActive(false);
    }
}
