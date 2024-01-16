using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Boids/Filter/Same Boids")]
public class SameBoidsFilter : ContextFilter
{
    public override List<Transform> Filter(BoidsAgent agent, List<Transform> original)
    {
        List<Transform> filtered = new List<Transform>();
        foreach (Transform item in original)
        {
            BoidsAgent itemAgent = item.GetComponent<BoidsAgent>();
            if (itemAgent != null && itemAgent.AgentBoid == agent.AgentBoid)
            {
                filtered.Add(item);
            }
        }
        return filtered;
    }
}
