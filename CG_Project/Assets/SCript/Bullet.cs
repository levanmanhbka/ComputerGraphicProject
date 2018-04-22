using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float lifetime = 2;


    void Start()
    {

    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Bullet OnTriggerEnter2D");
        if (col.isTrigger == false)
        {
            if (col.CompareTag("Player"))
            {
                col.SendMessageUpwards("Damage", 1);
                Debug.Log("Bullet col.SendMessageUpwards ");
            }
            else if (col.CompareTag("Enemy"))
            {
                col.SendMessageUpwards("Damage", 20);
                Debug.Log("Bullet col.SendMessageUpwards ");
            }
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
            Destroy(gameObject);
    }
}
