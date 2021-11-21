using UnityEngine;

public class SpecimenHealthyResistantState : SpecimenState
{
    public override void EnterState( SpecimenMeneger specimentMeneger )
    {
        specimentMeneger.sprite.color = Color.green;
    }


    public override void UpdateState( SpecimenMeneger specimentMeneger )
    {
        specimentMeneger.transform.Rotate( Vector3.forward , Random.Range( -20f , 20f ) );
        specimentMeneger.transform.Translate( Vector3.right * Random.Range(specimentMeneger.healthyResistantMinSpeed, specimentMeneger.healthyResistantMaxSpeed) * Time.deltaTime );
    }


    public override void OnTriggerZoneStay( SpecimenMeneger specimenMeneger , SpecimenMeneger other )
    {
        return;
    }


    public override void OnTriggerZoneExit( SpecimenMeneger specimenMeneger , SpecimenMeneger other )
    {
        return;
    }

}
