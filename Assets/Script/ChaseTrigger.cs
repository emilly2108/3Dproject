using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChaseTrigger : MonoBehaviour
{
    public MonsterChaser monster1;
    public MonsterChaser monster2;
    public GameObject chaseEndTrigger2; 
    public Text descText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ChaseStart1"))
        {
            monster1.StartChase(transform);
            ShowMessage("������ ������� �ִ�..");
        }
        else if (other.CompareTag("ChaseEnd1"))
        {
            monster1.StopChase();
            ShowMessage("�߰��� ���� �� ����.");
        }
        else if (other.CompareTag("ChaseStart2"))
        {
            monster2.StartChase(transform);
            ShowMessage("������ ������� �ִ�..");

      
            if (chaseEndTrigger2 != null)
                chaseEndTrigger2.SetActive(true);
        }
        else if (other.CompareTag("ChaseEnd2"))
        {
            monster2.StopChase();
            ShowMessage("�߰��� ���� �� ����.");
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
