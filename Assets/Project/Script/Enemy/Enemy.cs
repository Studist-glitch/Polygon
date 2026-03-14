using Polygon;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Transform target;
    [SerializeField] private NavMeshAgent agent;

    private void Start()
    {
        target = FindFirstObjectByType<Controller>(FindObjectsInactive.Include).transform;
        agent.speed = Random.Range(5f, 50f);
        agent.avoidancePriority = Random.Range(5, 50);
    } 

    void Update()
    {
        agent.SetDestination(target.position);
    }
}
