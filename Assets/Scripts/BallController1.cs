using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController1 : MonoBehaviour
 
{
    public float speed;
    public float minDirection = 0.5f;
    public GameObject sparksVFX;

    private Vector3 direction;
    private Rigidbody rb;

    private bool stopped = true;
    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
       // ChooseDirection();
        
    }

    // Update is called once per frame
    void Update()
    {
       // transform.position += direction * speed * Time.deltaTime;
        
    }
    void FixedUpdate()
    {
        if (stopped) return;
       rb.MovePosition(this.rb.position + direction * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        bool hit = false;

        if (other.CompareTag("Wall")) {
            direction.z = -direction.z;
            hit = true;
        }
        if (other.CompareTag("Racket")) {

         //   direction.x = -direction.x;
            Vector3 newDirection = (transform.position - other.transform.position).normalized ;

           newDirection.x = Mathf.Sign(newDirection.x) * Mathf.Max(Mathf.Abs(newDirection.x), this.minDirection);
            newDirection.z = Mathf.Sign(newDirection.z) * Mathf.Max(Mathf.Abs(newDirection.z), this.minDirection);

            direction = newDirection;
            hit = true;
        }
        if (hit) {
           GameObject sparks = Instantiate(this.sparksVFX, transform.position, transform.rotation);
            Destroy(sparks, 4f);
        }
       

    }
    private void ChooseDirection()
    {
        float signX = Mathf.Sign(Random.Range(-1f, 1f));
        float signz = Mathf.Sign(Random.Range(-1f, 1f));
        this.direction = new Vector3(0.5f * signX, 0, 0.5f * signz);
        
    }
    public void Stop()
    {
        this.stopped = true;
    }

    public void Go() {
        ChooseDirection();
        this.stopped = false;
        
    }
}
