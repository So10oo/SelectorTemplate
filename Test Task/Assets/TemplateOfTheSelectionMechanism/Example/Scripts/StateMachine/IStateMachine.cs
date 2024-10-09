namespace SelectionTemplate.Example
{
    public interface IStateMachine<TypeState> where TypeState : IState
    {
        public void ChangeState(TypeState newPanel);
    }
}