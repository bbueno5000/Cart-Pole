using MLAgents;
using UnityEngine;

public class CartPoleAgent : Agent
{
    public GameObject cart;
    public GameObject pole;
    private Rigidbody cartRb;

    public override void AgentAction (float[] vectorAction, string textAction)
    {
        cartRb.velocity = new Vector3(
            Mathf.Clamp(vectorAction[0], -1f, 1f) * 10f, 0f, 0f);
    }

    public override void AgentReset ()
    {
        this.transform.position = new Vector3(0f, -6f, 0f);
    }

    public override void CollectObservations ()
    {
        AddVectorObs(cart.transform.position);
        AddVectorObs(pole.transform.position);
    }

    public override void InitializeAgent ()
    {
        cartRb = cart.GetComponent<Rigidbody>();
    }

}
