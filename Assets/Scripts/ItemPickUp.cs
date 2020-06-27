using UnityEngine;
public class ItemPickUp : Interactable {
    public Item item;
    public override void Interact() {
        base.Interact();

        PickUp();
    }

    void PickUp() {

        Debug.Log("picking up item" + item.name);
        Inventory.instance.Add(item);
        // add to inventory
        Destroy(gameObject);
    }
}
