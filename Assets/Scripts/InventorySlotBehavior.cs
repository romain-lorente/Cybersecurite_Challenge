using UnityEngine;
using UnityEngine.UI;

public class InventorySlotBehavior : MonoBehaviour
{
    public int slotID;
    public InventoryItem item;

    Button btn;
    bool isSelected;

    Color notSelectedColor = new Color(1f, 1f, 1f);
    Color selectedColor = new Color(0.6f, 0.6f, 0.6f);
    Color emptySlotColor = new Color(1f, 1f, 1f, 0f);

    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SetItem);
    }

    /// <summary>
    /// Change le sprite et la couleur de l'emplacement selon les cas
    /// </summary>
    void FixedUpdate()
    {
        if (item != null)
        {
            btn.image.sprite = item.sprite;
            btn.image.color = (isSelected)
                ? selectedColor
                : notSelectedColor;
        }
        else
        {
            btn.image.sprite = null;
            btn.image.color = emptySlotColor;
        }
    }

    public void Unselect()
    {
        isSelected = false;
    }

    void SetItem()
    {
        if(item != null)
            isSelected = Constants.GetInventoryManager().SetCurrentItem(item, slotID);
    }
}
