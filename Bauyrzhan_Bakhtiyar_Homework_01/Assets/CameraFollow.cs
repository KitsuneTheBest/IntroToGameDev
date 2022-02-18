using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Follow;

    public Vector3 _offsetFromFollowToCamera;
    public float _initialY;

    private void Awake()
    {
        _offsetFromFollowToCamera = transform.position - Follow.position;
        _initialY = transform.position.y;
    }

    private void LateUpdate()
    {
        var position = Follow.position + _offsetFromFollowToCamera;
        position.y = _initialY;
        transform.position = position;
    }
}