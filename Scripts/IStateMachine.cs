

namespace VideoJames.ScriptableFSM
{
    /// <summary>
    /// Keeps a Finite State Machine in action.
    /// The generic type is for passing in the object the statemachine is operating on.
    /// </summary>
    public interface IStateMachine<T> where T : IHaveState
    {
        string Name { get; }
        void Init(T stateHaver);
        void Tick(T stateHaver, float deltaTime);
    }
}

