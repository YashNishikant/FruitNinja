
using UnityEngine;

public class Fruit : MonoBehaviour
{

    [SerializeField] private GameObject half;
    [SerializeField] private ParticleSystem exp;
    private bool canBreak;

    private void Start()
    {
        canBreak = true;
        if (Random.Range(1, 3) == 1)
            transform.GetComponent<Rigidbody>().AddTorque(transform.forward * 500);
        else
            transform.GetComponent<Rigidbody>().AddTorque(transform.forward * -500);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (canBreak && collision.transform.tag.Equals("Sword")) {
            FindObjectOfType<Score>().inc();
            GameObject e1 = Instantiate(half, transform.position, Quaternion.identity);
            GameObject e2 = Instantiate(half, transform.position, Quaternion.Euler(e1.transform.rotation.x, e1.transform.rotation.y + 180, e1.transform.rotation.z));
            Instantiate(exp, transform.position, Quaternion.identity);
            e1.GetComponent<Rigidbody>().AddForce(e1.transform.forward * Time.deltaTime * 100, ForceMode.Impulse);
            e2.GetComponent<Rigidbody>().AddForce(e2.transform.forward * Time.deltaTime * 100, ForceMode.Impulse);

            canBreak = false;

            Destroy(this.gameObject);
        }
    }
}
