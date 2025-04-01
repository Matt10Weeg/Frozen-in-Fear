using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    public void VoegItemToe(Item nieuwItem)
    {
        items.Add(nieuwItem);
        Debug.Log(nieuwItem.itemNaam + " is toegevoegd aan de inventory!");
        FindObjectOfType<InventoryUI>().UpdateUI(); // UI verversen
    }

    public void VerwijderItem(Item item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Debug.Log(item.itemNaam + " is verwijderd uit de inventory!");
            FindObjectOfType<InventoryUI>().UpdateUI(); // UI verversen
        }
    }
}