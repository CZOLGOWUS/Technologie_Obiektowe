using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecimensSaves
{
    public List<SpecimenMemento> simulationSaves;

    public SpecimensSaves()
    {
        simulationSaves = new List<SpecimenMemento>();
    }

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

    public void ClearSave()
    {
        simulationSaves.Clear();
    }

}
