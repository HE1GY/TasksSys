using System;
using UnityEngine;

namespace TaskFolder
{
    public class TaskInteractor : MonoBehaviour
    {
        public event Action TaskStarted;
        
        [SerializeField] private SimpleTask _simpleTask; 

        private void OnEnable()
        {
            _simpleTask.Started += OnTaskStarted;
        }

        private void OnDisable()
        {
            _simpleTask.Started -=  OnTaskStarted;
            _simpleTask.Started -=  OnTaskStarted;
        }

        private void OnTaskStarted()
        {
            TaskStarted?.Invoke();
        }


        public void CompleteTask()
        {
            _simpleTask.InvokeCompleted();
        }
    }
}
