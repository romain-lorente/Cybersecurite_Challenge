using UnityEngine;
using UnityEngine.UI;

public class InventorySlotBehavior : MonoBehaviour
{
    public int slotID;
    public InventoryItem item;

    Button btn;
    bool isSelected;

    Color notSelectedColor = new Color(0.6f, 0.6f, 0.6f);
    Color selectedColor = new Color(1f, 1f, 1f);

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
        btn.image.sprite = (item != null)
            ? item.sprite
            : null;

        btn.image.color = isSelected
            ? selectedColor
            : notSelectedColor;

        //TODO : ne rien afficher si l'emplacement est vide
    }

    public void Unselect()
    {
        isSelected = false;
    }

    void SetItem()
    {
        //TODO : rendre impossible la sélection si l'emplacement est vide
        isSelected = Constants.GetInventoryManager().SetCurrentItem(item, slotID);
    }
}
