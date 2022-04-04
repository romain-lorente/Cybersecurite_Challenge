using UnityEngine;

public static class Constants
{
    public static string InventoryPanelTag = "InvPanel";
    public static string InventorySlotTag = "InvSlot";

    public static int NumberOfSlots = 10;

    public enum ItemIdentifiers
    {
        DEBUG_USBDRIVE
    }

    public static InventoryManager GetInventoryManager()
    {
        return GameObject.FindGameObjectWithTag(InventoryPanelTag).GetComponent<InventoryManager>();
    }
}
