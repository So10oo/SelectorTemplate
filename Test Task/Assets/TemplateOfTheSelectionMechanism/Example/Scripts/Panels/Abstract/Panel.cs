using System;
using UnityEngine;

namespace SelectionTemplate.Example
{
    public abstract class Panel : MonoBehaviour, IState
    {
        public Action OnEnter;
        public Action OnExit;
        public virtual void Enter()
        {
            OnEnter?.Invoke();
        }

        public virtual void Initialization(PanelStateMachine panelStateMachine)
        {
        }

        public virtual void Exit()
        {
            OnExit?.Invoke();
        }
    }
}
