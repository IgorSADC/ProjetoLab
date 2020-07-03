using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOVBehavior
{
    private FOVStatus status;
    private List<Transform> targets;
    private Transform transform;
    private Vector2 cPosition;
    [SerializeField]

    public FOVBehavior(Transform t, FOVStatus fStatus){
        this.status = fStatus;
        this.transform = t;

    }
    private Vector2 GetVectorFromTransform(Transform t) => new Vector2 (t.position.x, t.position.y);

    public void UpdateDir(){
        cPosition = GetVectorFromTransform(transform);
    }
    public bool CheckTarget(Transform t){
        Vector2 tPos = GetVectorFromTransform(t);
        return CheckDistance(tPos) && CheckAngle(tPos);
    }

    private bool CheckDistance(Vector2 tPosition) => Vector2.Distance(cPosition, tPosition) < status.maxDistance;

    private bool CheckAngle(Vector2 tPosition){ 
        Vector2 dirToT = (tPosition - cPosition).normalized;
        Vector3 dir = transform.right;
        Vector2 newDir = new Vector2(dir.x, dir.y).normalized;
        return Vector2.Angle(newDir, dirToT) < status.maxAngle; 
    }

    public void drawArc(LineRenderer line){
        int resolution = line.positionCount;
        Vector3[] positions = new Vector3[resolution];
        positions[0] = transform.position;
        positions[1] = transform.position + transform.right * status.maxDistance;
        positions[resolution -1] = transform.position;
        float step = status.maxAngle/(resolution-3);
        for(int i = 1; i < resolution -2; i++){
            float angle = step*i * Mathf.Deg2Rad;

            positions[i+1] = transform.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle),0) * status.maxDistance;
        }
        Debug.Log(positions);
        line.SetPositions(positions);
    }

/*
    public FOVBehavior(FOVStatus status, Transform transform){
        this.status = status;
        this.transform = transform;
    }

    public void ChangeFOVStatus(FOVStatus status){
        this.status = status;
    }

    public void AddTarget(Transform t){
        targets.Add(t);
    }

    public void RemoveTarget(Transform t){
        targets.Remove(t);

    }

    public bool[] CheckTargets(List<Transform> targets,Vector2 dir){
        int n = targets.Count;
        bool[] bools = new bool[n];
        for(int i =0; i< n; i++){
            Transform cTarget = targets[i];
            bools[i] = CheckDistance(cTarget) && CheckAngle(cTarget, dir);
        }
        return bools;
    }

    public bool CheckTarget(Transform t,Vector2 dir) {

        return CheckDistance(t) && CheckAngle(t, dir);
    }


    


    private bool CheckDistance(Transform t) => 
    Vector2.Distance(GetVectorFromTransform(transform), GetVectorFromTransform(t)) < status.maxDistance;


    private bool CheckAngle(Transform t, Vector2 dir){
        bool ok = false;

        return ok;

    }*/
    


}
