using UnityEngine;

namespace TaskFolder
{
    [CreateAssetMenu(fileName = "SimpleTask",menuName = "SO/Simple Task")]
    public  class SimpleTask : Task
    {
        private bool _isActive;
        
        public override void Start()
        {
            base.Start();
            
            Debug.Log($"Start sub {this.name}");//////////////
            _isActive = true;
        }
        public void InvokeCompleted()
        {
            if(_isActive)
            {
                Debug.Log($"Complete sub {this.name}");///////////////
            
                _isActive = false;
                base.Complete();
            }
       
        }
    }
}