using UnityEngine;

namespace TaskFolder
{
    public class TasksRunner : MonoBehaviour
    {
        [SerializeField] private Task _mainTask;

        private void Start()
        {
            _mainTask.Start();
        }
    }
}