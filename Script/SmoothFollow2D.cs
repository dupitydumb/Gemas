using UnityEngine;
using System.Collections;

public class SmoothFollow2D : MonoBehaviour {

    //offset from the viewport center to fix damping
    public float m_DampTime = 10f;
    public Transform m_Target;
    public float m_XOffset = 0;
    public float m_YOffset = 0;

	private float margin = 0.1f;

	public float min_x = 0;
	public float max_X = 0;
	void Start () {
		if (m_Target==null){
			m_Target = GameObject.FindGameObjectWithTag("Player").transform;
		}
	}

    void Update() {
        if (m_Target)
        {
            float targetX = m_Target.position.x + m_XOffset;
            float targetY = m_Target.position.y + m_YOffset;

            if (Mathf.Abs(transform.position.x - targetX) > margin)
                targetX = Mathf.Lerp(transform.position.x, targetX, 1 / m_DampTime * Time.deltaTime);

            if (Mathf.Abs(transform.position.y - targetY) > margin)
                targetY = Mathf.Lerp(transform.position.y, targetY, m_DampTime * Time.deltaTime);
            transform.position = new Vector3(targetX, targetY, transform.position.z);

            if (transform.position.x < min_x)
            {
                transform.position = new Vector3(min_x, transform.position.y, transform.position.z);
            }
            else if (transform.position.x > max_X)
            {
                transform.position = new Vector3(max_X, transform.position.y, transform.position.z);
            }

        }
    }
}