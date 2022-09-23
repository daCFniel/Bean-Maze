using UnityEngine;

public class AttachToParent : MonoBehaviour
{
    public Transform child;
    public Transform parent;
    void Start()
    {
        //Make ObjectA's position match objectB
        child.position = parent.position;

        //Now parent the object so it is always there
        child.parent = parent;
    }
}
