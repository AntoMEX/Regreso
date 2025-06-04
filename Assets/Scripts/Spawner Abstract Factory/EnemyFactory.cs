using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Abstract Factory: define la interfaz de creación
//public abstract class EnemyFactory
//{
//    public abstract GameObject CreateEnemy(Vector3 spawnPosition);
//}

public abstract class EnemyFactory : MonoBehaviour, IEnemySpawner
{
    //El método SpawnEnemy debe ser implementado en cada factory concreto.
    public abstract GameObject SpawnEnemy(Vector3 spawnPosition);
}


////Factory para zonas interiores: spawn de enemigo normal o enemigo pesado
//public class InteriorEnemyFactory : EnemyFactory
//{
//    //Prefabs
//    public GameObject enemyNormalPrefab;
//    public GameObject enemyHeavyPrefab;

//    public override GameObject CreateEnemy(Vector3 spawnPosition)
//    {
//        //Se decide aleatoriamente entre enemigo normal o pesado
//        int randomType = Random.Range(0, 2); // valor 0 o 1
//        GameObject prefabToSpawn = (randomType == 0) ? enemyNormalPrefab : enemyHeavyPrefab;
//        return Object.Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
//    }
//}

////Factory para zonas exteriores: spawn de enemigo ligero
//public class ExteriorEnemyFactory : EnemyFactory
//{
//    public GameObject enemyLightPrefab;

//    public override GameObject CreateEnemy(Vector3 spawnPosition)
//    {
//        return Object.Instantiate(enemyLightPrefab, spawnPosition, Quaternion.identity);
//    }
//}