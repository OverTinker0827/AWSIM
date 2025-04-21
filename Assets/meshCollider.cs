using UnityEngine;
using UnityEditor;

public class meshCollider : EditorWindow
{
    [MenuItem("Tools/Add MeshColliders to All Children")]
    static void AddMeshCollidersToChildren()
    {
        GameObject selected = Selection.activeGameObject;
        if (selected == null)
        {
            Debug.LogError("Please select a GameObject.");
            return;
        }

        int count = 0;

        foreach (Transform t in selected.GetComponentsInChildren<Transform>(true))
        {
            // Add MeshCollider only if it has a MeshFilter and doesn't already have a Collider
            if (t.GetComponent<MeshFilter>() != null && t.GetComponent<Collider>() == null)
            {
                t.gameObject.AddComponent<MeshCollider>();
                count++;
            }
        }

        Debug.Log($"✅ Added MeshCollider to {count} GameObject(s).");
    }
}

