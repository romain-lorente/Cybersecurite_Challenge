using UnityEngine;

/// <summary>
/// Comportement des objets pr�sents dans la sc�ne, sur lesquels on peut cliquer
/// </summary>
public class SceneItemBehavior : MonoBehaviour
{
    public bool isCollectableItem;
    public bool hasContextualMenu;
    public bool hasUsableItemInteraction;

    public InventoryItem itemToCollect;
    public InventoryItem itemToUse;

    InventoryManager mgr;

    void Start()
    {
        mgr = Constants.GetInventoryManager();
    }

    /// <summary>
    /// Effectue une action si l'on a cliqu� sur l'objet
    /// </summary>
    void OnMouseDown()
    {
        DoOnClickAction();
    }

    void DoOnClickAction()
    {
        if(hasUsableItemInteraction)
        {
            InventoryItem currentItem = mgr.GetCurrentItem();

            if (currentItem != null && itemToUse != null && currentItem.itemIdentifier == itemToUse.itemIdentifier)
            {
                //TODO : action apr�s avoir utilis� l'objet
                mgr.RemoveUsedItemFromInventory();
                itemToUse = null;
            }
        }
        else if(hasContextualMenu)
        {
            //TODO : ouverture d'un menu
            Debug.Log("ouverture menu");
        }
        else if(isCollectableItem)
        {
            mgr.AddItemToInventory(itemToCollect);
            Destroy(gameObject);
        }
    }
}
