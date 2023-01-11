using UnityEngine.EventSystems;
using UnityEngine;

public class ClickListener : BaseListener
{
    void OnMouseDown()
    {
        if(!EventSystem.current.IsPointerOverGameObject())
            ExecuteAction();
    }
}
