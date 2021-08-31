
using UnityEngine;

namespace VideoJames.ScriptableFSM.Samples
{
    public interface ICharacter : IHaveState
    {
        int Health { get; set; }
        int MaxHeath { get; }
        Animator Animator { get; }

    }
}