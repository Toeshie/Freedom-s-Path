using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class TwoPointPatrolingLight : MonoBehaviour
{
    private int currentTargetIndex = 0;
    [SerializeField] private Transform[] targetLocations;
    private AIDestinationSetter destinationSetter;
    private AIPath aiPath;

    private void Awake()
    {
        destinationSetter = GetComponent<AIDestinationSetter>();
        aiPath = GetComponent<AIPath>();
        destinationSetter.target = targetLocations[currentTargetIndex];
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, targetLocations[currentTargetIndex].position) < aiPath.endReachedDistance)
        {
            currentTargetIndex = (currentTargetIndex + 1) % targetLocations.Length;
            
            destinationSetter.target = targetLocations[currentTargetIndex];
        }
    }
}
