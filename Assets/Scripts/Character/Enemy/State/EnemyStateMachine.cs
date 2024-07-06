namespace Simple2DRPG.Character
{
    public class EnemyStateMachine
    {
        public EnemyState CurrentState { get; private set; }

        public void Initialize(EnemyState startState)
        {
            CurrentState = startState;
            CurrentState.Enter();
        }

        public void ChangeState(EnemyState state)
        {
            CurrentState.Exit();
            CurrentState = state;
            CurrentState.Enter();
        }
    }
}