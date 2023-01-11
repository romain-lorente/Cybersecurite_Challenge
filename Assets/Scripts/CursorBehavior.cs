using UnityEngine;
using UnityEngine.UI;

public class CursorBehavior : MonoBehaviour
{
    void Update()
    {
        SetSprite();
    }

    void SetSprite()
    {
        InventoryItem item = Constants.GetInventoryManager().GetCurrentItem();

        if (item != null)
        {
            Texture2D tex = item.sprite.texture;

            Cursor.SetCursor(tex, new Vector2(Constants.CursorOffset, Constants.CursorOffset), CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }
}
