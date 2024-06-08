using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject bullet;
    public Slider healthBar;

    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            healthBar.value -= 20;
            if(healthBar.value <= 0)
            {
                Destroy(this.gameObject, 0.2f);
                Destroy(healthBar.gameObject, 0.2f);
            }
        }

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

        Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position) + new Vector3(0, -30, 0);
        healthBar.transform.position = screenPos;
    }
}
