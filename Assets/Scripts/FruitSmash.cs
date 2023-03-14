using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSmash : MonoBehaviour
{

    [SerializeField] private ParticleSystem exp;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.tag.Equals("Sword"))
        {
            FindObjectOfType<Score>().inc();
            Instantiate(exp, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
