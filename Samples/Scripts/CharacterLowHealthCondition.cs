
using Sirenix.OdinInspector;
using UnityEngine;


namespace VideoJames.ScriptableFSM.Samples
{
    [InlineProperty]
    public class CharacterLowHealthCondition : ICondition<ICharacter>
    {
        public string Name => $"Health below {lowHealthThreshold}";
        [SerializeField, HideLabel] private int lowHealthThreshold;

        public bool IsMet(ICharacter stateHaver)
        {
            return stateHaver.Health < lowHealthThreshold;
        }
    }
}