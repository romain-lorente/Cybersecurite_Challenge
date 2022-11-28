using UnityEngine.EventSystems;

public class ClickListener : BaseListener
{
    void OnMouseDown()
    {
        if(!EventSystem.current.IsPointerOverGameObject())
            ExecuteAction();
    }
}
