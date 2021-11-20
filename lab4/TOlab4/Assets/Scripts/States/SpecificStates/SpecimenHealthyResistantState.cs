using UnityEngine;

public class SpecimenHealthyResistantState : SpecimenState
{
    public override void EnterState( SpecimenMeneger specimentMeneger )
    {
        specimentMeneger.GetComponent<SpriteRenderer>().color = Color.green;
    }
    public override void UpdateState( SpecimenMeneger specimentMeneger )
    {
        specimentMeneger.transform.Rotate( Vector3.forward , Random.Range( -20f , 20f ) );
        specimentMeneger.transform.Translate( Vector3.right * specimentMeneger.Speed * Time.deltaTime );
    }

    public override void OnCollisonStay( SpecimenMeneger specimenMeneger , SpecimenMeneger other )
    {
        return;
    }

}
