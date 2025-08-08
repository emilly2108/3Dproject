using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChaseTrigger : MonoBehaviour
{
    public MonsterChaser monster1;
    public MonsterChaser monster2;
    public GameObject chaseEndTrigger2;
   
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ChaseStart1"))
        {
            monster1.StartChase(transform);
            GuideTextManager.Instance.ShowMessage("������ ������� �ִ�..");
        }
        else if (other.CompareTag("ChaseEnd1"))
        {
            monster1.StopChase();
            GuideTextManager.Instance.ShowMessage("�߰��� ���� �� ����.");
        }
        else if (other.CompareTag("ChaseStart2"))
        {
            monster2.StartChase(transform);
            GuideTextManager.Instance.ShowMessage("������ ������� �ִ�..");

      
            if (chaseEndTrigger2 != null)
                chaseEndTrigger2.SetActive(true);
        }
        else if (other.CompareTag("ChaseEnd2"))
        {
            monster2.StopChase();
            GuideTextManager.Instance.ShowMessage("�߰��� ���� �� ����.");
        }
    }

}
