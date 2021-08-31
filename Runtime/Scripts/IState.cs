
namespace VideoJames.ScriptableFSM
{
    public interface IState<T> where T : IHaveState
    {
        string Name { get; }
        void Enter(T stateHaver);
        void Tick(T stateHaver, float deltaTime);
        void Exit(T stateHaver);
    }
}