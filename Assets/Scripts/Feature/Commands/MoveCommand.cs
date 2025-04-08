using System;
using Feature.Player.Movement;
using UnityEngine;

namespace Feature.Commands
{
    public class MoveCommand : ITickableCommand
    {
        private readonly PlayerMovement _playerMovement;
        private readonly Vector3 _target;
        private bool _commandExecuted = false;
    
        public bool CommandExecuted => _commandExecuted;
        public event Action OnCompleted;
        public MoveCommand(PlayerMovement playerMovement, Vector3 target)
        {
            _playerMovement = playerMovement;
            _target = target;
        }

        public void Execute()
        {
            _commandExecuted = true;
            _playerMovement.MoveTo(_target);
        }

        public void Tick()
        {
            if (_commandExecuted is false)
                return;
        
            if (_playerMovement.IsMoving is false)
                OnCompleted?.Invoke();
        }
    }
}
