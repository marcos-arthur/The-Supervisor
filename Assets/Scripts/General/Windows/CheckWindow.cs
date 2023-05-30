using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWindow : MonoBehaviour
{
    public static CheckWindow instance;

    public List<string> stolenItemNames = new List<string>();

    [SerializeField] private GameObject selectionWindow;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if(ExplorerClose.Instance != null)
        {
            ExplorerClose.Instance.windowCloser();
        }

        Instantiate(selectionWindow);
    }

    public void addStolenItems(List<string> stolenItems)
    {
        stolenItemNames = stolenItems;
    }

    public void checkItems(List<GameObject> selectedItems)
    {
        int points = 0;
        foreach (GameObject item in selectedItems)
        {
            if (stolenItemNames.Contains(item.name))
            {
                points += 500;
                stolenItemNames.Remove(item.name);
            }
            else
            {
                points -= 500;
            }
        }

        if(stolenItemNames.Count > 0)
        {
            points -= 200 * stolenItemNames.Count;
        }

        if(points > 0)
        {
            AudioController.instance.PlayOneShot(FMODEventsController.instance.correctAnswerSound, transform.position);
        }
        else
        {
            AudioController.instance.PlayOneShot(FMODEventsController.instance.wrongAnswerSound, transform.position);
        }

        GlobalPointsController.instance.addPoints(points);
        stolenItemNames.Clear();
    }
}
