using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navigation : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Seek();
        agent.SetDestination(agent.destination);

    }

    void Seek()
    {
        agent.destination = target.transform.position;
    }
}
