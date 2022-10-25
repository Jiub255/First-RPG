using UnityEngine;

// have usable item and equipment item subclasses
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName = "New Item";
    [TextArea(3, 20)]
    public string itemDescription = "Item Description";

    public Sprite itemIconSprite = null;

    public GameEventItem onRemoveItem;

    // stackable stuff
    public int amount = 1;

    public virtual void Use()
    {
        // use the item
        Debug.Log("Using " + name);
    }

    public void RemoveFromInventory()
    {
        // InvManager listens for this, removes from InvSO
        onRemoveItem.Raise(this);
    }
}