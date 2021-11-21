
using System.Collections.Generic;
using UnityEngine;



public class GameMeneger : MonoBehaviour
{
    [Header( "simulationSettings" )]
    [SerializeField] private Camera mainCamera;

    [Header( "Board settings" )]
    [SerializeField] private SpriteRenderer simulationBoardSprite;
    [SerializeField] private float sizeX;
    [SerializeField] private float sizeY;
    private Vector2 boardCenter;


    [Header( "Speciment population settings" )]
    [SerializeField] private GameObject specimentPrefab;
    [SerializeField] private int populationSize;

    [Tooltip( "number of Sick Specimen will be calculated using population size" )]
    [SerializeField] private int numberOfHealthySpecimen;
    [Range( 0f , 1f )]
    [SerializeField] private float probalityOfSpawnigWithResistance;
    [Range( 0f , 1f )]
    [SerializeField] private float probalityOfSpawnigWithSymptomns;

    private CircleCollider2D specimenCircleCollider;
    private List<SpecimenMeneger> specimentList = new List<SpecimenMeneger>();


    public float SizeX { get => sizeX; }
    public float SizeY { get => sizeY; }



    // Start is called before the first frame update
    void OnEnable()
    {
        simulationBoardSprite.transform.localScale = new Vector2( sizeX , sizeY );
        simulationBoardSprite.GetComponent<BoxCollider2D>().size = new Vector2( sizeX , sizeY );


        //initial spawning
        Vector2 initialPos = new Vector2();
        boardCenter = simulationBoardSprite.GetComponent<Collider2D>().bounds.center;

        for( int i = 0 ; i < populationSize ; i++ )
        {
            SpecimenMeneger specimen = Instantiate(specimentPrefab, initialPos, Quaternion.identity).GetComponent<SpecimenMeneger>();

            if (specimen != null)
            {
                specimenCircleCollider = specimen.transform.GetComponent<CircleCollider2D>();
                specimenCircleCollider.radius = 0.1f;
                
            }
            else
            {
                throw new System.Exception("specimen bounds or circle collider 2D is null");
            }

            initialPos.x = Random.Range( -sizeX / 2f + specimenCircleCollider.radius * 0.5f , sizeX / 2f - specimenCircleCollider.radius * 0.5f );
            initialPos.y = Random.Range( -sizeY / 2f + specimenCircleCollider.radius * 0.5f , sizeY / 2f - specimenCircleCollider.radius * 0.5f );

            if( numberOfHealthySpecimen > i )
            {
                specimen.currentState = probalityOfSpawnigWithResistance > Random.value
                    ? (SpecimenState)specimen.healtyResistant
                    : (SpecimenState)specimen.healthyFragile;
            }
            else
            {
                specimen.currentState = probalityOfSpawnigWithSymptomns > Random.value
                    ? (SpecimenState)specimen.sickSymptomatic
                    : (SpecimenState)specimen.sickAsymptomatic;
            }

            specimen.currentState.EnterState(specimen);

            specimen.transform.position = initialPos;

            specimentList.Add( specimen );

        }


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for( int i = 0 ; i < specimentList.Count ; i++ )
        {
            SpecimenMeneger specimen = specimentList[i];

            //temp fix for null refs
            if( specimen == null )
            {
                specimentList.Remove(specimen);
                continue;
            }
            else if(specimenCircleCollider == null)
            {
                specimentList.Remove(specimen);
                continue;
            }

            if( IsOutsideBoard( specimen.transform , specimenCircleCollider.radius, simulationBoardSprite.transform ) )
            {
                if( Random.value > Random.value )
                {
                    specimen.transform.Rotate( Vector3.forward , 180f );
                    specimen.transform.Translate( Vector3.right * specimenCircleCollider.radius * 0.1f );
                }
                else
                {
                    specimentList.Remove( specimen );

                    GameObject.Destroy( specimen.gameObject );

                    specimentList.Add( SpawnSpecimen() );

                }
            }

            //print(specimentList.FindAll((x) => { return x.currentState is SpecimenSickSymptomaticState; }).Count );

        }


    }


    private SpecimenMeneger SpawnSpecimen()
    {
        Vector2 initialPos = GetRandomBorderPosition();
        SpecimenMeneger specimenMeneger;

        GameObject specimen = Instantiate( specimentPrefab , initialPos ,Quaternion.identity );
        specimenMeneger = specimen.GetComponent<SpecimenMeneger>();

        if( Random.value >= 0.1f )
        {
            specimenMeneger.currentState = probalityOfSpawnigWithResistance > Random.value
                ? (SpecimenState)specimenMeneger.healtyResistant
                : (SpecimenState)specimenMeneger.healthyFragile;
        }
        else
        {
            specimenMeneger.currentState = probalityOfSpawnigWithSymptomns > Random.value
                ? (SpecimenState)specimenMeneger.sickSymptomatic
                : (SpecimenState)specimenMeneger.sickAsymptomatic;
        }

        specimenMeneger.currentState.EnterState( specimenMeneger );

        specimen.transform.position = initialPos;

        return specimenMeneger;
    }



    private Vector2 GetRandomBorderPosition()
    {
        Vector2 initialPos;
        switch( (int)(Random.Range( 0f , 4f )) )
        {
            case 0:
            {
                initialPos.x = Random.Range(
                    (-sizeX / 2f + specimenCircleCollider.radius * 0.5f) ,
                    (sizeX / 2f - specimenCircleCollider.radius * 0.5f) );

                initialPos.y = sizeY / 2f - specimenCircleCollider.radius * 0.5f;

                break;
            }
            case 1:
            {
                initialPos.x = sizeX / 2f - specimenCircleCollider.radius * 0.5f;

                initialPos.y = Random.Range(
                    (-sizeY / 2f + specimenCircleCollider.radius * 0.5f) ,
                    (sizeY / 2f - specimenCircleCollider.radius * 0.5f) );

                break;
            }
            case 2:
            {

                initialPos.x = Random.Range(
                    (-sizeX / 2f + specimenCircleCollider.radius * 0.5f) ,
                    (sizeX / 2f - specimenCircleCollider.radius * 0.5f) );

                initialPos.y = -sizeY / 2f + specimenCircleCollider.radius * 0.5f;

                break;
            }
            case 3:
            {
                initialPos.x = -sizeX / 2f + specimenCircleCollider.radius * 0.5f;

                initialPos.y = Random.Range(
                    (-sizeY / 2f + specimenCircleCollider.radius * 0.5f) ,
                    (sizeY / 2f - specimenCircleCollider.radius * 0.5f) );

                break;
            }
            default:
            {
                initialPos.x = Random.Range( -sizeX / 2f + specimenCircleCollider.radius * 0.5f , sizeX / 2f - specimenCircleCollider.radius * 0.5f );
                initialPos.y = Random.Range( -sizeY / 2f + specimenCircleCollider.radius * 0.5f , sizeY / 2f - specimenCircleCollider.radius * 0.5f );
                break;
            }
        }

        return initialPos;
    }


    private bool IsOutsideBoard( Transform specimen , float radius , Transform board )
    {

        return
            specimen.position.x + radius> board.position.x + board.localScale.x / 2f ||
            specimen.position.x - radius < board.position.x - board.localScale.x / 2f ||
            specimen.position.y - radius < board.position.y - board.localScale.x / 2f ||
            specimen.position.y + radius  > board.position.y + board.localScale.x / 2f;
    }

}
