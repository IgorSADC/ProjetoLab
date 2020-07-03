using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler
{
    private Animator _anim;
    private bool _runningState = false;

    #region Constructor
    public AnimationHandler(Animator anim){
        _anim = anim;
    }
    #endregion

    #region GenericFunctions
    private void ActivateAnimation(string name, bool value){
        _anim.SetBool(name, value);
    }
    private void ActivateAnimation(string name){
        _anim.SetTrigger(name);
    }
    private void ActivateAnimation(string name, float value){
        _anim.SetFloat(name, value);
    }

    #endregion

    #region Movement Region
    public void ChangeRunningState(){
        _runningState = !_runningState;
        ActivateAnimation(ImportantKeys.AnimationKeys.RunningKey, _runningState);
    }

    #endregion
}
