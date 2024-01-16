using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boids/Filter/Physics Layer")]
public class PhysicsLayerFilter : ContextFilter
{
    public LayerMask mask;

    public override List<Transform> Filter(BoidsAgent agent, List<Transform> original)
    {
        List<Transform> filtered = new List<Transform>();
        foreach (Transform i in original)
        {
            if (mask == (mask | (1 << i.gameObject.layer)))
            {
                filtered.Add(i);
            }
        }
        return filtered;
    }
}
