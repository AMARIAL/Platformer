using System.Collections.Generic;
using UnityEngine;

public class Containers : MonoBehaviour
{
    public static Containers ST {get; private set;}
    
    public Dictionary<GameObject, Health> healthContainer = new Dictionary<GameObject, Health>();
    public Dictionary<GameObject, Healer> healerContainer = new Dictionary<GameObject, Healer>();
    private void Awake()
    {
        ST = this;
    }
}
