using UnityEngine;

[CreateAssetMenu(fileName = "Nieuw Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemNaam;
    public Sprite icoon; // Voor de UI-weergave
    public int itemID;
}
