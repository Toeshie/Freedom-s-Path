using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointPositionReseter : MonoBehaviour
{
    private CheckpointManager checkpointManager = null;
    private void Awake()
    {
        checkpointManager = FindObjectOfType<CheckpointManager>();
        CheckpointManager.ResetCheckPointPosition();
    }
}
