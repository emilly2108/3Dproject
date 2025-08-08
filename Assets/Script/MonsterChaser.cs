using UnityEngine;
using UnityEngine.AI;

public class MonsterChaser : MonoBehaviour
{
    [SerializeField] public GameObject chaseStartTrigger;
    [SerializeField] public GameObject chaseEndTrigger; //추격 끝난 후 비활성화 위해 

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
        SoundManager.instance.PlayBGM("chaseBGM");
        target = chaseTarget;
        isChasing = true;
        agent.speed = chaseSpeed;
        chaseStartTrigger.SetActive(false);
    }
    public void PauseChase()
    {
        SoundManager.instance.PlayBGM("mainBGM");
        isChasing = false;
        agent.ResetPath();
        chaseStartTrigger.SetActive(true);
        chaseEndTrigger.SetActive(true);
    }
    public void StopChase()
    {
        SoundManager.instance.PlayBGM("mainBGM");
        isChasing = false;
        agent.ResetPath();
        gameObject.SetActive(false);
        chaseStartTrigger.SetActive(false);
        chaseEndTrigger.SetActive(false);
    }
}
