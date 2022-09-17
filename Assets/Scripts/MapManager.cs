using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] GameObject _groundPrefab;
    private List<NewGroundInstantiator> _groundList = new List<NewGroundInstantiator>();

    public void InstantiateGround(Vector3 position)
    {
        GameObject ground = Instantiate(_groundPrefab, position + new Vector3(4578, 0, 0), Quaternion.identity);
        _groundList.Add(ground.GetComponent<NewGroundInstantiator>());

        if(_groundList.Count > 2)
        {
            _groundList[0].DestroyGround();
            _groundList.Remove(_groundList[0]);
        }
    }

}

