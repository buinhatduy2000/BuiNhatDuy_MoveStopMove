using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState<T>
{
    public void OnEnter(T go);
    public void OnExecute(T go);
    public void OnExit(T go);
}
