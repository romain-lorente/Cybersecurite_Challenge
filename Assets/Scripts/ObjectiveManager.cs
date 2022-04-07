using UnityEngine;
using UnityEngine.UI;

public class ObjectiveManager : MonoBehaviour
{
    public Objective[] objectives = new Objective[] { };

    int currentObjective = 0;
    Text objectiveText;

    void Start()
    {
        objectiveText = GameObject.FindGameObjectWithTag(Constants.ObjectiveTextTag).GetComponent<Text>();
    }

    void Update()
    {
        DisplayObjectiveText();
    }

    void DisplayObjectiveText()
    {
        if(currentObjective <= objectives.Length - 1)
        {
            objectiveText.text = objectives[currentObjective].description;
        }
        else
        {
            objectiveText.text = Constants.text_allObjectivesCompleted;
        }
    }

    public int GetProgress()
    {
        return currentObjective;
    }

    public void IncrementProgressCounter()
    {
        currentObjective++;
    }
}
