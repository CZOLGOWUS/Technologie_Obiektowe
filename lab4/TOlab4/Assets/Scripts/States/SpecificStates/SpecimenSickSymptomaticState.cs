using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecimenSickSymptomaticState : SpecimenState
{
    public override void EnterState( SpecimenMeneger specimentMeneger )
    {
        specimentMeneger.GetComponent<SpriteRenderer>().color = Color.red;
    }

    public override void UpdateState( SpecimenMeneger specimentMeneger )
    {
        Transform specimenTransform = specimentMeneger.transform;

        specimenTransform.Rotate( Vector3.forward , Random.Range( -20f , 20f ) );
        specimenTransform.Translate( Vector3.right * specimentMeneger.Speed * Time.deltaTime );


    }

    public override void OnCollisonStay( SpecimenMeneger specimenMeneger , SpecimenMeneger other )
    {

    }

}
