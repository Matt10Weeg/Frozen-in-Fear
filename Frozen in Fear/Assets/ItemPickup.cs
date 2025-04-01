using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item; // Het item dat opgepakt wordt

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory inventory = other.GetComponent<Inventory>();
            if (inventory != null)
            {
                inventory.VoegItemToe(item);
                Destroy(gameObject); // Item verdwijnt uit de wereld
            }
        }
    }
}