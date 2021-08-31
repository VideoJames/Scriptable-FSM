
using UnityEngine;


namespace VideoJames.ScriptableFSM.Samples
{
    public class CharacterLowHealthCondition : ICondition<ICharacter>
    {
        public string Name => "No name";
        [SerializeField] private int lowHealthThreshold;

        public bool IsMet(ICharacter stateHaver)
        {
            return stateHaver.Health < lowHealthThreshold;
        }
    }
}