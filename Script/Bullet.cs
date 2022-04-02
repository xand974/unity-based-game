using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 5f;
    [SerializeField]private new Rigidbody rigidbody;
    // Start is called before the first frame update

    private void FixedUpdate()
    {
        rigidbody.velocity = Vector3.up * speed;
        StartCoroutine(HideBullet());
    }

   IEnumerator HideBullet()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}
