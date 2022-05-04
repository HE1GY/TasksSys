using System;
using TaskFolder;
using UnityEngine;

[CreateAssetMenu(fileName = "End Task",menuName = "SO/Create EndTask")]
public class EndTask:ScriptableObject,ITask
{
    [SerializeField] private TaskInfo _taskInformation;
        
    public event Action Started;
    public event Action Completed;

    private bool _isActive;
    public void Start()
    {
        Debug.Log($"Start sub {this.name}");
        
        _isActive = true;
        Started?.Invoke();
    }
    public void InvokeCompleted()
    {
        if(_isActive)
        {
            Debug.Log($"Complete sub {this.name}");
            
            _isActive = false;
            Completed?.Invoke();
        }
       
    }
}