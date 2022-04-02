using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] Transform bulletPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        Fire();
    }


    private void Fire()
    {
        var firstPrefabInPool = ObjectPool.Instance.GetObjectFromPool();
        if (firstPrefabInPool != null)
        {
            firstPrefabInPool.transform.position = bulletPosition.position;
            firstPrefabInPool.SetActive(true);
        }
    }
}
