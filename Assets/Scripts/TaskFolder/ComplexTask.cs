using System;
using System.Collections.Generic;
using UnityEngine;

namespace TaskFolder
{
    [CreateAssetMenu(menuName = "SO/Create ComplexTask", fileName = "ComplexTask")]
    public class ComplexTask : Task
    {
        [SerializeField] private Task[] _tasks;
        
        private Queue<Task> _tasksQueue = new ();
        private Task _currentTask;
        private int _completedTasks;
        
        private void OnValidate()
        {
            ArrayToQueue();
        }

        public override void Start()
        {
            base.Start();
            
            Debug.Log($"Start {this.name}");/////////////////////
            _completedTasks = 0;
            EnterNextTask();
        }
        
        private void EnterNextTask()
        {
            _currentTask = GetNextTask();
            _currentTask.Start();
            _currentTask.Completed += OnCompletedInnerTask;
        }
        
        private void OnCompletedInnerTask()
        {
            _completedTasks++;
            _currentTask.Completed -= OnCompletedInnerTask;

            if (CheckIfCompleted())
            {
                Debug.Log($"Completed {this.name}");///////////////
                base.Complete();
            }
            else
            {
                EnterNextTask();
            }
        }
        
        private Task GetNextTask()
        {
            return _tasksQueue.Dequeue();
        }
        
        private bool CheckIfCompleted() => _completedTasks == _tasks.Length;

        private void ArrayToQueue()
        {
            foreach (Task task in _tasks)
            {
                _tasksQueue.Enqueue(task);
            }
        }
        
    }
}