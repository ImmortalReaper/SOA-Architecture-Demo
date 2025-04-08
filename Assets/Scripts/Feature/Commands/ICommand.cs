using System;

namespace Feature.Commands
{
    public interface ICommand
    {
        public bool CommandExecuted { get; }
        public void Execute();
        public event Action OnCompleted; 
    }
}
