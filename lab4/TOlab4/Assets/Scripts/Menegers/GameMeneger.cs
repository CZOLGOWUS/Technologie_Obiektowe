using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMeneger : MonoBehaviour
{
    [Header( "simulationSettings" )]
    [SerializeField] private Camera mainCamera;

    [Header("Board settings")]
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



        Vector2 initialPos = new Vector2();
        SpecimenMeneger specimenMeneger;

        for( int i = 0 ; i < populationSize ; i++ )
        {
            initialPos.x = Random.Range( -sizeX / 2f + sizeX * 0.1f , sizeX / 2f - sizeX * 0.1f );
            initialPos.y = Random.Range( -sizeY / 2f + sizeY * 0.1f , sizeY / 2f - sizeY * 0.1f );

            GameObject specimen = Instantiate( specimentPrefab, initialPos, Quaternion.identity) ;
            specimenMeneger = specimen.GetComponent<SpecimenMeneger>();


            if(numberOfHealthySpecimen > i)
            {
                specimenMeneger.StartingState = probalityOfSpawnigWithResistance > Random.Range( 0f , 1f ) 
                    ? (SpecimenState)specimenMeneger.HealtyResistant 
                    : (SpecimenState)specimenMeneger.HealthyFragile; 
            }
            else
            {
                specimenMeneger.StartingState = probalityOfSpawnigWithSymptomns > Random.Range( 0f , 1f )
                    ? (SpecimenState)specimenMeneger.SickSymptomatic
                    : (SpecimenState)specimenMeneger.SickAsymptomatic;
            }

            specimenMeneger.StartingState.EnterState( specimenMeneger );

            specimen.transform.position = initialPos;

            specimentList.Add( specimen );

        }

        if( specimentList.Count > 0 )
            specimenBounds = specimentList[0].GetComponent<CircleCollider2D>().bounds;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach(GameObject specimen in specimentList)
        {
            if(IsOutsideBoard(specimen.transform, specimenBounds, simulationBoardSprite .transform) )
            {
                specimen.transform.Rotate( Vector3.forward , 180f );
            }
        }
    }


    private bool IsOutsideBoard( Transform specimen ,Bounds specimenBounds , Transform board )
    {
        return
            specimen.position.x + specimenBounds.size.x * 0.5f > board.position.x + board.localScale.x / 2f ||
            specimen.position.x - specimenBounds.size.x * 0.5f < board.position.x - board.localScale.x / 2f ||
            specimen.position.y - specimenBounds.size.y * 0.5f < board.position.y - board.localScale.x / 2f ||
            specimen.position.y + specimenBounds.size.y * 0.5f > board.position.y + board.localScale.x / 2f;
    }

}
