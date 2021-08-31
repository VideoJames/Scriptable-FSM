

namespace VideoJames.ScriptableFSM
{
    public interface IAction<T> where T : IHaveState
    {
        string Name { get; }
        void Act(T stateHaver);
    }
}

