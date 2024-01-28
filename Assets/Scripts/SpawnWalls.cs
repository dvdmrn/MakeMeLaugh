using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWalls : MonoBehaviour
{
    public GameObject wall;
    public GameObject hurtBox;
    public int xSpawnPoint;
    public int headSpaceBuffer;

    public float floorCeiling = 0;
    private float _floorFloor;
    private float _ceilCeil;
    private LevelScroll _levelScroll;
    private int _wallWidth = 100;
    private int _randWalkY = 0;
    private int _yPosCeil = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        _levelScroll = GetComponent<LevelScroll>();
        _randWalkY = 100;
        _floorFloor = -Mathf.Floor(Screen.height/4f);
        _ceilCeil = -_floorFloor - headSpaceBuffer;        
        StartCoroutine(nameof(SpawnLoop));
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            float lastFloorPos = _randWalkY;
            _randWalkY = Mathf.CeilToInt(Mathf.Clamp(_randWalkY + Random.Range(-100f, 100f), _floorFloor, floorCeiling));

            float lastCeilPos = _yPosCeil;
            _yPosCeil = _randWalkY +  Mathf.FloorToInt(Random.Range(headSpaceBuffer, - _floorFloor));
            
            float yDiffFloor = lastFloorPos - _randWalkY;
            float yDiffCeil = lastCeilPos  - _yPosCeil;
            GameObject floorObj = Instantiate(wall, new Vector3(xSpawnPoint, _randWalkY, 0), Quaternion.identity);
            GameObject floorVert = Instantiate(wall, 
                                                new Vector3(xSpawnPoint - (int)(_wallWidth / 2), 
                                                                    _randWalkY + (yDiffFloor/2), 
                                                                    0), 
                                                Quaternion.Euler(new Vector3(0,0,90)));
            GameObject hurtBoxFloor = Instantiate(hurtBox, new Vector3(xSpawnPoint, _randWalkY - 50, 0), Quaternion.identity);

            GameObject ceilObj = Instantiate(wall, new Vector3(xSpawnPoint, _yPosCeil, 0), Quaternion.identity);
            GameObject ceilVert = Instantiate(wall, 
                                        new Vector3(xSpawnPoint - (int)(_wallWidth / 2), 
                                                            _yPosCeil + (yDiffCeil/2), 
                                                            0), 
                                        Quaternion.Euler(new Vector3(0,0,90)));
            GameObject hurtBoxCeil = Instantiate(hurtBox, new Vector3(xSpawnPoint, _yPosCeil + 50, 0), Quaternion.identity);

            
            // floorVert.transform.localScale = new Vector3(Mathf.Sqrt(Mathf.Pow(yDiffFloor,2)), 0, 0);
            floorObj.transform.SetParent(transform);
            floorVert.transform.SetParent(transform);
            ceilObj.transform.SetParent(transform);
            ceilVert.transform.SetParent(transform);
            hurtBoxFloor.transform.SetParent(transform);
            hurtBoxCeil.transform.SetParent(transform);
            floorVert.transform.localScale = new Vector3(Mathf.Abs(yDiffFloor)  * 2, 4, 4);
            ceilVert.transform.localScale = new Vector3(Mathf.Abs(yDiffCeil) * 2, 4, 4);
            floorVert.name = "FLOOR_VERTY";
            ceilVert.name = "CEIL_VERTY";
            yield return new WaitForSeconds(_wallWidth/_levelScroll.scrollSpeed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
