using System;
using Unity.VisualScripting;
using UnityEngine;

public class Stats_S : MonoBehaviour
{
    [SerializeField] public int Rank = 1;
    [SerializeField] public float Speed = 5f;
    [SerializeField] public GameObject explosionPrefab;
    private bool isAlive = false;


    private void Start()
    {
        isAlive = true;
    }
    
    private void Update()
    {
        if(!isAlive)
        {
            Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }   
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject other = collision.gameObject;
        if (other != null)
        {
            if (other.tag != gameObject.tag)
            {
                if (Rank == 11)
                {
                    isAlive = false;
                    return;
                }
                //checking if the rank 1 and bomb are colliding 
                else if (other.GetComponent<Stats_S>().Rank == 999)
                {
                    if (Rank == 1)
                    {
                        other.GetComponent<Stats_S>().isAlive = false;
                    }
                    isAlive = false;
                    return;
                }
                else if (other.GetComponent<Stats_S>().Rank != 11 && (Rank <= other.GetComponent<Stats_S>().Rank))
                {
                    if(Rank == other.GetComponent<Stats_S>().Rank)
                    {
                        other.GetComponent<Stats_S>().isAlive = false;
                    }
                    isAlive = false;
                    return;
                }
            }
            else { return; }
        }
        else { return ; }
    }
}
