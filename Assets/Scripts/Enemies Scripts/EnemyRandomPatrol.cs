using UnityEngine;
using Pathfinding;

public class EnemyRandomPatrol : MonoBehaviour
{
    [SerializeField] private Transform[] targetLocations;
    
    private int currentTargetIndex = 0;
    private AIDestinationSetter destinationSetter;
    private int newLocation;

    private void Awake()
    {
        destinationSetter = GetComponent<AIDestinationSetter>();
        destinationSetter.target = targetLocations[currentTargetIndex];
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, targetLocations[currentTargetIndex].position) < 0.1f)
        {
            newLocation = Random.Range(0, targetLocations.Length - 1);
            if (newLocation >= currentTargetIndex)
            {
                newLocation++;
            }
            currentTargetIndex = newLocation;
            destinationSetter.target = targetLocations[currentTargetIndex];
        }
    }
}
