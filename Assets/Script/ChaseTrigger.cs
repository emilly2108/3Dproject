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
            ShowMessage("누군가 따라오고 있다..");
        }
        else if (other.CompareTag("ChaseEnd1"))
        {
            monster1.StopChase();
            ShowMessage("추격이 멈춘 것 같다.");
        }
        else if (other.CompareTag("ChaseStart2"))
        {
            monster2.StartChase(transform);
            ShowMessage("누군가 따라오고 있다..");

      
            if (chaseEndTrigger2 != null)
                chaseEndTrigger2.SetActive(true);
        }
        else if (other.CompareTag("ChaseEnd2"))
        {
            monster2.StopChase();
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
