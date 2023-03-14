using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private List<GameObject> fruits;
    [SerializeField] private GameObject player;
    [SerializeField] private ParticleSystem Snow;
    //[SerializeField] private GameObject sword;

    private float time;
    private Vector3 start;
    private bool locking;
    
    [SerializeField] private float range;

    private void Start()
    {
        locking = false;
    }

    void Update()
    {
        if(start!= null) { 
            player.transform.position = start + new Vector3(0,5,0);

            if (!locking) {
                //GameObject s = Instantiate(sword, player.transform.position + transform.forward * 2, Quaternion.identity);
                locking = true;
                //s.transform.tag = "Sword";
                Instantiate(Snow, player.transform.position + new Vector3(0, 50, 0), Quaternion.identity);
            }
            time += Time.deltaTime;

            if(time > 1) {
                int e = Random.Range(0, fruits.Count);
                if (e == fruits.Count - 1)
                {
                    if (Random.Range(1,2) == 1) {
                        GameObject g = Instantiate(fruits[e], new Vector3(Random.Range(transform.position.x + range, transform.position.x - range), transform.position.y + 7, Random.Range(transform.position.z + range, transform.position.z - range)), Quaternion.identity);
                        g.GetComponent<Rigidbody>().AddForce(new Vector3(0, 500, 0) * Time.deltaTime, ForceMode.Impulse);
                        time = 0;

                        if (Vector3.Distance(g.transform.position, player.transform.position) < 2.5f)
                        {
                            Destroy(g);
                        }
                    }
                }
                else { 
                    GameObject g = Instantiate(fruits[e], new Vector3(Random.Range(transform.position.x + range, transform.position.x - range), transform.position.y+7, Random.Range(transform.position.z + range, transform.position.z - range)), Quaternion.identity);
                    g.GetComponent<Rigidbody>().AddForce(new Vector3(0, 500, 0) * Time.deltaTime, ForceMode.Impulse);
                    time = 0;

                    if (Vector3.Distance(g.transform.position, player.transform.position) < 2.5f){
                        Destroy(g);
                    }
                }
            }
        }
    }

    public void setSpawn(Vector3 max)
    {
        start = max;
    }

}
