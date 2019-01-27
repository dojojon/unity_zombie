using UnityEngine;

public class MoveToPosition : MonoBehaviour
{

    public Transform goal;
    private UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        agent.SetDestination(goal.position);
    }
}
