using UnityEngine;

public class scriptAdd : MonoBehaviour
{
    void Start()
    {
        AddTreeScriptToLeafNodes(transform);
    }

    void AddTreeScriptToLeafNodes(Transform parent)
    {
        if (parent.childCount == 0)
        {
            // Check if "tree" script is already added
            if (parent.GetComponent<npc>() == null)
            {
                parent.gameObject.AddComponent<npc>();
                Debug.Log("tree script added to: " + parent.name);
            }
        }
        else
        {
            foreach (Transform child in parent)
            {
                AddTreeScriptToLeafNodes(child);
            }
        }
    }
}

