using UnityEngine;

public class SpecimenHealthyFragileState : SpecimenState
{

    public override void EnterState( SpecimenMeneger specimentMeneger )
    {
        specimentMeneger.sprite.color = new Color(1f,1f,1f);
    }


    public override void UpdateState( SpecimenMeneger specimentMeneger)
    {
        Move(specimentMeneger, specimentMeneger.healthyFragileMinSpeed, specimentMeneger.healthyFragileMaxSpeed);
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
