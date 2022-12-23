using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventoryFullPanel;
    (InventoryItem item, int slot) currentItem = (null, -1);
    Text itemDescText;

    void Start()
    {
        itemDescText = GameObject.FindGameObjectWithTag(Constants.ItemDescriptionTextTag).GetComponent<Text>();
        itemDescText.text = Constants.text_defaultItemDescription;
    }

    void Update()
    {
        itemDescText.text = currentItem.item != null
            ? currentItem.item.description
            : Constants.text_defaultItemDescription;
    }

    InventorySlotBehavior[] GetSortedSlots()
    {
        List<GameObject> slotObjects = GameObject.FindGameObjectsWithTag(Constants.InventorySlotTag).ToList();
        InventorySlotBehavior[] slots = new InventorySlotBehavior[Constants.NumberOfSlots];

        for (int i = 0; i < Constants.NumberOfSlots; i++)
        {
            GameObject obj = slotObjects.FirstOrDefault(
                s => s.GetComponent<InventorySlotBehavior>().slotID == i
            );

            if (obj != null)
                slots[i] = obj.GetComponent<InventorySlotBehavior>();
        }

        return slots;
    }

    public bool AddItemToInventory(InventoryItem i)
    {
        foreach (InventorySlotBehavior slot in GetSortedSlots())
        {
            if(slot.item == null)
            {
                slot.item = i;
                return true;
            }
        }

        return false;
    }

    public void RemoveUsedItemFromInventory()
    {
        GetSortedSlots()[currentItem.slot].item = null;

        UnselectAllButtons();
        currentItem = (null, -1);
    }

    /// <summary>
    /// Définit l'objet tenu. Si l'on clique sur le même emplacement alors que l'on tient déjà l'objet, alors il est retiré.
    /// </summary>
    /// <param name="i">Objet</param>
    /// <param name="s">Emplacement</param>
    /// <returns>True si l'objet est sélectionné avec succès, sinon false</returns>
    public bool SetCurrentItem(InventoryItem i, int s)
    {
        UnselectAllButtons();

        bool isAlreadySelected = currentItem.slot == s;

        currentItem = isAlreadySelected
            ? (null, -1)
            : (i, s);

        return !isAlreadySelected;
    }

    void UnselectAllButtons()
    {
        foreach (InventorySlotBehavior slot in GetSortedSlots())
        {
            if(slot != null)
                slot.Unselect();
        }
    }

    public InventoryItem GetCurrentItem()
    {
        return currentItem.item;
    }
}
