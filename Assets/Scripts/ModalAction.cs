using UnityEngine;

public class ModalAction : AbsAction
{
    public GameObject modal; //La fenêtre à ouvrir/fermer


    public override bool Execute()
    {
        modal.SetActive(!modal.activeSelf);

        return true;
    }
}
