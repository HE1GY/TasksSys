using System;
using TaskFolder;
using UnityEngine;

public class ExampleTaskClicker : MonoBehaviour
{
    [SerializeField] private TaskInteractor taskInteractor;

    private void OnEnable()
    {
        taskInteractor.TaskStarted += OnTaskStarted;
    }

    private void OnDisable()
    {
        taskInteractor.TaskStarted -= OnTaskStarted;
    }


    private void OnMouseDown()
    {
        taskInteractor.CompleteTask();
        gameObject.transform.position-=Vector3.up;
    }

    private void OnTaskStarted()
    {
        gameObject.transform.position+=Vector3.up;
    }
}
