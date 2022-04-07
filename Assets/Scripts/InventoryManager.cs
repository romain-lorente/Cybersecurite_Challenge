using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    (InventoryItem item, int slot) currentItem = (null, -1);

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

    public void AddItemToInventory(InventoryItem i)
    {
        foreach (InventorySlotBehavior slot in GetSortedSlots())
        {
            if(slot.item == null)
            {
                slot.item = i;
                break;
            }
        }

        //TODO : gérer le cas où l'inventaire est plein
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
    /// <returns>True si l'objet était déjà sélectionné, sinon false</returns>
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
