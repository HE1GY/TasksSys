using System;
using UnityEngine;

namespace TaskFolder
{
    
    public abstract class Task:ScriptableObject
    {
        [SerializeField] private TaskInfo _taskInfo;
        
        public event Action Started;
        public event Action Completed;

        public virtual void Start()
        {
            Started?.Invoke();
        }
        
        public virtual void Complete()
        {
            Completed?.Invoke();
        }
    }
}