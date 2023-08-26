using UnityEngine;
using UnityEngine.UI;

public class ModalButtonAction : AbsAction
{
    public AbsAction nextAction;
    public bool disablesModal; //Si true, désactive de manière définitive la modale une fois l'action effectuée
    public bool disablesThisButton; //Si true, désactive le bouton lié à cette action une fois l'action effectuée
    public bool closesModal = true; //Si true, ferme la fenêtre après l'exécution de l'action

    private void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(DoAction);
    }

    void DoAction()
    {
        Execute();
    }

    public override bool Execute()
    {
        GameObject modal = transform.parent.gameObject;
        Button btn = gameObject.GetComponent<Button>();

        if(nextAction != null && !nextAction.Execute())
        {
            return false;
        }

        if (disablesThisButton)
            btn.interactable = false;

        if (disablesModal)
            Destroy(modal);

        if (modal != null && closesModal)
            modal.SetActive(false);

        return true;
    }
}
