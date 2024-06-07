using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject bullet;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        transform.Translate(translation, 0, 0);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            // Instantiate(bullet, this.transform.position, Quaternion.identity);
            GameObject b = Pool.singleton.Get("Bullet");
            if(b != null)
            {
                b.transform.position = this.transform.position;
                b.SetActive(true);
            }
        }
    }
}
