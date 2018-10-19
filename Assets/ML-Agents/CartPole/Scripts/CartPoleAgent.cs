using MLAgents;
using UnityEngine;

public class CartPoleAgent : Agent
{
    public GameObject cart;
    public GameObject pole;
    private Rigidbody cartRb;
    private Rigidbody poleRb;

    public override void AgentAction (float[] vectorAction, string textAction)
    {
        cartRb.velocity = new Vector3(
            Mathf.Clamp(vectorAction[0], -1f, 1f) * 10f, 0f, 0f);

        Vector3 targetDirection = pole.transform.position - cart.transform.position;

        float angle = Vector3.Angle(
            targetDirection,
            transform.right);

        if (cart.transform.position.x < -10 || cart.transform.position.x > 10)
        {
            AgentReset();
        }

        if (angle < 70 || angle > 110)
        {
            Done();
            AddReward(-1);
        }

        AddReward(0.1f);
    }

    public override void AgentReset ()
    {
        pole.transform.position = new Vector3(0f, 4f, 0f);
        pole.transform.rotation = Quaternion.identity;
        poleRb.velocity = Vector3.zero;
        poleRb.angularVelocity = Vector3.zero;
    }

    public override void CollectObservations ()
    {
        AddVectorObs(cart.transform.position);
        AddVectorObs(pole.transform.position);
    }

    public override void InitializeAgent ()
    {
        cartRb = cart.GetComponent<Rigidbody>();
        poleRb = pole.GetComponent<Rigidbody>();
    }

}
