public interface IInputBlockerService
{
    public bool IsInputBlocked { get; }
    public void BlockInput();
    public void UnblockInput();
}
