using UnityEngine;

public class InputBlockerService : IInputBlockerService
{
    private int _blockCounter = 0;
    public bool IsInputBlocked => _blockCounter > 0;

    public void BlockInput() =>
        _blockCounter++;

    public void UnblockInput() =>
        _blockCounter = Mathf.Max(0, _blockCounter - 1);
}
