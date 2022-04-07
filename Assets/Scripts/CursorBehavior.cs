using UnityEngine;
using UnityEngine.UI;

public class CursorBehavior : MonoBehaviour
{
    void Update()
    {
        SetSprite();
        MoveOnCursor();
    }

    void SetSprite()
    {
        Image image = GetComponent<Image>();
        InventoryItem item = Constants.GetInventoryManager().GetCurrentItem();

        if (item != null)
        {
            image.sprite = item.sprite;
            image.color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            image.sprite = null;
            image.color = new Color(1f, 1f, 1f, 0f);
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
