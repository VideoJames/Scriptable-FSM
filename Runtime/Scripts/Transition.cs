
using Sirenix.OdinInspector;
using UnityEngine;

namespace VideoJames.ScriptableFSM
{
    public class Transition<T> : ITransition<T> where T : IHaveState
    {
        public string Name => GetName();
        public bool FromAnyState => fromAnyState;
        public IState<T> FromState => fromState;
        public IState<T> ToState => toState;

        [SerializeField] private bool fromAnyState;
        [SerializeField, LabelText("From"), HideIf("fromAnyState")] private IState<T> fromState;
        [SerializeField, LabelText("To")] private IState<T> toState;
        [SerializeField, ListDrawerSettings(ListElementLabelName = "Name"), HideReferenceObjectPicker] private ICondition<T>[] conditions = new ICondition<T>[0];

        /// <summary>
        /// Checks all conditions and returns false if any are not met, otherwise returns true.
        /// </summary>
        /// <param name="stateHaver"></param>
        /// <returns></returns>
        public bool HasMetConditions(T stateHaver)
        {
            foreach(ICondition<T> condition in conditions)
            {
                if (!condition.IsMet(stateHaver))
                    return false;
            }
            return true;
        }

        #region Inspector Name
        private string GetName()
        {
            var from = fromAnyState ? "Any state" : FromState != null ? FromState.Name : "NULL";
            var to = ToState != null ? ToState.Name : "NULL";
            var conditionNames = conditions != null && conditions.Length > 0 ? "|| " : "NO CONDITIONS";

            for (var i = 0; i < conditions.Length; i++)
            {
                var condition = conditions[i];
                if (condition == null) continue;
                conditionNames += condition.Name;
                if (i < conditions.Length - 1)
                {
                    conditionNames += " AND ";
                }
            }

            return $"{from} ---> {to} {conditionNames}";
        }
        #endregion
    }
}