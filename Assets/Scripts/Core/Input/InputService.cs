using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class InputService : IInputService, IInitializable, IDisposable 
{
    private const string PLAYER_ACTION_MAP = "Player";
    private const string INPUT_POSITION_ACTION = "InputPosition";
    private readonly InputActionAsset _inputActions;
    private InputAction _interactionAction;
    private IInputBlockerService _inputBlockerService;
    public event Action<Vector2> OnInputPositionPerformed;

    public InputService(InputActionAsset inputActionAsset, IInputBlockerService inputBlockerService)
    {
        _inputActions = inputActionAsset;
        _inputBlockerService = inputBlockerService;
    }

    public void Initialize() 
    {
        _inputActions.Enable();
        _interactionAction = _inputActions.FindActionMap(PLAYER_ACTION_MAP).FindAction(INPUT_POSITION_ACTION);
        
        _interactionAction.performed += OnInputPosition;
    }

    public void Dispose() 
    {
        _inputActions.Disable();
        _interactionAction.performed -= OnInputPosition;
    }
    
    public void OnInputPosition(InputAction.CallbackContext context) 
    {
        if(_inputBlockerService.IsInputBlocked)
            return;
        
        if (context.performed)
            OnInputPositionPerformed?.Invoke(Pointer.current.position.ReadValue());
    }
}
