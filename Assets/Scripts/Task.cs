using System;
using System.Collections.Generic;
using TaskFolder;
using UnityEngine;


[CreateAssetMenu(menuName = "SO/Create Task", fileName = "Task")]
public class Task : ScriptableObject, ITask
{
    public event Action Started;
    public event Action Completed;
    
    [SerializeField] TaskInfo _taskInformation;
    [SerializeField] private List<ScriptableObject> _tasksList;

    
    private Queue<ITask> _tasksQueue = new ();
    private ITask _currentTask;
    private int _completedTasks;
    
    private void OnValidate()
    {
        foreach (ScriptableObject scriptableObject in _tasksList)
        {
            if (scriptableObject != null)
            {
                if (scriptableObject is ITask task)
                {
                    _tasksQueue.Enqueue(task);
                }
                else
                {
                    int errorIndex = _tasksList.IndexOf(scriptableObject);
                    _tasksList[errorIndex] = null;
                    throw new Exception("not implement ITask");
                }
            }
        }
    }
    
    public void Start()
    {
        Debug.Log($"Start {this.name}");
        Started?.Invoke();
        _completedTasks = 0;
        EnterNextTask();
    }

    private void OnCompletedInnerTask()
    {
        _completedTasks++;
        _currentTask.Completed -= OnCompletedInnerTask;

        if (CheckIfCompleted())
        {
            Debug.Log($"Completed {this.name}");
            Completed?.Invoke();
        }
        else
        {
            EnterNextTask();
        }
    }

    private bool CheckIfCompleted() => _completedTasks == _tasksList.Count;

    private void EnterNextTask()
    {
        _currentTask = GetNextTask();
        _currentTask.Start();
        _currentTask.Completed += OnCompletedInnerTask;
    }

    private ITask GetNextTask()
    {
        return _tasksQueue.Dequeue();
    }
}