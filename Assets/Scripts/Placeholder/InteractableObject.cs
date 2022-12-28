using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    protected virtual void Start()
    {
        gameObject.tag = "Interactable";
    }
    public abstract void Interact(Transform player);
}
