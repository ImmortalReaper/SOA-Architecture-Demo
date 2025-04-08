using System.Collections.Generic;
using Zenject;

namespace Feature.Commands
{
    public class CommandQueue : ITickable
    {
        private readonly Queue<ICommand> _queue = new();
        private ICommand _currentCommand;
    
        public void Enqueue(ICommand command)
        {
            _queue.Enqueue(command);
            if (_currentCommand == null)
                StartNextCommand();
        }

        private void StartNextCommand()
        {
            if (_queue.Count > 0)
            {
                _currentCommand = _queue.Dequeue();
                _currentCommand.OnCompleted += OnCommandCompleted;
                _currentCommand.Execute();
            }
        }

        private void OnCommandCompleted()
        {
            if (_currentCommand != null)
            {
                _currentCommand.OnCompleted -= OnCommandCompleted;
                _currentCommand = null;
                StartNextCommand();
            }
        }

        public void Tick()
        {
            if (_currentCommand == null)
                return;
        
            if (_currentCommand is ITickableCommand tickable)
                tickable.Tick();
        }
    }
}
