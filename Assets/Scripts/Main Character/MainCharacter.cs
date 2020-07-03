using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour
{

    private AnimationHandler animationHandler;
    private FOVBehavior bFOV;
    public GameObject testTarget; 
    public FOVStatus status;

    [SerializeField]
    private LineRenderer line;
    // Start is called before the first frame update
    void Start()
    {
        animationHandler = new AnimationHandler(GetComponentInChildren<Animator>());
        bFOV = new FOVBehavior(transform, status);
        animationHandler.ChangeRunningState();
        

    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKey(KeyCode.LeftShift)){
            line.enabled = true;
            bFOV.drawArc(line);
        } else{
            line.enabled = false;
        }
        
        if(bFOV.CheckTarget(testTarget.transform)) Debug.Log("TargetNaMira");
    }
}
