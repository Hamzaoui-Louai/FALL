using UnityEngine;

[RequireComponent(typeof(Transform))]
public class CameraBehaviour : MonoBehaviour
{
    Transform transform;
    Transform playerTransform;
    [SerializeField] float upperLimit;
    [SerializeField] float lowerLimit;

    void Start()
    {
        transform = GetComponent<Transform>();
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        StandardBehaviour();
    }

    void StandardBehaviour()
    {
        transform.position = new Vector3(0,(playerTransform.position.y >= upperLimit)? upperLimit : (playerTransform.position.y < lowerLimit) ? lowerLimit : playerTransform.position.y, -10);
    }
}
