using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _speed;

    public void Move(Vector3 offset)
    {
        _playerTransform.Translate(offset * _speed * Time.deltaTime);
    }
}
