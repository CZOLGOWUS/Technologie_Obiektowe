using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecimenSickAsymptomaticState : SpecimenState
{

    public override void EnterState( SpecimenMeneger specimentMeneger )
    {
        specimentMeneger.sprite.color = new Color( 0.6f,0,0);
    }


    public override void UpdateState( SpecimenMeneger specimentMeneger )
    {
        specimentMeneger.transform.Rotate( Vector3.forward , Random.Range( -20f , 20f ) );
        specimentMeneger.transform.Translate( Vector3.right * specimentMeneger.Speed * Time.deltaTime );
    }


    public override void OnTriggerZoneStay( SpecimenMeneger specimenMeneger , SpecimenMeneger other )
    {
        if( specimenMeneger.distanceAndTimeDict.ContainsKey( other ) )
        {
            specimenNearInfo currentInfo = specimenMeneger.distanceAndTimeDict[other];

            currentInfo.TimeWithingRange = specimenMeneger.distanceAndTimeDict[other].TimeWithingRange + 1;
            currentInfo.Distance = Vector2.Distance( specimenMeneger.transform.position , other.transform.position ) < 2f;

            if( currentInfo.TimeWithingRange >= 3*25 )
            {
                specimenMeneger.SwitchState( (Random.value > 0.5f ?
                    (SpecimenState)specimenMeneger.sickSymptomatic :
                    (SpecimenState)specimenMeneger.sickAsymptomatic ));
            }
             
        }
        else
        {
            specimenMeneger.distanceAndTimeDict[other] = new specimenNearInfo( 0f,true);
        }
    }


    public override void OnTriggerZoneExit( SpecimenMeneger specimenMeneger , SpecimenMeneger other )
    {
        return;
    }
    
}

