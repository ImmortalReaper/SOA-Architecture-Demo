namespace Feature.Commands
{
    public interface ITickableCommand : ICommand
    {
        public void Tick();
    }
}
