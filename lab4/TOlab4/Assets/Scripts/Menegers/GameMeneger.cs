
using System.Collections.Generic;
using UnityEngine;



public class GameMeneger : MonoBehaviour
{
    [Header("simulationSettings")]
    [SerializeField] private Camera mainCamera;

    [Header("Board settings")]
    [SerializeField] private SpriteRenderer simulationBoardSprite;
    [SerializeField] private float sizeX;
    [SerializeField] private float sizeY;
    private Vector2 boardCenter;


    [Header("Speciment population settings")]
    [SerializeField] private GameObject specimentPrefab;
    [SerializeField] private int populationSize;

    [Tooltip("number of Sick Specimen will be calculated using population size")]
    [SerializeField] private int numberOfHealthySpecimen;
    [Range(0f, 1f)]
    [SerializeField] private float probalityOfSpawnigWithResistance;
    [Range(0f, 1f)]
    [SerializeField] private float probalityOfSpawnigWithSymptomns;

    private CircleCollider2D specimenCircleCollider;
    private List<SpecimenMeneger> specimentList = new List<SpecimenMeneger>();

    [Space]
    [Header("Continuous spawn settings")]
    [Range(0f, 1f)]
    [SerializeField] public float sickSpecimenSpawnProbability;

    public float SizeX { get => sizeX; }
    public float SizeY { get => sizeY; }


    private SpecimensSaves specimensSaved;

    private float circleColliderRadius = 0.1f;


    // Start is called before the first frame update
    void OnEnable()
    {
        simulationBoardSprite.transform.localScale = new Vector2(sizeX, sizeY);
        simulationBoardSprite.GetComponent<BoxCollider2D>().size = new Vector2(sizeX, sizeY);


        //initial spawning
        Vector2 initialPos = new Vector2();
        boardCenter = simulationBoardSprite.GetComponent<Collider2D>().bounds.center;

        for (int i = 0; i < populationSize; i++)
        {
            SpecimenMeneger specimen = Instantiate(specimentPrefab, initialPos, Quaternion.identity).GetComponent<SpecimenMeneger>();

            if (specimen != null)
            {
                specimen.transform.GetComponent<CircleCollider2D>().radius = circleColliderRadius;

            }
            else
            {
                throw new System.Exception("specimen bounds or circle collider 2D is null");
            }

            initialPos.x = Random.Range(-sizeX / 2f + circleColliderRadius * 0.5f, sizeX / 2f - circleColliderRadius * 0.5f);
            initialPos.y = Random.Range(-sizeY / 2f + circleColliderRadius * 0.5f, sizeY / 2f - circleColliderRadius * 0.5f);

            if (numberOfHealthySpecimen > i)
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

            specimentList.Add(specimen);

        }


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < specimentList.Count; i++)
        {
            SpecimenMeneger specimen = specimentList[i];


            if (IsOutsideBoard(specimen.transform, circleColliderRadius, simulationBoardSprite.transform))
            {
                if (Random.value > Random.value)
                {
                    specimen.transform.Rotate(Vector3.forward, 180f);
                    specimen.transform.Translate(Vector3.right * circleColliderRadius * 0.1f);
                }
                else
                {
                    specimentList.Remove(specimen);

                    GameObject.Destroy(specimen.gameObject);

                    specimentList.Add(SpawnSpecimen());

                }
            }

            //print(specimentList.FindAll((x) => { return x.currentState is SpecimenSickSymptomaticState; }).Count );

        }

    }


    private SpecimenMeneger SpawnSpecimen()
    {
        Vector2 initialPos = GetRandomBorderPosition();


        GameObject specimen = Instantiate(specimentPrefab, initialPos, Quaternion.identity);

        Vector3 direction = (boardCenter - initialPos).normalized;
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        specimen.transform.eulerAngles = specimen.transform.forward * targetAngle;

        SpecimenMeneger specimenMeneger = specimen.GetComponent<SpecimenMeneger>();


        if (Random.value >= sickSpecimenSpawnProbability)
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

        specimen.transform.position = initialPos;
        specimenMeneger.currentState.EnterState(specimenMeneger);


        return specimenMeneger;
    }



    private Vector2 GetRandomBorderPosition()
    {
        Vector2 initialPos;
        switch ((int)(Random.Range(0f, 4f)))
        {
            case 0:
                {
                    initialPos.y = sizeY / 2f - circleColliderRadius * 2f;

                    initialPos.x = Random.Range(
                        (-sizeX / 2f + circleColliderRadius * 0.5f),
                        (sizeX / 2f - circleColliderRadius * 0.5f));


                    break;
                }
            case 1:
                {
                    initialPos.x = sizeX / 2f - circleColliderRadius * 2f;

                    initialPos.y = Random.Range(
                        (-sizeY / 2f + circleColliderRadius * 0.5f),
                        (sizeY / 2f - circleColliderRadius * 0.5f));

                    break;
                }
            case 2:
                {
                    initialPos.y = -sizeY / 2f + circleColliderRadius * 2f;

                    initialPos.x = Random.Range(
                        (-sizeX / 2f + circleColliderRadius * 0.5f),
                        (sizeX / 2f - circleColliderRadius * 0.5f));


                    break;
                }
            case 3:
                {
                    initialPos.x = -sizeX / 2f + circleColliderRadius * 2f;

                    initialPos.y = Random.Range(
                        (-sizeY / 2f + circleColliderRadius * 0.5f),
                        (sizeY / 2f - circleColliderRadius * 0.5f));

                    break;
                }
            default:
                {
                    initialPos.x = Random.Range(-sizeX / 2f + circleColliderRadius * 2f, sizeX / 2f - circleColliderRadius * 2f);
                    initialPos.y = Random.Range(-sizeY / 2f + circleColliderRadius * 2f, sizeY / 2f - circleColliderRadius * 2f);
                    break;
                }
        }

        return initialPos;
    }


    private bool IsOutsideBoard(Transform specimen, float radius, Transform board)
    {

        return
            specimen.position.x + radius > board.position.x + board.localScale.x / 2f ||
            specimen.position.x - radius < board.position.x - board.localScale.x / 2f ||
            specimen.position.y - radius < board.position.y - board.localScale.x / 2f ||
            specimen.position.y + radius > board.position.y + board.localScale.x / 2f;
    }


    public void SaveSimulationState()
    {

        if (specimensSaved != null)
        {
            specimensSaved.ClearSave();
        }
        else
            specimensSaved = new SpecimensSaves();

        for (int i = 0; i < specimentList.Count; i++)
        {
            specimensSaved.AddSpecimenSave(specimentList[i].StoreInMemento());
        }

        print(specimensSaved.simulationSaves.FindAll((x) => { return x.State is SpecimenSickSymptomaticState; }).Count);
        print(specimensSaved.simulationSaves.FindAll((x) => { return x.State is SpecimenSickAsymptomaticState; }).Count);
        print(specimensSaved.simulationSaves.FindAll((x) => { return x.State is SpecimenHealthyFragileState; }).Count);
        print(specimensSaved.simulationSaves.FindAll((x) => { return x.State is SpecimenHealthyResistantState; }).Count);

    }


    public void RestoreSimulationState()
    {
        if (specimensSaved == null)
        {
            print("no state was saved");
            return;
        }

        if (specimentList == null)
        {
            specimentList = new List<SpecimenMeneger>();
        }

        if(specimentList.Count != specimensSaved.GetSpecimenCount())
        {
            Debug.LogError("corupted save data");
            return;
        }


        for (int i = 0; i < specimensSaved.GetSpecimenCount(); i++)
        {
            SpecimenMemento memento = specimensSaved.GetSpecimenMemento(i);

            specimentList[i].RestoreFromMemento(memento);
        }

    }

}
