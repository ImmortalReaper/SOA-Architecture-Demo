using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class DisableInputOnUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private IInputBlockerService _inputBlockerService;
    
    [Inject]
    public void InjectDependencies(IInputBlockerService inputBlockerService) =>
        _inputBlockerService = inputBlockerService;

    public void OnPointerEnter(PointerEventData eventData) =>
        _inputBlockerService.BlockInput();

    public void OnPointerExit(PointerEventData eventData) =>
        _inputBlockerService.UnblockInput();
}
