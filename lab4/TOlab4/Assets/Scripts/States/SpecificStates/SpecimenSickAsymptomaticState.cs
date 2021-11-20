using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecimenSickAsymptomaticState : SpecimenState
{
    private Dictionary<SpecimenMeneger,specimenNearInfo> distanceAndTimeDict;


    public override void EnterState( SpecimenMeneger specimentMeneger )
    {
        specimentMeneger.GetComponent<SpriteRenderer>().color = new Color( 0.6f,0,0);
    }


    public override void UpdateState( SpecimenMeneger specimentMeneger )
    {
        specimentMeneger.transform.Rotate( Vector3.forward , Random.Range( -20f , 20f ) );
        specimentMeneger.transform.Translate( Vector3.right * specimentMeneger.Speed * Time.deltaTime );
    }

    public override void OnCollisonStay( SpecimenMeneger specimenMeneger , SpecimenMeneger other )
    {
        if(distanceAndTimeDict.ContainsKey( other ) )
        {
            specimenNearInfo currentInfo = distanceAndTimeDict[other];

            currentInfo = new specimenNearInfo(
                distanceAndTimeDict[other].TimeWithingRange + Time.deltaTime ,
                Vector2.Distance( specimenMeneger.transform.position , other.transform.position ) );

            if( currentInfo.TimeWithingRange >= 3 )
            {

            }

        }
        else
        {
            distanceAndTimeDict[other] = new specimenNearInfo( 0f,0f);
        }
    }
}

