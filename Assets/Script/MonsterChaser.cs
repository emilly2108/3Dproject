using UnityEngine;
using UnityEngine.AI;

public class MonsterChaser : MonoBehaviour
{
    [SerializeField] private GameObject chaseStartTrigger;
    [SerializeField] private GameObject chaseEndTrigger; //추격 끝난 후 비활성화 위해 

    public float chaseSpeed = 3.5f;

    private NavMeshAgent agent;
    private Transform target;
    private bool isChasing = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (isChasing==true)
        {
            agent.SetDestination(target.position);
        }
    }

    public void StartChase(Transform chaseTarget)
    {
        target = chaseTarget;
        isChasing = true;
        agent.speed = chaseSpeed;
    }

    public void StopChase()
    {
        isChasing = false;
        agent.ResetPath();
        gameObject.SetActive(false);
        chaseStartTrigger.SetActive(false);
        chaseEndTrigger.SetActive(false);
    }
}
