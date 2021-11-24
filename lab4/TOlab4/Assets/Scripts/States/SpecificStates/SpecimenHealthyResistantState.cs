using UnityEngine;

public class SpecimenHealthyResistantState : SpecimenState
{
    public override void EnterState( SpecimenMeneger specimentMeneger )
    {
        specimentMeneger.sprite.color = new Color(0.5f, 0.8f, .5f);
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
