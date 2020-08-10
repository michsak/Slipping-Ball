using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] Transform torus;
    [SerializeField] float anglePerTime;

    void FixedUpdate()
    {
        torus.transform.Rotate(0, 0, anglePerTime);
    }

    public void SetAnglePerTime(float val)
    {
        anglePerTime = val;
    }

    public void SetTorus(Transform transform)
    {
        torus = transform;
    }
}
