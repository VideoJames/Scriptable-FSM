
namespace VideoJames.ScriptableFSM
{
    public interface ITransition<T> where T : IHaveState
    {
        string Name { get; }
        bool FromAnyState { get; }
        IState<T> FromState { get; }
        IState<T> ToState { get; }
        bool HasMetConditions(T stateHaver);
    }
}

