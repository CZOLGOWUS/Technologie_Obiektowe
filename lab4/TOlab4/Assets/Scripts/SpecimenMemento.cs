using UnityEngine;

public class SpecimenMemento
{

    private SpecimenState state;
    private Transform transform;

    public SpecimenState State { get => state; set => state = value; }
    public Transform Transform { get => transform; set => transform = value; }
    
    public SpecimenMemento(SpecimenState state, Transform transform)
    {
        this.transform = transform;
        this.state = state;
    }
}
