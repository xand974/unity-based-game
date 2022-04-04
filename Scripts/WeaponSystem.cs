using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [SerializeField] WeaponData weaponData;

    [SerializeField] Transform playerHandTransform;

    private  GameObject model;

    private void OnEnable()
    {
        if (model != null) Destroy(model);
        if(weaponData != null)
        {
            model = Instantiate(weaponData.Prefab);
            model.transform.SetParent(playerHandTransform);
            model.transform.localScale = new Vector3(x : 4 ,y :3 , z : 3);
            model.transform.rotation = new Quaternion(x: 0.6179256f, y: 2.045542f, z: -0.16f , w : 5f);
        }
    }

    void Update()
    {
        //Input for testing
        if(Input.GetKeyDown(KeyCode.M))
        {
            Attack();
        }
    }

    public void  Attack()
    {
        var target = GameObject.FindGameObjectWithTag("enemy").GetComponent<Target>();
        if(weaponData.Damage > 0)
        {
            target.TakeDamage(weaponData.Damage);
        }
    }
}
