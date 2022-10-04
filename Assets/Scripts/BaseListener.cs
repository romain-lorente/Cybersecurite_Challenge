using UnityEngine;

public class BaseListener : MonoBehaviour
{
    public AbsAction action; //L'action � ex�cuter
    public bool triggersProgress; //True si la progression augmente apr�s avoir effectu� l'action
    public int progressNeededToTrigger; //Le compteur inclus dans ObjectiveManager doit �tre �gal � ce nombre pour d�clencher la progression

    ObjectiveManager objMgr;

    protected void Start()
    {
        objMgr = Constants.GetObjectiveManager();
    }

    protected void ExecuteAction()
    {
        //Si l'action a �t� effectu�e correctement, incr�menter le compteur de progression
        if(action.Execute() && triggersProgress && progressNeededToTrigger == objMgr.GetProgress())
        {
            objMgr.IncrementProgressCounter();
        }
    }
}
