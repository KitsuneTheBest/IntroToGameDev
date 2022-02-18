using UnityEngine;

public class FallTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var playerMovement = other.GetComponent<PlayerMovement>();
        if (playerMovement == null) return;
        Debug.Log("Fail");
        playerMovement.enabled = false;
    }
}