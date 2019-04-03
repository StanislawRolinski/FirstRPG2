using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEnter : MonoBehaviour
{
    public string transitionName;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerController.Instance.AreaTransitionName != null)
        {
            if (transitionName == PlayerController.Instance.AreaTransitionName)
            {
                PlayerController.Instance.transform.position = transform.position;
            }
        }
    }
}
