using UnityEngine;

public class NavigationManager : MonoBehaviour
{
    int currentNavigationId; //Identifiant du point de navigation actuel, utile pour masquer les flèches de navigation inutiles

    public int GetCurrentNavigationId()
    {
        return currentNavigationId;
    }

    public void SetCurrentNavigationId(int id)
    {
        currentNavigationId = id;
    }
}
