using UnityEngine;
using System.Collections;

public class playerScript : MonoBehaviour {

    float shotinterval = 0;
    public Transform missilePrefab;
    public Transform enemy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (shotinterval <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                for (int i = 0; i < 5; ++i)
                {
                    Quaternion qqq = Quaternion.Euler(0, i * 40 -80, 0);
                    Transform msl = Instantiate(missilePrefab, transform.position + new Vector3(i*2 - 4,0,0), qqq) as Transform;
                    msl.GetComponent<missileMoveScript>().TargetEnemy = enemy;
                }
                shotinterval = 8;
            }
        }
        else
        {
            shotinterval -= 1;
        }

    }
}
