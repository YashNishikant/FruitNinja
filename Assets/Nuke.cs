using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuke : MonoBehaviour
{
    [SerializeField] private ParticleSystem exp;
    private bool candestroy;

    private void Start()
    {
        candestroy = true;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.tag.Equals("Sword") && candestroy)
        {
            FindObjectOfType<Score>().reset();
            Instantiate(exp, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        if (collision.transform.tag.Equals("Floor"))
        {
            candestroy = false;
            Destroy(this.gameObject);
        }
    }
}
