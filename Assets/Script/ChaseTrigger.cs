using UnityEngine;
using UnityEngine.UI;

public class ChaseTrigger : MonoBehaviour
{
    public MonsterChaser monster;
    public Text descText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ChaseStart1"))
        {
            monster.StartChase(transform);
            descText.text = "������ ������� �ִ�..";
        }
        else if (other.CompareTag("ChaseEnd1"))
        {
            monster.StopChase();
            descText.text = "�߰��� ���� �� ����.";
        }
    }
}
