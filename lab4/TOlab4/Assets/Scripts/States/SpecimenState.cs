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
