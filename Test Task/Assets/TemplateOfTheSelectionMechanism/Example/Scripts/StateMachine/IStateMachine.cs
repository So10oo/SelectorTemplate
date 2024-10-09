namespace SelectionTemplate.Example
{
    public interface IStateMachine<TypeState>
    {
        public void ChangeState(TypeState newPanel);
    }
}