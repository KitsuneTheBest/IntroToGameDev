using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float RotationSpeedAngle = 45f;
    public float SpeedMultiplier = 1f;
    public float MaxHeight = 3f;

    private float _startingPositionY;

    private void Awake()
    {
        _startingPositionY = transform.position.y;
    }

    private void Update()
    {
        transform.Rotate(0, RotationSpeedAngle * Time.deltaTime, 0);
        float y = Mathf.PingPong(Time.time * SpeedMultiplier, MaxHeight - _startingPositionY) + _startingPositionY;
        var coinPosition = transform.position;
        coinPosition.y = y;
        transform.position = coinPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        var playerMovement = other.GetComponent<PlayerMovement>();
        if (playerMovement == null) return;
        Debug.Log("Coin collected!");
        Destroy(gameObject);
    }
}