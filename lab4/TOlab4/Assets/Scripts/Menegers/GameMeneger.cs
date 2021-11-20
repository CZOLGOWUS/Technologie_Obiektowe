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
    private List<GameObject> specimentList = new List<GameObject>();


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

            GameObject specimen = Instantiate( specimentPrefab , initialPos , Quaternion.identity );
            specimenMeneger = specimen.GetComponent<SpecimenMeneger>();

            if( specimen != null )
                specimenBounds = specimen.GetComponent<CircleCollider2D>().bounds;

            initialPos.x = Random.Range( -sizeX / 2f + specimenBounds.size.x * 0.5f , sizeX / 2f - specimenBounds.size.x * 0.5f );
            initialPos.y = Random.Range( -sizeY / 2f + specimenBounds.size.y * 0.5f , sizeY / 2f - specimenBounds.size.y * 0.5f );

            if( numberOfHealthySpecimen > i )
            {
                specimenMeneger.StartingState = probalityOfSpawnigWithResistance > Random.value
                    ? (SpecimenState)specimenMeneger.HealtyResistant
                    : (SpecimenState)specimenMeneger.HealthyFragile;
            }
            else
            {
                specimenMeneger.StartingState = probalityOfSpawnigWithSymptomns > Random.value
                    ? (SpecimenState)specimenMeneger.SickSymptomatic
                    : (SpecimenState)specimenMeneger.SickAsymptomatic;
            }

            specimenMeneger.StartingState.EnterState( specimenMeneger );

            specimen.transform.position = initialPos;

            specimentList.Add( specimen );

        }


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for( int i = 0 ; i < specimentList.Count ; i++ )
        {
            GameObject specimen = specimentList[i];

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

                    GameObject.Destroy( specimen );

                    specimentList.Add( SpawnSpecimen() );

                }
            }
        }
    }


    private GameObject SpawnSpecimen()
    {
        Vector2 initialPos = new Vector2();
        SpecimenMeneger specimenMeneger;

        switch( (int)(Random.Range(0f,4f)) )
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
                    (-sizeY / 2f + specimenBounds.size.y * 0.5f),
                    (sizeY / 2f - specimenBounds.size.y * 0.5f));

                break;
            }
            case 2:
            {

                initialPos.x = Random.Range(
                    (-sizeX / 2f + specimenBounds.size.x * 0.5f) ,
                    (sizeX / 2f - specimenBounds.size.x * 0.5f));

                initialPos.y = -sizeY / 2f + specimenBounds.size.y * 0.5f;

                break;
            }
            case 3:
            {
                initialPos.x = -sizeX / 2f + specimenBounds.size.x * 0.5f;

                initialPos.y = Random.Range(
                    (-sizeY / 2f + specimenBounds.size.y * 0.5f),
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

        GameObject specimen = Instantiate( specimentPrefab , initialPos , Quaternion.identity );
        specimenMeneger = specimen.GetComponent<SpecimenMeneger>();

        if( Random.value >= 0.1f )
        {
            specimenMeneger.StartingState = probalityOfSpawnigWithResistance > Random.value
                ? (SpecimenState)specimenMeneger.HealtyResistant
                : (SpecimenState)specimenMeneger.HealthyFragile;
        }
        else
        {
            specimenMeneger.StartingState = probalityOfSpawnigWithSymptomns > Random.value
                ? (SpecimenState)specimenMeneger.SickSymptomatic
                : (SpecimenState)specimenMeneger.SickAsymptomatic;
        }

        specimenMeneger.StartingState.EnterState( specimenMeneger );

        specimen.transform.position = initialPos;

        specimentList.Add( specimen );

        return specimen;
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
