using System;
using UnityEngine;

namespace TaskFolder
{
    [Serializable]
    public struct TaskInfo
    {
        public string Name;

        [TextArea(5, 10)] public string Description;
    }
}