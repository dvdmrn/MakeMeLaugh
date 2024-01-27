using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWalls : MonoBehaviour
{
    public GameObject wall;
    public int xSpawnPoint;
    public int headSpaceBuffer;

    public float floorCeiling = 0;
    private float _floorFloor;
    private float _ceilCeil;
    private LevelScroll _levelScroll;
    private int _wallWidth = 100;
    private int _lastYPos = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        _levelScroll = GetComponent<LevelScroll>();
        _lastYPos = 100;
        _floorFloor = -Mathf.Floor(Screen.height/4f);
        _ceilCeil = -_floorFloor - headSpaceBuffer;        
        StartCoroutine(nameof(SpawnLoop));
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            _lastYPos = Mathf.CeilToInt(Mathf.Clamp(_lastYPos + Random.Range(-100f, 100f), _floorFloor, floorCeiling));   
            GameObject floorObj = Instantiate(wall, new Vector3(xSpawnPoint, _lastYPos, 0), Quaternion.identity);
            GameObject ceilObj = Instantiate(wall, new Vector3(xSpawnPoint, _lastYPos + Random.Range(headSpaceBuffer, -_floorFloor), 0), Quaternion.identity);
            floorObj.transform.SetParent(transform);
            ceilObj.transform.SetParent(transform);
            yield return new WaitForSeconds(_wallWidth/_levelScroll.scrollSpeed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
