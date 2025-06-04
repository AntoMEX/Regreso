using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class EnemySpawner : MonoBehaviour
//{
//    [Header("Tipo de zona")]
//    [Tooltip("Marca esta casilla si la zona es interior.")]
//    public bool isInterior;

//    [Header("Referencias a Prefabs para interiores")]
//    public GameObject enemyNormalPrefab;  // Usado solo en zonas interiores
//    public GameObject enemyHeavyPrefab;   // Usado solo en zonas interiores

//    [Header("Referencias a Prefabs para exteriores")]
//    public GameObject enemyLightPrefab;   // Usado solo en zonas exteriores

//    [Header("Punto de Spawn")]
//    public Transform spawnPoint; // Puedes usar la posici�n del GameObject o asignar otro transform

//    private EnemyFactory enemyFactory;
//    private bool hasSpawned = false; // Para evitar que se spawnee varias veces (puedes eliminarlo si quieres m�ltiples spawns)

//    void Start()
//    {
//        // Inicializa la factor�a a utilizar seg�n la zona
//        if (isInterior)
//        {
//            InteriorEnemyFactory interiorFactory = new InteriorEnemyFactory();
//            interiorFactory.enemyNormalPrefab = enemyNormalPrefab;
//            interiorFactory.enemyHeavyPrefab = enemyHeavyPrefab;
//            enemyFactory = interiorFactory;
//        }
//        else
//        {
//            ExteriorEnemyFactory exteriorFactory = new ExteriorEnemyFactory();
//            exteriorFactory.enemyLightPrefab = enemyLightPrefab;
//            enemyFactory = exteriorFactory;
//        }
//    }

//    // Detecta la colisi�n con el trigger
//    private void OnTriggerEnter(Collider other)
//    {
//        // Comprueba si el objeto que entra tiene la etiqueta "Player"
//        if (other.CompareTag("Player") && !hasSpawned)
//        {
//            // Crea el enemigo en la posici�n del spawn
//            enemyFactory.CreateEnemy(spawnPoint.position);
//            hasSpawned = true;
//        }
//    }
//}

public class EnemySpawner : MonoBehaviour
{
    [Header("Posici�n de Spawn")]
    public Transform spawnPoint;

    [Header("Tipo de Spawn")]
    public bool isNormalSpawn;
    public bool isHighSpawn;
    public bool isLightSpawn;

    [Header("Referencias a Factories")]
    public NormalEnemyFactory normalEnemyFactory;
    public HighEnemyFactory highEnemyFactory;
    public LightEnemyFactory lightEnemyFactory;

    private bool hasSpawned = false; //Para evitar spawns m�ltiples (ajusta seg�n tu necesidad)

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasSpawned)
        {
            if (isNormalSpawn)
            {
                normalEnemyFactory.SpawnEnemy(spawnPoint.position);
            }
            else if (isHighSpawn)
            {
                highEnemyFactory.SpawnEnemy(spawnPoint.position);
            }
            else if (isLightSpawn)
            {
                lightEnemyFactory.SpawnEnemy(spawnPoint.position);
            }
            hasSpawned = true;
        }
    }
}