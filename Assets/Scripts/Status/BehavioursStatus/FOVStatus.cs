using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New FOVS", menuName = "Status/Behaviours/FOV")]
public class FOVStatus : ScriptableObject
{
   public float maxDistance;
   public float maxAngle;
}
