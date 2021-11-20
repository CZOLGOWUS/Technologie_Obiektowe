using System;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent( typeof(SpriteRenderer) )]
public class SpecimenMeneger : MonoBehaviour
{

    public SpecimenState startingState { get; set; }
    public SpecimenState currentState { get; set; }
    public SpecimenHealthyResistantState healtyResistant { get; } = new SpecimenHealthyResistantState();
    public SecimenHealthyFragileState healthyFragile { get; } = new SecimenHealthyFragileState();
    public SpecimenSickSymptomaticState sickSymptomatic { get; } = new SpecimenSickSymptomaticState();
    public SpecimenSickAsymptomaticState sickAsymptomatic { get; } = new SpecimenSickAsymptomaticState();

    public Dictionary<SpecimenMeneger , specimenNearInfo> distanceAndTimeDict { get; set; } = new Dictionary<SpecimenMeneger , specimenNearInfo>();

    [SerializeField] private float speed = 1f;
    public float Speed { get => speed; set => speed = value; }

    [SerializeField] public SpriteRenderer sprite { get; private set; }

    public int infectionTime { get; set; } = 20*25; // 1 frame is 1/25 of a second
    private int infectionTimeRemaining = 0;








    // Start is called before the first frame update
    void OnEnable()
    {
        sprite = GetComponent<SpriteRenderer>();

        GetComponentInChildren<CircleCollider2D>().radius = 1f;

        InfectionRadiusDelegateHelper infectionRadiusHelper = GetComponentInChildren<InfectionRadiusDelegateHelper>();

        infectionRadiusHelper.OnInfectionRangeStay += OnTriggerStay2D;
        infectionRadiusHelper.OnInfectionRangeExit += OnTriggerExit2D;

        currentState = startingState != null ? startingState : healtyResistant;
        currentState.EnterState( this );

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        currentState.UpdateState( this );
    }


    public void SwitchState(SpecimenState newState)
    {
        currentState = newState;
        currentState.EnterState(this);
    }


    private void OnTriggerStay2D( Collider2D collider )
    {
        currentState.OnTriggerZoneStay( this , collider.GetComponent<SpecimenMeneger>() );
    }

    private void OnTriggerExit2D( Collider2D collider )
    {
        currentState.OnTriggerZoneExit( this , collider.GetComponent<SpecimenMeneger>() );
    }

    public void printTesting(string text)
    {
        print( text );
    }

}
