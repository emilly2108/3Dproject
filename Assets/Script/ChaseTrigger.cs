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
            descText.text = "누군가 따라오고 있다..";
        }
        else if (other.CompareTag("ChaseEnd1"))
        {
            monster.StopChase();
            descText.text = "추격이 멈춘 것 같다.";
        }
    }
}
