using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecimenSickSymptomaticState : SpecimenState
{
    public override void EnterState( SpecimenMeneger specimentMeneger )
    {
        specimentMeneger.sprite.color = Color.red;
    }

    public override void UpdateState( SpecimenMeneger specimentMeneger )
    {
        Transform specimenTransform = specimentMeneger.transform;

        specimenTransform.Rotate( Vector3.forward , Random.Range( -20f , 20f ) );
        specimenTransform.Translate( Vector3.right * specimentMeneger.Speed * Time.deltaTime );


    }

    public override void OnTriggerZoneStay( SpecimenMeneger specimenMeneger , SpecimenMeneger other )
    {

    }


    public override void OnTriggerZoneExit( SpecimenMeneger specimenMeneger , SpecimenMeneger other )
    {
        return;
    }

}
