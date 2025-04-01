using UnityEngine;

public class Item : MonoBehaviour
{
    public string ItemName = "Zwaard";
    public Sprite ItemIcon;
    private bool isPickedUp = false;

    public bool IsPickedUp
    {
        get { return isPickedUp; }
    }

    public string ItemNameProperty
    {
        get { return ItemName; }
    }

    public void PickUp(Transform hand)
    {
        isPickedUp = true;
        EquipToHand(hand);
    }

    private void EquipToHand(Transform hand)
    {
        transform.SetParent(hand);
        transform.localPosition = new Vector3(0, 0, 0.2f);
        transform.localRotation = Quaternion.Euler(180, 270, 50);
        transform.localScale = Vector3.one * 0.5f;
        gameObject.SetActive(true);
        Debug.Log("Zwaard in hand gezet! Ouder: " + transform.parent.name +
                  ", Local Pos: " + transform.localPosition +
                  ", World Pos: " + transform.position +
                  ", Scale: " + transform.localScale);
    }

    public void Drop(Vector3 position)
    {
        isPickedUp = false;
        transform.SetParent(null);
        transform.SetPositionAndRotation(position, Quaternion.identity);
        gameObject.SetActive(true);
        Debug.Log("Zwaard laten vallen!");
    }
}