using UnityEngine;

/// <summary>
/// Comportement des objets pr�sents dans la sc�ne, sur lesquels on peut cliquer
/// </summary>
public class SceneItemBehavior : MonoBehaviour
{
    public bool isCollectableItem;
    public bool hasContextualMenu;
    public bool hasUsableItemInteraction;
    public bool triggersProgress;
    public int progressNeededToTrigger; //Le compteur inclus dans ObjectiveManager doit �tre �gal � ce nombre pour d�clencher la progression

    public InventoryItem itemToCollect;
    public InventoryItem itemToUse;

    InventoryManager mgr;
    ObjectiveManager objMgr;

    void Start()
    {
        mgr = Constants.GetInventoryManager();
        objMgr = Constants.GetObjectiveManager();
    }

    /// <summary>
    /// Effectue une action si l'on a cliqu� sur l'objet
    /// </summary>
    void OnMouseDown()
    {
        if(DoOnClickAction() && triggersProgress && progressNeededToTrigger == objMgr.GetProgress())
        {
            objMgr.IncrementProgressCounter();
        }
    }

    bool DoOnClickAction()
    {
        if(hasUsableItemInteraction)
        {
            InventoryItem currentItem = mgr.GetCurrentItem();

            if (currentItem != null && itemToUse != null && currentItem.itemIdentifier == itemToUse.itemIdentifier)
            {
                //TODO : action apr�s avoir utilis� l'objet
                mgr.RemoveUsedItemFromInventory();
                itemToUse = null;

                return true;
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

            return true;
        }

        return false;
    }
}
