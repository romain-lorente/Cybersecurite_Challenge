public class UseItemAction : AbsAction
{
    public InventoryItem itemToUse;
    public AbsAction nextAction;

    InventoryManager mgr;

    void Start()
    {
        mgr = Constants.GetInventoryManager();
    }

    public override bool Execute()
    {
        InventoryItem currentItem = mgr.GetCurrentItem();

        if (currentItem != null && itemToUse != null && currentItem.itemIdentifier == itemToUse.itemIdentifier)
        {
            mgr.RemoveUsedItemFromInventory();
            itemToUse = null;

            if(nextAction != null)
            {
                nextAction.Execute();
            }

            return true;
        }

        return false;
    }
}
