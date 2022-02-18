using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 1f;

    private int _coinCounter;

    private int _directionIndex;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _coinCounter = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) _directionIndex = _directionIndex == 0 ? 1 : 0;
    }

    private void FixedUpdate()
    {
        var velocity = _directionIndex == 0 ? Vector3.forward : Vector3.right;
        velocity *= Speed;
        velocity.y = _rigidbody.velocity.y;
        _rigidbody.velocity = velocity;
    }

    private void OnDisable()
    {
        var velocity = Vector3.zero;
        velocity.y = _rigidbody.velocity.y;
        _rigidbody.velocity = velocity;
    }

    private void OnTriggerEnter(Collider other)
    {
        var coin = other.GetComponent<Coin>();
        if (coin == null) return;
        _coinCounter++;
        Debug.Log("Total coins: " + _coinCounter);
    }
}