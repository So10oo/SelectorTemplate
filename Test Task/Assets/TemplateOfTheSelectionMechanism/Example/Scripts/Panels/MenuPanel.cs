namespace SelectionTemplate.Example
{
    public class MenuPanel : Panel
    {
        public override void Enter()
        {
            base.Enter();
            gameObject.SetActive(true);
        }

        public override void Exit()
        {
            base.Exit();
            gameObject.SetActive(false);
        }
    }
}

