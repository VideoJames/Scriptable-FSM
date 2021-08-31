
using UnityEngine;


namespace VideoJames.ScriptableFSM.Samples
{
    public class SetCharacterAnimatorParameter : IAction<ICharacter>
    {
        public string Name => "No name";
        [SerializeField] private string parameterKey;
        // TODO: Add all animator parameter types

        public void Act(ICharacter stateHaver)
        {
            stateHaver.Animator.SetTrigger(parameterKey);
        }
    }
}