using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMemento
{
    private SpecimenState prevState;
    private Transform prevSecimenTransform;

    public StateMemento(SpecimenState state, Transform specimenTransform)
    {
        prevState = state;
        prevSecimenTransform = specimenTransform;
    }



}
