Player
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private HotbarManager hotbar; // Verander Hotbar naar HotbarManager
    private Transform hand;

    void Start()
    {
        hotbar = FindObjectOfType<HotbarManager>(); // Verander Hotbar naar HotbarManager
        if (hotbar == null)
        {
            Debug.LogError("Hotbar niet gevonden!");
        }
        hand = transform.Find("Hand");
        if (hand == null)
        {
            Debug.LogError("Hand niet gevonden!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryPickupItem();
        }
    }

    void OnTriggerStay(Collider other)
    {
    }

    private void TryPickupItem()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 2f);
        foreach (Collider collider in colliders)
        {
            Item item = collider.GetComponent<Item>();
            if (item != null && !item.IsPickedUp)
            {
                if (hotbar != null && hotbar.AddItem(item))
                {
                    item.PickUp(hand);
                    Debug.Log("Item opgepakt door speler: " + item.ItemNameProperty);
                    return;
                }
                else
                {
                    Debug.LogWarning("Kon item niet toevoegen aan hotbar!");
                }
            }
        }
    }
}
