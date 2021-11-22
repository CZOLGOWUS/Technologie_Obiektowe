using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpecimenState
{

    public abstract void EnterState( SpecimenMeneger specimenMeneger );
    public abstract void UpdateState( SpecimenMeneger specimenMeneger );
    public abstract void OnTriggerZoneStay( SpecimenMeneger specimenMeneger , SpecimenMeneger other );
    public abstract void OnTriggerZoneExit( SpecimenMeneger specimenMeneger , SpecimenMeneger other );

    public void Move(SpecimenMeneger specimen, float minSpeed, float maxSpeed)
    {
        

        specimen.transform.Rotate(Vector3.forward, Random.Range(-20f, 20f));
        specimen.transform.Translate(Vector3.right * Random.Range(minSpeed, maxSpeed) * Time.deltaTime);

    }

}
