using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIPatrol : MonoBehaviour {

    [SerializeField]
    List<WayPoint> _patrolPoints;

    NavMeshAgent navMeshAgent;
    [SerializeField]
    int currentPatrolIndex;
    Vector3 targetVector;
    float delay;
    float totalWait;
    void Start () {
        navMeshAgent = this.GetComponent<NavMeshAgent>();

        if (navMeshAgent == null)
        {
            Debug.LogError("The nav mesh agent comonent is not attached to " + gameObject.name);
        }
        else
        {
            if(_patrolPoints != null && _patrolPoints.Count >= 2)
            {
                currentPatrolIndex = 0;
                SetDestination();
            }
            else
            {
                Debug.Log("Insufficient patrol points for basic patrolling behaviour.");
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        SetDestination();
        ChangePatrolPoint();
	}

    private void SetDestination()
    {
        targetVector = _patrolPoints[currentPatrolIndex].transform.position;
        //transform.rotation.eulerAngles += new Vector3(0, 90, 0);
        navMeshAgent.SetDestination(targetVector);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetVector - transform.position), Time.deltaTime);
        //transform.LookAt(navMeshAgent.steeringTarget);
    }

    private void ChangePatrolPoint()
    {
        if (delay > totalWait)
        {
            if (navMeshAgent.remainingDistance <= 1.0f)
            {
                if (currentPatrolIndex == (_patrolPoints.Count - 1))
                {
                    currentPatrolIndex = 0;
                }
                else
                {
                    currentPatrolIndex += 1;
                }
            }
            delay = 0;
        }
        else
        {
            delay += Time.deltaTime;
        }
    }
}
