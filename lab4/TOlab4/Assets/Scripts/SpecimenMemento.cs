using System.Collections.Generic;
using UnityEngine;

public class SpecimenMemento
{

    private SpecimenState state;
    private Vector2 position;
    private Quaternion rotation;
    private int infectionTimeCount;
    private Dictionary<SpecimenMeneger, float> specimenInRadius;

    public SpecimenState State { get => state; set => state = value; }
    public Dictionary<SpecimenMeneger, float> SpecimenInRadius { get => specimenInRadius; set => specimenInRadius = value; }
    public Vector2 Position { get => position; set => position = value; }
    public Quaternion Rotation { get => rotation; set => rotation = value; }
    public int InfectionTimeCount { get => infectionTimeCount; set => infectionTimeCount = value; }

    public SpecimenMemento(SpecimenState state, Vector2 position, Quaternion rotation, int infectionTimeCount ,Dictionary<SpecimenMeneger, float> specimenDict)
    {
        this.position = position;
        this.rotation = rotation;
        this.infectionTimeCount = infectionTimeCount;
        this.state = state;
        specimenInRadius = specimenDict;
    }
}
