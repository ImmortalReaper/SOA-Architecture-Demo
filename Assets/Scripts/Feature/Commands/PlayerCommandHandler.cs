using System;
using Core.Input;
using Feature.Player.Movement;
using Feature.PlayerData;
using UnityEngine;
using Zenject;

namespace Feature.Commands
{
    public class PlayerCommandHandler : IInitializable, IDisposable
    {
        private readonly IInputService _inputService;
        private readonly CommandQueue _commandQueue;
        private readonly PlayerEntityModel _playerEntityModel;

        public PlayerCommandHandler(IInputService inputService, CommandQueue commandQueue, PlayerEntityModel playerEntityModel)
        {
            _inputService = inputService;
            _playerEntityModel = playerEntityModel;
            _commandQueue = commandQueue;
        }

        public void Initialize() =>
            _inputService.OnInputPositionPerformed += OnClick;

        public void Dispose() =>
            _inputService.OnInputPositionPerformed -= OnClick;
    
        private void OnClick(Vector2 screenPos)
        {
            if(_playerEntityModel.PlayerEntity == null)
                return;
        
            if(_playerEntityModel.PlayerEntity.TryGetComponent(out PlayerMovement playerMovement))
                _commandQueue.Enqueue(new MoveCommand(playerMovement, screenPos));
        }
    }
}