using UnityEngine;

public class SpecimenMeneger : MonoBehaviour
{

    private SpecimenState startingState;
    private SpecimenState currentState;
    private SpecimenHealthyResistantState healtyResistant = new SpecimenHealthyResistantState();
    private SecimenHealthyFragileState healthyFragile = new SecimenHealthyFragileState();
    private SpecimenSickSymptomaticState sickSymptomatic = new SpecimenSickSymptomaticState();
    private SpecimenSickAsymptomaticState sickAsymptomatic = new SpecimenSickAsymptomaticState();


    [SerializeField] private float speed = 1f;
    [SerializeField] private SpriteRenderer sprite;

    private Vector2 currentMovingDirection;
    



    public SpecimenHealthyResistantState HealtyResistant { get => healtyResistant;  }
    public SecimenHealthyFragileState HealthyFragile { get => healthyFragile;  }
    public SpecimenSickSymptomaticState SickSymptomatic { get => sickSymptomatic;  }
    public SpecimenSickAsymptomaticState SickAsymptomatic { get => sickAsymptomatic;  }
    public SpecimenState CurrentState { get => currentState; set => currentState = value; }
    public SpecimenState StartingState {get => startingState; set => startingState = value; }

    public float Speed { get => speed; set => speed = value; }


    // Start is called before the first frame update
    void Start()
    {
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


    private void OnCollisionStay2D( Collision2D collision )
    {
        if(collision.transform.tag == "Specimen")
            currentState.OnCollisonStay( this, collision.transform.GetComponent<SpecimenMeneger>() );
    }

}
