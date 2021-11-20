using System.Collections;
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


    [Header( "Speciment population settings" )]
    [SerializeField] private GameObject specimentPrefab;
    [SerializeField] private int populationSize;

    [Range( 0 , 300 )]
    [Tooltip( "number of Sick Specimen will be calculated using population size" )]
    [SerializeField] private int numberOfHealthySpecimen;
    [Range( 0f , 1f )]
    [SerializeField] private float probalityOfSpawnigWithResistance;
    [Range( 0f , 1f )]
    [SerializeField] private float probalityOfSpawnigWithSymptomns;

    private Bounds specimenBounds;
    private List<SpecimenMeneger> specimentList = new List<SpecimenMeneger>();


    public float SizeX { get => sizeX; }
    public float SizeY { get => sizeY; }



    // Start is called before the first frame update
    void Start()
    {
        simulationBoardSprite.transform.localScale = new Vector2( sizeX , sizeY );
        simulationBoardSprite.GetComponent<BoxCollider2D>().size = new Vector2( sizeX , sizeY );


        //initial spawning
        Vector2 initialPos = new Vector2();
        SpecimenMeneger specimenMeneger;

        for( int i = 0 ; i < populationSize ; i++ )
        {

            GameObject specimenObject = Instantiate( specimentPrefab , initialPos , Quaternion.identity );
            SpecimenMeneger specimen = specimenObject.GetComponent<SpecimenMeneger>();

            specimenMeneger = specimen.GetComponent<SpecimenMeneger>();

            if( specimen != null )
                specimenBounds = specimen.GetComponent<CircleCollider2D>().bounds;

            initialPos.x = Random.Range( -sizeX / 2f + specimenBounds.size.x * 0.5f , sizeX / 2f - specimenBounds.size.x * 0.5f );
            initialPos.y = Random.Range( -sizeY / 2f + specimenBounds.size.y * 0.5f , sizeY / 2f - specimenBounds.size.y * 0.5f );

            if( numberOfHealthySpecimen > i )
            {
                specimenMeneger.startingState = probalityOfSpawnigWithResistance > Random.value
                    ? (SpecimenState)specimenMeneger.healtyResistant
                    : (SpecimenState)specimenMeneger.healthyFragile;
            }
            else
            {
                specimenMeneger.startingState = probalityOfSpawnigWithSymptomns > Random.value
                    ? (SpecimenState)specimenMeneger.sickSymptomatic
                    : (SpecimenState)specimenMeneger.sickAsymptomatic;
            }

            specimenMeneger.startingState.EnterState( specimenMeneger );

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

            if( specimen == null )
                continue;

            if( IsOutsideBoard( specimen.transform , specimenBounds , simulationBoardSprite.transform ) )
            {
                if( Random.value > Random.value )
                {
                    specimen.transform.Rotate( Vector3.forward , 180f );
                    specimen.transform.Translate( Vector3.right * specimenBounds.size.x * 0.1f );
                }
                else
                {
                    specimentList.Remove( specimen );

                    GameObject.Destroy( specimen.gameObject );

                    specimentList.Add( SpawnSpecimen() );

                }
            }
        }
    }


    private SpecimenMeneger SpawnSpecimen()
    {
        Vector2 initialPos = new Vector2();
        SpecimenMeneger specimenMeneger;

        initialPos = GetRandomBorderPosition();

        GameObject specimen = Instantiate( specimentPrefab , initialPos , Quaternion.identity );
        specimenMeneger = specimen.GetComponent<SpecimenMeneger>();

        if( Random.value >= 0.1f )
        {
            specimenMeneger.startingState = probalityOfSpawnigWithResistance > Random.value
                ? (SpecimenState)specimenMeneger.healtyResistant
                : (SpecimenState)specimenMeneger.healthyFragile;
        }
        else
        {
            specimenMeneger.startingState = probalityOfSpawnigWithSymptomns > Random.value
                ? (SpecimenState)specimenMeneger.sickSymptomatic
                : (SpecimenState)specimenMeneger.sickAsymptomatic;
        }

        specimenMeneger.startingState.EnterState( specimenMeneger );

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
                    (-sizeX / 2f + specimenBounds.size.x * 0.5f) ,
                    (sizeX / 2f - specimenBounds.size.x * 0.5f) );

                initialPos.y = sizeY / 2f - specimenBounds.size.y * 0.5f;

                break;
            }
            case 1:
            {
                initialPos.x = sizeX / 2f - specimenBounds.size.x * 0.5f;

                initialPos.y = Random.Range(
                    (-sizeY / 2f + specimenBounds.size.y * 0.5f) ,
                    (sizeY / 2f - specimenBounds.size.y * 0.5f) );

                break;
            }
            case 2:
            {

                initialPos.x = Random.Range(
                    (-sizeX / 2f + specimenBounds.size.x * 0.5f) ,
                    (sizeX / 2f - specimenBounds.size.x * 0.5f) );

                initialPos.y = -sizeY / 2f + specimenBounds.size.y * 0.5f;

                break;
            }
            case 3:
            {
                initialPos.x = -sizeX / 2f + specimenBounds.size.x * 0.5f;

                initialPos.y = Random.Range(
                    (-sizeY / 2f + specimenBounds.size.y * 0.5f) ,
                    (sizeY / 2f - specimenBounds.size.y * 0.5f) );

                break;
            }
            default:
            {
                initialPos.x = Random.Range( -sizeX / 2f + specimenBounds.size.x * 0.5f , sizeX / 2f - specimenBounds.size.x * 0.5f );
                initialPos.y = Random.Range( -sizeY / 2f + specimenBounds.size.y * 0.5f , sizeY / 2f - specimenBounds.size.y * 0.5f );
                break;
            }
        }

        return initialPos;
    }


    private bool IsOutsideBoard( Transform specimen , Bounds specimenBounds , Transform board )
    {
        return
            specimen.position.x + specimenBounds.size.x * 0.5f > board.position.x + board.localScale.x / 2f ||
            specimen.position.x - specimenBounds.size.x * 0.5f < board.position.x - board.localScale.x / 2f ||
            specimen.position.y - specimenBounds.size.y * 0.5f < board.position.y - board.localScale.x / 2f ||
            specimen.position.y + specimenBounds.size.y * 0.5f > board.position.y + board.localScale.x / 2f;
    }

}
