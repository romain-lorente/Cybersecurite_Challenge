using UnityEngine;

/// <summary>
/// Comportement des objets présents dans la scène, sur lesquels on peut cliquer
/// </summary>
public class SceneItemBehavior : MonoBehaviour
{
    /// <summary>
    /// Enum des actions possibles lorsqu'on clique sur l'objet
    /// </summary>
    public enum SceneItemActions
    {
        ADD_TO_INVENTORY,
        OPEN_MENU
        //TODO : action d'utilisation de l'objet
    }

    public SceneItemActions action;
    public InventoryItem item;

    /// <summary>
    /// Effectue une action si l'on a cliqué sur l'objet
    /// </summary>
    void OnMouseDown()
    {
        DoOnClickAction();
    }

    void DoOnClickAction()
    {
        switch(action)
        {
            case SceneItemActions.ADD_TO_INVENTORY:
                Constants.GetInventoryManager().AddItemToInventory(item);
                Destroy(gameObject);
                break;

            case SceneItemActions.OPEN_MENU:
                //TODO : implémentation des menus contextuels
                Debug.Log("clic sur objet");
                break;

            //TODO : possiblité d'avoir plusieurs actions
        }
    }
}
