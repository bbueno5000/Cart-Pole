using MLAgents;
using UnityEngine;
using UnityEngine.UI;

public class Plane : MonoBehaviour
{
    public CartPoleAgent cartPoleAgent;

    private void OnTriggerEnter (Collider collider)
    {
        if (collider.tag == "spere")
        {
            cartPoleAgent.AddReward(-1f);
            cartPoleAgent.AgentReset();
        }
    }
}
