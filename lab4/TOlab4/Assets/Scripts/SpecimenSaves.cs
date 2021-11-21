using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecimenSaves
{
    private List<SpecimenMemento> simulationSaves;

    public void AddSpecimenSave(SpecimenMemento specimenMemento)
    {
        simulationSaves.Add(specimenMemento);
    }

    public SpecimenMemento GetSpecimenMemento(int index)
    {
        return simulationSaves[index];
    }

    public int GetSpecimenCount()
    { 
        return simulationSaves.Count;
    }

}
