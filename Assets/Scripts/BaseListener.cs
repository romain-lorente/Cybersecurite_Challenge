using UnityEngine;

public class BaseListener : MonoBehaviour
{
    public AbsAction action; //L'action à exécuter
    public bool triggersProgress; //True si la progression augmente après avoir effectué l'action
    public int progressNeededToTrigger; //Le compteur inclus dans ObjectiveManager doit être égal à ce nombre pour déclencher la progression

    ObjectiveManager objMgr;

    protected void Start()
    {
        objMgr = Constants.GetObjectiveManager();
    }

    protected void ExecuteAction()
    {
        //Si l'action a été effectuée correctement, incrémenter le compteur de progression
        if(action.Execute() && triggersProgress && progressNeededToTrigger == objMgr.GetProgress())
        {
            objMgr.IncrementProgressCounter();
        }
    }
}
