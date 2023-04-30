using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskbarController : MonoBehaviour
{
    private bool[] itens = { false, false, false, false, false };
    private Transform[] allChildren;

    // Start is called before the first frame update
    void Start()
    {
        allChildren = GetComponentsInChildren<Transform>();

        // Debug.Log(allChildren.Length);

        // allChildren[1].gameObject.SetActive(false);

        addIcon();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addIcon()
    {
        Debug.Log("teste");
        Debug.Log(allChildren.Length);
        for (int i = 0; i < allChildren.Length; i++)
        {
            if (itens[i])
            {
                Debug.Log("teste");
            }
        }
    }
}
