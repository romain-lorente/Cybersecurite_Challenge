using System.Linq;
using UnityEngine;

public class GetItemAction : AbsAction
{
    public InventoryItem itemToCollect;

    InventoryManager mgr;

    void Start()
    {
        mgr = Constants.GetInventoryManager();
    }

    public override bool Execute()
    {
        bool success = mgr.AddItemToInventory(itemToCollect);
        if(success)
        {
            Destroy(gameObject);
        }
        else
        {
            GameObject panel = Constants.GetInventoryManager().inventoryFullPanel;
            panel.SetActive(true);
        }

        return success;
    }
}
