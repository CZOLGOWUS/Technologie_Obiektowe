using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpecimenState
{
    public struct specimenNearInfo
    {
        private float timeWithingRange;
        private float distance;

        public specimenNearInfo( float timeWithingRange , float distance )
        {
            this.timeWithingRange = timeWithingRange;
            this.distance = distance;
        }

        public float TimeWithingRange { get => timeWithingRange; set => timeWithingRange = value; }
        public float Distance { get => distance; set => distance = value; }
    }

    public abstract void EnterState( SpecimenMeneger specimenMeneger );
    public abstract void UpdateState( SpecimenMeneger specimenMeneger );
    public abstract void OnCollisonStay( SpecimenMeneger specimenMeneger , SpecimenMeneger other);

}
