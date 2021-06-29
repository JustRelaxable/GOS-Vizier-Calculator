using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

[CreateAssetMenu(fileName ="Vizier Card",menuName ="Create Vizier")]
public class VizierCard : ScriptableObject
{
    public int vizierLevel;
    public string vizierName;
    public SkeletonDataAsset vizierSkeletonDataAsset;
    public List<Talent> talents;
    public int vizierIndex;
    public float size;

    public float YPositionFix;
}
