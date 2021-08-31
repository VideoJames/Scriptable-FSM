

namespace VideoJames.ScriptableFSM
{
    public interface ICondition<T> where T : IHaveState
    {
        string Name { get; }
        bool IsMet(T stateHaver);
    }
}
