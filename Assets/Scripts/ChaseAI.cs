using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChaseAI : MonoBehaviour
{
    private GameObject player;
    public float speed;
    public float chaseDistance;

    private float distance;

    

    // Skrypt szuka gracza i podchodzi do niego
    void FixedUpdate()
    {
        player = GameObject.Find("Player");
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        

        if (distance < chaseDistance)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }
        
    }
}
