using UnityEngine;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    private float _speed;
    private float _targetPointStopDistance;
    private Vector3 _targetPosition;
    private bool _isMoving = false;
    
    public bool IsMoving => _isMoving;
    public float Speed => _speed;
    
    [Inject]
    public void InjectDependencies(PlayerConfig playerConfig)
    {
        _speed = playerConfig.PlayerSpeed;
        _targetPointStopDistance = playerConfig.PlayerTargetPointStopDistance;
    }
    
    private void Update()
    {
        if (_isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, _targetPosition) < _targetPointStopDistance)
                _isMoving = false;
        }
    }
    
    public void SetPlayerSpeed(float speed) => 
        _speed = speed;
    
    public void MoveTo(Vector3 target)
    {
        _targetPosition = target;
        _isMoving = true;
    }
}
