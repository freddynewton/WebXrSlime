using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftbodyBallController : MonoBehaviour
{
    [SerializeField] private float _springForce = 100f;
    [SerializeField] private float _damping = 0.2f;

    [SerializeField] private float _maxDistance = 0.5f;
    [SerializeField] private float _minDistance = 0.1f;

    private List<SpringJoint> _joints = new List<SpringJoint>();

    private void Awake()
    {
        var joints = GetComponentsInChildren<SpringJoint>(true);
        foreach (var joint in joints)
        {
            _joints.Add(joint);
            joint.spring = _springForce;
            joint.damper = _damping;

            joint.minDistance = _minDistance;
            joint.maxDistance = _maxDistance;
        }
    }
}
