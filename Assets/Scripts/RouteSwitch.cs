using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;
using System;

public class RouteSwitch : MonoBehaviour
{
    private SplineFollower follower;

    private void Start()
    {
        follower = GetComponent<SplineFollower>();
        follower.onNode += OnNodePassed;
    }

    private void OnNodePassed(List<SplineTracer.NodeConnection> passed)
    {
        SplineTracer.NodeConnection nodeConnection = passed[0];
        Debug.Log(nodeConnection.node.name + " at point " + nodeConnection.point);
        double nodePercent = (double)nodeConnection.point / (follower.spline.pointCount - 1);
        double followerPercent = follower.UnclipPercent(follower.result.percent);
        float distancePastNode = follower.spline.CalculateLength(nodePercent, followerPercent);
        Debug.Log(nodePercent);

        Node.Connection[] connections = nodeConnection.node.GetConnections();
        follower.spline = connections[1].spline;
        double newnodePercent = (double)connections[1].pointIndex / (connections[1].spline.pointCount - 1);
        double newPercent = connections[1].spline.Travel(newnodePercent, distancePastNode, follower.direction);
        follower.SetPercent(newPercent);
        
    }
}
