using System.Collections.Generic;
using UnityEngine;

public class Containers : MonoBehaviour
{
    public static Containers ST {get; private set;}
    
    public Dictionary<GameObject, Health> healthContainer;
    private void Awake()
    {
        ST = this;
        healthContainer = new Dictionary<GameObject, Health>();
    }
}
