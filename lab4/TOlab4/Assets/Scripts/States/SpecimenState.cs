using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpecimenState
{

    public abstract void EnterState( SpecimenMeneger specimenMeneger );
    public abstract void UpdateState( SpecimenMeneger specimenMeneger );
    public abstract void OnTriggerZoneStay( SpecimenMeneger specimenMeneger , SpecimenMeneger other );
    public abstract void OnTriggerZoneExit( SpecimenMeneger specimenMeneger , SpecimenMeneger other );

}

public struct specimenNearInfo
{
    private float timeWithingRange;
    private bool isWithInRange;

    public specimenNearInfo( float timeWithingRange , bool isWithInRange )
    {
        this.timeWithingRange = timeWithingRange;
        this.isWithInRange = isWithInRange;
    }

    public float TimeWithingRange { get => timeWithingRange; set => timeWithingRange = value; }
    public bool Distance { get => isWithInRange; set => isWithInRange = value; }
}