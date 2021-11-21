using UnityEngine;


public struct SpecimenStateInfo
{
    public SpecimenState state;
    public Transform transform;

    public SpecimenStateInfo(SpecimenState state, Transform transform)
    {
        this.state = state;
        this.transform = transform;
    }
}