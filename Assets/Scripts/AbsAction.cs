using UnityEngine;

public abstract class AbsAction : MonoBehaviour
{
    /// <summary>
    /// Tente d'ex�cuter une action et envoie true en cas de succ�s
    /// </summary>
    /// <returns></returns>
    public abstract bool Execute();
}
