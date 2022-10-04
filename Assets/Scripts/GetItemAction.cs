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
        mgr.AddItemToInventory(itemToCollect);
        Destroy(gameObject);

        return true;
    }
}
