using UnityEngine;

public class SpecimenHealthyResistantState : SpecimenState
{
    public override void EnterState( SpecimenMeneger specimentMeneger )
    {
        specimentMeneger.sprite.color = Color.green;
    }


    public override void UpdateState( SpecimenMeneger specimentMeneger )
    {
        Move(specimentMeneger, specimentMeneger.healthyResistantMinSpeed, specimentMeneger.healthyResistantMaxSpeed);
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
