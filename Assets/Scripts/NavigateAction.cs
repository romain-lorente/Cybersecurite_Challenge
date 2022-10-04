using UnityEngine;

public class NavigateAction : AbsAction
{
    public GameObject destinationPoint; //Prend un objet comportant un point de navigation (donc qui possède un NavigationPoint) servant de destination
    public int showWithCurrentNavId; //Id du point de navigation pour lequel on affichera cet objet

    NavigationManager navMgr;

    void Start()
    {
        navMgr = Constants.GetNavigationManager();
    }

    void Update()
    {
        bool active = navMgr.GetCurrentNavigationId() == showWithCurrentNavId;
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
