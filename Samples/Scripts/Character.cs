
using Sirenix.OdinInspector;
using UnityEngine;

namespace VideoJames.ScriptableFSM.Samples
{
    public class Character : SerializedMonoBehaviour, ICharacter
    {
        public int Health { get; set; }

        public int MaxHeath => maxHealth;

        public Animator Animator => animator;

        [SerializeField] private int maxHealth;
        [SerializeField] private Animator animator;

        [SerializeField] private IStateMachine<ICharacter> stateMachine;

        private void Awake()
        {
            Health = MaxHeath;
            stateMachine.Init(this);
        }

        private void Update()
        {
            stateMachine.Tick(this, Time.deltaTime);
        }
    }
}
