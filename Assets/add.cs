using UnityEngine;

public class add : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Start the recursive process from the parent object
        AddMeshColliderToLeafNodes(transform);
    }

    // Recursive function to add MeshCollider to leaf nodes
    void AddMeshColliderToLeafNodes(Transform parent)
    {
        // Check if the current object has no children
        if (parent.childCount == 0)
        {
            // If no children, this is a leaf node (grandchild, great-grandchild, etc.)
            if (parent.GetComponent<MeshCollider>() == null)
            {
                // Add MeshCollider if not already present
                parent.gameObject.AddComponent<MeshCollider>();
            }
        }
        else
        {
            // If there are children, recurse into each child
            foreach (Transform child in parent)
            {
                AddMeshColliderToLeafNodes(child);
            }
        }
    }
}

