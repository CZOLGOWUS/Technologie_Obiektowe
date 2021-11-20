using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectionRadiusDelegateHelper : MonoBehaviour
{

    public Action<Collider2D> OnInfectionRangeStay;
    public Action<Collider2D> OnInfectionRangeExit;

    private void OnTriggerStay2D( Collider2D collider )
    {
        if(collider.CompareTag("Specimen"))
            OnInfectionRangeStay( collider );
    }

    private void OnTriggerExit2D( Collider2D collider )
    {
        if( collider.CompareTag( "Specimen" ) )
            OnInfectionRangeStay( collider );
    }
}
