using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VideoJames.ScriptableFSM.Samples
{
    public class SetCharacterHealth : IAction<ICharacter>
    {
        public string Name => "No name";
        [SerializeField] private int newHealth;
        public void Act(ICharacter stateHaver)
        {
            stateHaver.Health = newHealth;
        }
    }
}