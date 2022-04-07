using UnityEngine;

public static class Constants
{
    public static string InventoryPanelTag = "InvPanel";
    public static string InventorySlotTag = "InvSlot";
    public static string ObjectivePanelTag = "ObjectivePanel";
    public static string ObjectiveTextTag = "ObjectiveText";

    public static int NumberOfSlots = 10;
    public static float CursorOffset = 0.05f;

    public static string text_allObjectivesCompleted = "Tous les objectifs sont atteints.";

    public enum ItemIdentifiers
    {
        DEBUG_USBDRIVE
    }

    public static InventoryManager GetInventoryManager()
    {
        return GameObject.FindGameObjectWithTag(InventoryPanelTag).GetComponent<InventoryManager>();
    }

    public static ObjectiveManager GetObjectiveManager()
    {
        return GameObject.FindGameObjectWithTag(ObjectivePanelTag).GetComponent<ObjectiveManager>();
    }
}