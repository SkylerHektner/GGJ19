using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] private GameObject parent; // This object should hold the children to be activated.

    private ITriggerable[] triggerables;

    void Start()
    {
        triggerables = parent.GetComponentsInChildren<ITriggerable>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider c)
    {
        Debug.Log("Triggered");
        if(c.tag == "Player")
        {
            foreach(ITriggerable t in triggerables)
            {
                t.Activate();
            }
        }
    }
}
