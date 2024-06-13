using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float moveRadius = 10f;
    public float waitTime = 2f;

    private NavMeshAgent agent;
    private float timer;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = waitTime;
        MoveToRandomPosition();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= waitTime)
        {
            MoveToRandomPosition();
            timer = 0;
        }
    }

    void MoveToRandomPosition()
    {
        Vector3 randomDirection = Random.insideUnitSphere * moveRadius;
        randomDirection += transform.position;

        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, moveRadius, -1);

        agent.SetDestination(navHit.position);
    }
}
