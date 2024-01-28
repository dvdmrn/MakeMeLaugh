using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{

    //private int xPos;
    private int yPos;

    [SerializeField]
    private GameObject[] _enemyPrefabs;
    private float _maximumSpawnTime;
    private float _minimumSpawnTime;
    private float _timeUntilSpawn;


    
void Start(){
    StartCoroutine(EnemyDrop());
    Debug.Log("en prefab"+_enemyPrefabs.Length);
}

IEnumerator EnemyDrop() {
    while (true){
        //xPos = Random.Range(700,900);
        yPos = Random.Range(50,-50);
        GameObject enemyObj = Instantiate(_enemyPrefabs[Mathf.FloorToInt(Random.Range(0,_enemyPrefabs.Length))], new Vector3(200,yPos, 0), Quaternion.identity);
        // to get transform as the objets transform, for the size to be smaller
        enemyObj.transform.SetParent(transform);
        enemyObj.transform.position = new Vector3(100, 0,0);
        enemyObj.transform.localScale = new Vector3(1,1,1);
        yield return new WaitForSeconds(Random.Range(3,6));
    }
}
    // Update is called once per frame
// void Update()
// {
//     if(_timeUntilSpawn <=0){
//         Instantiate(_enemyPrefabs, transform.position, Quaternion.identity);
//         SetTimeUntilSpawn();
//     }
// }

//     private void SetTimeUntilSpawn(){
//         _timeUntilSpawn = Random.Range(_minimumSpawnTime, _maximumSpawnTime);
//     }
}
