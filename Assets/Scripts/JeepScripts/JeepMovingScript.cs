using System;
using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform targetPoint = null;
    [SerializeField] private Transform startingPosition = null;

    [SerializeField] private float duration = 3f;
    

    private bool jeepStartFlag = false;

    private float step = 0;

    private void Awake()
    {
        step = Vector2.Distance(transform.position, targetPoint.position) / duration;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(JeepStart());
        }
    }

    private IEnumerator JeepStart()
    {
        yield return new WaitForSeconds(2.0f);
        jeepStartFlag = true;
    }

    private IEnumerator RestartJeep()
    {
        yield return new WaitForSeconds(30f);
        transform.position = startingPosition.position;
    }

    private void Update()
    {
        if (jeepStartFlag)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPoint.position,
                step * Time.deltaTime);

            if (Mathf.Approximately(transform.position.x, targetPoint.position.x) &&
                Mathf.Approximately(transform.position.y, targetPoint.position.y))
            {
                jeepStartFlag = false;
                StartCoroutine(RestartJeep());
            }
        }
        
    }
}