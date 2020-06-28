using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    void Start()
    {
        Vector3 vec = new Vector3(5, 0, 0);
        transform.Translate(vec);
        
    }
}