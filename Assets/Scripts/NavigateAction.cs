using UnityEngine;

public class NavigateAction : AbsAction
{
    public GameObject destinationPoint; //Prend un objet comportant un point de navigation (donc qui possède un NavigationPoint) servant de destination
    public int showWithCurrentNavId; //Id du point de navigation pour lequel on affichera cet objet
    public int progressNeeded; //Progression minimale nécessaire pour afficher la flèche

    NavigationManager navMgr;
    ObjectiveManager objMgr;

    void Start()
    {
        navMgr = Constants.GetNavigationManager();
        objMgr = Constants.GetObjectiveManager();
    }

    void Update()
    {
        bool progressOk = objMgr.GetProgress() >= progressNeeded;
        bool active = progressOk && navMgr.GetCurrentNavigationId() == showWithCurrentNavId;
        gameObject.GetComponent<MeshRenderer>().enabled = active;
        gameObject.GetComponent<MeshCollider>().enabled = active;
    }

    public override bool Execute()
    {
        GameObject camera = Camera.main.gameObject;
        Transform destTransform = destinationPoint.transform;

        camera.transform.SetPositionAndRotation(destTransform.position, destTransform.rotation);
        navMgr.SetCurrentNavigationId(destinationPoint.GetComponent<NavigationPoint>().navigationPointId);

        return true;
    }
}
