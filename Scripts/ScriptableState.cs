
using UnityEngine;
using Sirenix.OdinInspector;

namespace VideoJames.ScriptableFSM
{
    public abstract class ScriptableState<T> : SerializedScriptableObject, IState<T> where T : IHaveState
    {
        public string Name => name;
        [SerializeField, ListDrawerSettings(ListElementLabelName = "Name"), HideReferenceObjectPicker] private IAction<T>[] onEnterActions = new IAction<T>[0];
        [SerializeField, ListDrawerSettings(ListElementLabelName = "Name"), HideReferenceObjectPicker] private IAction<T>[] onUpdateActions = new IAction<T>[0];
        [SerializeField, ListDrawerSettings(ListElementLabelName = "Name"), HideReferenceObjectPicker] private IAction<T>[] onExitActions = new IAction<T>[0];

        public virtual void Enter(T stateHaver)
        {
            foreach (IAction<T> action in onEnterActions)
            {
                action.Act(stateHaver);
            }
        }

        public virtual void Tick(T stateHaver, float deltaTime)
        {
            foreach (IAction<T> action in onUpdateActions)
            {
                action.Act(stateHaver);
            }
        }

        public virtual void Exit(T stateHaver)
        {
            foreach (IAction<T> action in onExitActions)
            {
                action.Act(stateHaver);
            }
        }
    }
}