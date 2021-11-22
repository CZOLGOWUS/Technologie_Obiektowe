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

    [SerializeField] private int infectionTime = 20 * 25;
    [SerializeField] public int timeToInfect;

    public SpriteRenderer sprite { get; private set; }
    public int InfectionTime { get => infectionTime; set => infectionTime = value; } // 1 frame is 1/25 of a second
    public int infectionTimeCount { get; set; } = 0;


    [Header("Speed diffrences")]
    [SerializeField] public float healthyResistantMinSpeed;
    [SerializeField] public float healthyResistantMaxSpeed;
    [Space]
    [SerializeField] public float healthyFragileMinSpeed;
    [SerializeField] public float healthyFragileMaxSpeed;
    [Space]
    [SerializeField] public float sickSymptomaticMinSpeed;
    [SerializeField] public float sickSymptomaticMaxSpeed;
    [Space]
    [SerializeField] public float sickAsymptomaticMinSpeed;
    [SerializeField] public float sickAsymptomaticMaxSpeed;





    // Start is called before the first frame update
    void OnEnable()
    {
        infectionTime =  (int)(infectionTime * UnityEngine.Random.Range(2f/3f,1f));
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

    public SpecimenMemento StoreInMemento()
    {
        return new SpecimenMemento(currentState, this.transform.position, this.transform.rotation, infectionTimeCount, specimensInInfectionRadiusDict);
    }

    public void RestoreFromMemento(SpecimenMemento memento)
    {
        currentState = memento.State;
        this.transform.position = memento.Position;
        transform.rotation = memento.Rotation;
        specimensInInfectionRadiusDict = specimensInInfectionRadiusDict;

        currentState.EnterState(this);
    }


}