using System;

internal interface ITask
{
    event Action Started;
    event Action Completed;
    void Start();
}