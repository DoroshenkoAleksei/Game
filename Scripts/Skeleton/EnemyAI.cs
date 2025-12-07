using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.AI;
using System.Runtime.CompilerServices;
using KnightAdvenchurUtils;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System;


public class EnemyAI : MonoBehaviour
{
    [SerializeField] private State startingState;
    [SerializeField] private float roamingDistanceMax = 7f;
    [SerializeField] private float roamingDistanceMin = 3f;

    [SerializeField] private float roamingTimerMax = 2f;

    private NavMeshAgent navMeshAgent;

    private State state;
    private Vector3 startingPosition;

    private Vector3 roamPosition;


    private float roamingTime;
    private enum State
    {

        Roaming
    }

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        state = startingState;


    }

    private void Update()
    {
        switch (state)
        {
            default:
            case State.Roaming:
                roamingTime -= Time.deltaTime;
                if (roamingTime < 0)
                {
                    Roaming();
                    roamingTime = roamingTimerMax;
                }
                break;
        }
    }

    private void Roaming()
    {
        // startingPosition = transform.position;
        // roamPosition = GetRoamingPosition();
        ChangeFacingDoraction(startingPosition, roamPosition);
        navMeshAgent.SetDestination(roamPosition);

    }

    private void changeFacingDoraction(Vector3 startingPosition, Vector3 roamPosition)
    {
        throw new NotImplementedException();
    }

    private Vector3 GetRoamingPosition()
    {
        return startingPosition + Utils.GetRandomDir() * UnityEngine.Random.Range(roamingDistanceMin, roamingDistanceMax);

    }


    private void ChangeFacingDoraction(Vector3 sourcePosition, Vector3 targetPosition) {
        if (sourcePosition.x > targetPosition.x)
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }


    } 
}
