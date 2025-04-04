

Hotbar
using UnityEngine;
using UnityEngine.UI;

public class Hotbar : MonoBehaviour
{
    private readonly Item[] items = new Item[3];
#pragma warning disable IDE0044
    private int selectedSlot = 0;
    private Item currentEquippedItem;
#pragma warning restore IDE0044
    private Transform hand; // Verwijder readonly

    public Image[] slotIcons;
    public RectTransform highlight;

    void Start()
    {
        hand = GameObject.FindGameObjectWithTag("Player").transform.Find("Hand");
        if (hand == null)
        {
            Debug.LogError("Hand niet gevonden!");
        }
        if (slotIcons.Length != 3)
        {
            Debug.LogError("Hotbar moet 3 slotIcons hebben!");
        }
        for (int i = 0; i < slotIcons.Length; i++)
        {
            if (slotIcons[i] == null)
            {
                Debug.LogError("Slot icon " + i + " is null!");
            }
            slotIcons[i].enabled = false;
            slotIcons[i].gameObject.SetActive(true);
        }
        UpdateHighlight();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectSlot(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectSlot(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectSlot(2);
        }
    }

    public bool AddItem(Item item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = item;
                if (item.ItemIcon == null)
                {
                    Debug.LogError("Item icon is null voor " + item.ItemNameProperty);
                }
                slotIcons[i].sprite = item.ItemIcon;
                slotIcons[i].gameObject.SetActive(true);
                slotIcons[i].enabled = true;
                slotIcons[i].color = new Color(1, 1, 1, 1);
                Debug.Log("Item toegevoegd aan slot " + i + ": " + item.ItemNameProperty);
                Debug.Log("Icon enabled voor slot " + i + ": " + slotIcons[i].enabled);
                Debug.Log("Sprite ingesteld voor slot " + i + ": " + (slotIcons[i].sprite != null ? slotIcons[i].sprite.name : "null"));
                if (i == selectedSlot && currentEquippedItem == null)
                {
                    EquipItem(i);
                }
                return true;
            }
        }
        Debug.Log("Hotbar vol!");
        return false;
    }

    void SelectSlot(int slot)
    {
        if (slot < 0 || slot >= items.Length)
        {
            return;
        }
        selectedSlot = slot;
        UpdateHighlight();
    }

    void UpdateHighlight()
    {
        float slotWidth = 80f;
        highlight.anchoredPosition = new Vector2(-80f + (selectedSlot * slotWidth), 0);
        Debug.Log("Highlight positie ingesteld: " + highlight.anchoredPosition);
    }

    void EquipItem(int slot)
    {
        if (currentEquippedItem != null)
        {
            currentEquippedItem.Drop(currentEquippedItem.transform.position);
            currentEquippedItem = null;
        }
        if (items[slot] != null)
        {
            currentEquippedItem = items[slot];
            currentEquippedItem.PickUp(hand);
            Debug.Log("Item geëquipeerd: " + currentEquippedItem.ItemNameProperty);
        }
    }
}
