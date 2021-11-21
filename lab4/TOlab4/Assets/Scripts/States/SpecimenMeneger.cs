using System;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent( typeof(SpriteRenderer) )]
public class SpecimenMeneger : MonoBehaviour
{

    public SpecimenState startingState { get; set; }
    public SpecimenState currentState { get; set; }
    public SpecimenHealthyResistantState healtyResistant { get; } = new SpecimenHealthyResistantState();
    public SpecimenHealthyFragileState healthyFragile { get; } = new SpecimenHealthyFragileState();
    public SpecimenSickSymptomaticState sickSymptomatic { get; } = new SpecimenSickSymptomaticState();
    public SpecimenSickAsymptomaticState sickAsymptomatic { get; } = new SpecimenSickAsymptomaticState();



    public Dictionary<SpecimenMeneger , float> specimensInInfectionRadiusDict { get; set; } = new Dictionary<SpecimenMeneger , float>();

    [SerializeField] private float speed = 1f;
    [SerializeField] private int infectionTime = 20 * 25;

    [SerializeField] public int timeToInfect;

    public float Speed { get => speed; set => speed = value; }
    public SpriteRenderer sprite { get; private set; }
    public int InfectionTime { get => infectionTime; set => infectionTime = value; } // 1 frame is 1/25 of a second
    public int infectionTimeCount { get; set; } = 0;


    [Header("Speed diffrences")]
    [SerializeField] private float healthyResistantMaxSpeed;
    [SerializeField] private float healthyResistantMinSpeed;
    [Space]
    [SerializeField] private float sickSyptomaticMaxSpeed;
    [SerializeField] private float healthySyptomaticMinSpeed;
    [Space]
    [SerializeField] private float sickAssyptomaticMaxSpeed;
    [SerializeField] private float sickAssyptomaticMinSpeed;
    [Space]
    [SerializeField] private float healthyFragileMaxSpeed;
    [SerializeField] private float healthyFragileMinSpeed;






    // Start is called before the first frame update
    void OnEnable()
    {
        sprite = GetComponent<SpriteRenderer>();

        GetComponentInChildren<CircleCollider2D>().radius = 1f;

        InfectionRadiusDelegateHelper infectionRadiusHelper = GetComponentInChildren<InfectionRadiusDelegateHelper>();

        infectionRadiusHelper.OnInfectionRangeStay += OnTriggerInfectionRangeStay2D;
        infectionRadiusHelper.OnInfectionRangeExit += OnTriggerInfectionRangeExit2D;

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
        infectionTimeCount = 0;


        currentState.EnterState(this);
    }


    private void OnTriggerInfectionRangeStay2D( Collider2D collider )
    {
        currentState.OnTriggerZoneStay( this , collider.GetComponent<SpecimenMeneger>() );
    }


    private void OnTriggerInfectionRangeExit2D( Collider2D collider )
    {
        currentState.OnTriggerZoneExit( this , collider.GetComponent<SpecimenMeneger>() );
    }


    public void printTesting(string text)
    {
        print( text );
    }

}
