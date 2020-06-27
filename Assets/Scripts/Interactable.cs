using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour {
    public float radius = 3f;
    bool isFocus = false;
    Transform player;
    bool hasInteracted = false;
    public Transform interactionTransform;
    public virtual void Interact() {
        // this method is meant to be overwritten
    }

    void Update() {
        if (isFocus && hasInteracted == false) {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= radius) {
                Interact();
                hasInteracted = true;
            }
        }
    }
    public void OnFocused(Transform playerTransform) {

        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
        
    }
    public void OnDefocused() {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }
    void OnDrawGizmosSelected() {
        if (interactionTransform == null) {
            interactionTransform = transform;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
