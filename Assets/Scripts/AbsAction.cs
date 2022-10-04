using UnityEngine;

public abstract class AbsAction : MonoBehaviour
{
    /// <summary>
    /// Tente d'exécuter une action et envoie true en cas de succès
    /// </summary>
    /// <returns></returns>
    public abstract bool Execute();
}
