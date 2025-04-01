using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public GameObject slotPrefab;  // Het UI-slot prefab
    public Transform slotParent;   // De Grid Layout waar de slots in komen

    public void UpdateUI()
    {
        // Verwijder oude slots
        foreach (Transform child in slotParent)
        {
            Destroy(child.gameObject);
        }

        // Voeg nieuwe slots toe voor elk item
        foreach (Item item in inventory.items)
        {
            GameObject slot = Instantiate(slotPrefab, slotParent);
            Image icon = slot.GetComponentInChildren<Image>();
            if (icon != null)
            {
                icon.sprite = item.icoon;
            }
        }
    }
}
