using UnityEngine;

public class CursorBehavior : MonoBehaviour
{
    void Update()
    {
        SetSprite();
        MoveOnCursor();
    }

    void SetSprite()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        InventoryItem item = Constants.GetInventoryManager().GetCurrentItem();

        if (item != null)
        {
            renderer.sprite = item.sprite;
        }
        else
        {
            renderer.sprite = null;
        }
    }

    void MoveOnCursor()
    {
        Canvas canvas = transform.parent.GetComponent<Canvas>();
        Camera renderCamera = canvas.worldCamera;

        Vector3 screenPoint = Input.mousePosition;
        screenPoint.z = canvas.planeDistance;

        Vector3 worldPoint = renderCamera.ScreenToWorldPoint(screenPoint);
        worldPoint.x += Constants.CursorOffset;
        worldPoint.y -= Constants.CursorOffset;
        transform.position = worldPoint;
    }
}
