
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    public GameObject cube;
    public Rigidbody rb;
    public BoxCollider bc;
    public int difficulty = 2;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                bc = hit.collider as BoxCollider;
                if (bc != null)
                {
                    Debug.Log("CUBE HIT");
                    CubeSpawner();
                    GameManager.Instance.ScoreCounter();
                    Destroy(bc.gameObject);
                }
            }
        }
    }

    private void CubeSpawner()
    {
        bool cubeSpawned = false;
        while (!cubeSpawned)
        {
            Vector3 cubePos = new Vector3(Random.Range(-4.5f, 4.5f), 1f, Random.Range(-4.5f, 4.5f));
            if ((cubePos - transform.position).magnitude < difficulty)
            {
                continue;
            }
            else
            {
                Instantiate(cube, cubePos, Quaternion.identity);
                cubeSpawned = true;
            }
        }
    }
}
