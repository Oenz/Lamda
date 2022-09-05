
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> _CheckPoints;

    public static GameManager _instance;

    [SerializeField] GameObject _player;

    [SerializeField] Text _meter;

    int CheckPointIndex = 0;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(_instance);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Linq
        _CheckPoints = GameObject.FindGameObjectsWithTag("CheckPoint").OrderBy(go => int.Parse(go.name.Replace("CheckPoint", ""))).ToList();
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckPointIndex >= _CheckPoints.Count())
        {
            _meter.text = "GOAL";
            Debug.Log($"GOAL");
            return;
        }
        float Distance = Vector3.Distance(_player.transform.position, _CheckPoints[CheckPointIndex].transform.position);

        for (int i = CheckPointIndex; i < _CheckPoints.Count() - 1; i++)
        {
            Distance += Vector3.Distance(_CheckPoints[i].transform.position, _CheckPoints[i + 1].transform.position);
        }

        Debug.Log($"Left : {Distance}m Checkpoint : {CheckPointIndex}");
        _meter.text = $"Left : {Distance}m Checkpoint : {CheckPointIndex}";

    }

    public void SetCheckPoint(GameObject go)
    {
        CheckPointIndex = int.Parse(go.name.Replace("CheckPoint", ""));

    }
}
