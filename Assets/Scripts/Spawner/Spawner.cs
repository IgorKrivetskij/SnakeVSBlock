using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private int _repeatCount;
    [SerializeField] private float _distanceBetweenElementsSpawn;
    [Header("Block")]
    [SerializeField] private Block _blockTemplate;
    [SerializeField] private AnimationCurve _blockSpawnChance;
    [Header("Bonus")]
    [SerializeField] private Bonus _bonusTemplate;
    [SerializeField] private AnimationCurve _bonusSpawnChance;
    [Header("Wall")]
    [SerializeField] private Wall _wallTemplate;
    [SerializeField] private AnimationCurve _wallSpawnChance;

    private BlockSpawnPoint[] _blockSpawnPoints;
    private BonusSpawnPoinrt[] _bonusSpawnPoints;
    private WallSpawnPoint[] _wallSpawnPoints;
    private List<GameObject> _containers = new List<GameObject>();
    private GameObject _container;
    private Element[] _spawnElements;
    private SpawnPoint[][] _spawPoints;
    private float[] _spawnChansess;

    private void Awake()
    {
        _blockSpawnPoints = GetComponentsInChildren<BlockSpawnPoint>();
        _bonusSpawnPoints = GetComponentsInChildren<BonusSpawnPoinrt>();
        _wallSpawnPoints = GetComponentsInChildren<WallSpawnPoint>();
        _spawnElements = new Element[] { _blockTemplate, _blockTemplate, _bonusTemplate, _wallTemplate };
        _spawPoints = new SpawnPoint[][] { _blockSpawnPoints, _blockSpawnPoints, _bonusSpawnPoints, _wallSpawnPoints };
        _spawnChansess = new float[] { 1f, _blockSpawnChance.Evaluate(Time.time), _bonusSpawnChance.Evaluate(Time.time), _wallSpawnChance.Evaluate(Time.time) };
    }

    private void Start()
    {
        StartCoroutine(BuildLevel());
        StartCoroutine(DestroyElementsLine());
    }

    private void UpChansess()
    {
        _spawnChansess = new float[] { 1f, _blockSpawnChance.Evaluate(Time.time), _bonusSpawnChance.Evaluate(Time.time) , _wallSpawnChance.Evaluate(Time.time) };
    }

    private void SpawnLevelPart()
    {
        UpChansess();
        for (int j = 0; j < _spawnElements.Length ; j++)
        {
            if(j != _spawnElements.Length - 1)            {
                GenerateElemets(_spawPoints[j], _spawnElements[j], _spawnChansess[j]);               
            }
            else
            {
                int tmp = _spawnElements.Length - 1;
                GenerateElemets(_spawPoints[tmp], _spawnElements[tmp], _spawnChansess[tmp]);
            }
            SpawnMoove(_distanceBetweenElementsSpawn);
        }
    }

    IEnumerator BuildLevel()
    {
        while (true)
        {
            SpawnLevelPart();
            yield return new WaitForSeconds(3f);
        }

    }

    IEnumerator DestroyElementsLine()
    {
        yield return new WaitForSeconds(5f);
        if (_containers != null)
        {           
            while (_containers.Count > 0)
            {
                yield return new WaitForSeconds(4f);
                Destroy(_containers[0].gameObject);
                _containers.RemoveAt(0);
            }
        }
    }

    private void GenerateElemets(SpawnPoint[] spawnPoints, Element generateElement, float _spawnChance)
    {
        _container = new GameObject();
        _containers.Add(_container);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (Random.Range(0, 1f) < _spawnChance)
            {
                CreateElement(spawnPoints[i].transform.position, generateElement.gameObject, _container);
            }
        }
    }

    private GameObject CreateElement(Vector2 spawnPoint, GameObject generateElement, GameObject container)
    {
        return Instantiate(generateElement, spawnPoint, Quaternion.identity, container.transform);
    }

    private void SpawnMoove(float distance)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + distance, transform.position.z);
    }
}
