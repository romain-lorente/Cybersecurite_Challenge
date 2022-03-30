using UnityEngine;

/// <summary>
/// Comportement des objets pr�sents dans la sc�ne, sur lesquels on peut cliquer
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
    }

    public SceneItemActions action;

    /// <summary>
    /// Effectue une action si l'on a cliqu� sur l'objet
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
                //TODO : impl�mentation de l'inventaire
                Destroy(gameObject);
                break;

            case SceneItemActions.OPEN_MENU:
                //TODO : impl�mentation des menus contextuels
                Debug.Log("clic sur objet");
                break;
        }
    }
}
