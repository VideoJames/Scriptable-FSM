
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;
namespace VideoJames.ScriptableFSM
{
    public abstract class ScriptableStateMachine<T> : SerializedScriptableObject, IStateMachine<T> where T : IHaveState
    {
        public string Name => "No name";
        [SerializeField] private IState<T> initialState;
        [SerializeField, ListDrawerSettings(ListElementLabelName = "Name"), HideReferenceObjectPicker] private ITransition<T>[] transitions = new ITransition<T>[0];

        [NonSerialized] private IState<T> currentState;

        public virtual void Init(T stateHaver)
        {
            SetState(stateHaver, initialState);
        }

        public virtual void Tick(T stateHaver, float deltaTime)
        {
            currentState.Tick(stateHaver, deltaTime);
            foreach (ITransition<T> transition in transitions)
            {
                if (currentState == transition.FromState)
                {
                    if (transition.HasMetConditions(stateHaver))
                    {
                        SetState(stateHaver, transition.ToState);
                    }
                    break;
                }
            }
        }

        protected virtual void SetState(T stateHaver, IState<T> newState)
        {
            currentState?.Exit(stateHaver);
            currentState = newState;
            currentState?.Enter(stateHaver);
        }
    }
}