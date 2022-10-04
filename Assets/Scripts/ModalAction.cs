using UnityEngine;

public class ModalAction : AbsAction
{
    public GameObject modal; //La fen�tre � ouvrir/fermer


    public override bool Execute()
    {
        modal.SetActive(!modal.activeSelf);

        return true;
    }
}
