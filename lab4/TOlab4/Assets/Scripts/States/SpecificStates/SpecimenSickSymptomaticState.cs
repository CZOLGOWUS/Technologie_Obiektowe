using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecimenSickSymptomaticState : SpecimenState
{
    public override void EnterState( SpecimenMeneger specimentMeneger )
    {
        specimentMeneger.sprite.color = Color.red;
        specimentMeneger.infectionTimeCount = 0;

    }

    public override void UpdateState( SpecimenMeneger specimentMeneger )
    {
        Transform specimenTransform = specimentMeneger.transform;

        specimenTransform.Rotate( Vector3.forward , Random.Range( -20f , 20f ) );
        specimenTransform.Translate( Vector3.right * Random.Range( specimentMeneger.sickSymptomaticMinSpeed,specimentMeneger.sickSymptomaticMaxSpeed) * Time.deltaTime );

        if(specimentMeneger.infectionTimeCount >= specimentMeneger.InfectionTime )
        {
            specimentMeneger.SwitchState(specimentMeneger.healtyResistant);
            specimentMeneger.infectionTimeCount = 0;
        }
        else
        {
            specimentMeneger.infectionTimeCount++; 
        }

    }

    public override void OnTriggerZoneStay( SpecimenMeneger specimenMeneger , SpecimenMeneger other )
    {
        if (specimenMeneger.specimensInInfectionRadiusDict.ContainsKey(other) )
        {

            specimenMeneger.specimensInInfectionRadiusDict[other]++;

            if (specimenMeneger.specimensInInfectionRadiusDict[other] >= specimenMeneger.timeToInfect )
            {
                other.SwitchState((Random.value > 0.5f ?
                    (SpecimenState)specimenMeneger.sickSymptomatic :
                    (SpecimenState)specimenMeneger.sickAsymptomatic));

                specimenMeneger.specimensInInfectionRadiusDict.Remove(other);
            }
            else if (!(other.currentState is SpecimenHealthyFragileState))
            {
                specimenMeneger.specimensInInfectionRadiusDict.Remove(other);
            }

        }
        else if (other.currentState is SpecimenHealthyFragileState)
        {
            specimenMeneger.specimensInInfectionRadiusDict[other] = 0f;
        }
    }


    public override void OnTriggerZoneExit( SpecimenMeneger specimenMeneger , SpecimenMeneger other )
    {
        if (specimenMeneger.specimensInInfectionRadiusDict.ContainsKey(other))
        {

            specimenMeneger.specimensInInfectionRadiusDict.Remove(other);

        }

    }

}
