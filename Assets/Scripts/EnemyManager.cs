using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public HealthManager healthManager;
    public int damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        damage = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

   // private void OnCollisionEnter2D(Collision2D collision)
  //  {
      //  if (collision.gameObject.tag == "Player")
      //  {
       //     healthManager.TakeDamage(damage);
       //     Debug.Log("1 Damage taken!");
      //  }

       

  //  }
}
