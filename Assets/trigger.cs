using UnityEngine;

public class trigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"[TRIGGER ENTERED] Object: {other.gameObject.name}");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"[TRIGGER EXITED] Object: {other.gameObject.name}");
    }
}

