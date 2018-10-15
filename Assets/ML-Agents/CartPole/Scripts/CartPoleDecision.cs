using MLAgents;
using System.Collections.Generic;
using UnityEngine;

public class CartPoleDecision : MonoBehaviour, Decision
{
    public GameObject cart;
    public GameObject pole;

    public float[] Decide(
        List<float> vectorObs,
        List<Texture2D> visualObs,
        float reward, bool done,
        List<float> memory)
    {
        Vector3 targetDirection = pole.transform.position - cart.transform.position;

        float angle = Vector3.Angle(
            targetDirection,
            transform.right);

        if (angle < 90) {
            return new float[1] {1};
        }
        else {
            return new float[1] {-1};
        }
    }

    public List<float> MakeMemory(
        List<float> vectorObs,
        List<Texture2D> visualObs,
        float reward, bool done,
        List<float> memory)
    {
        return new List<float>();
    }

}
