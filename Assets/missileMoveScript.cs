using UnityEngine;
using System.Collections;

public class missileMoveScript : MonoBehaviour {

    public Transform expl;

    Transform targetEnemy;
    float turnSpeed = 5;
    float forwardSpeed = 0;
    public Transform TargetEnemy
    {
        set {
            targetEnemy = value;
        }
    }

	// Use this for initialization
	void Start () {
	}

    // Update is called once per frame
    void Update() {
        Vector3 myDirc = transform.TransformDirection(Vector3.forward);
        Vector3 toEnemy = targetEnemy.position - transform.position;
        Vector3 cv = Vector3.Cross(myDirc, toEnemy.normalized);
        if (cv.y > 0)
        {
            transform.Rotate(new Vector3(0, 1, 0), turnSpeed);
        }
        else if(cv.y < 0)
        {
            transform.Rotate(new Vector3(0, 1, 0), -turnSpeed);
        }
        forwardSpeed += Time.deltaTime * 100f;
        transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed);

    }

    void OnTriggerEnter(Collider _other)
    {
        if(_other.tag == "Enemy")
        {
            Instantiate(expl,transform.position,Quaternion.identity);
            Destroy(this.gameObject);

        }
    }
}
