using UnityEngine;

namespace Misc
{
    public class ObjectRotator : MonoBehaviour
    {
        [SerializeField] private float speed = 1f;
        [SerializeField] private Vector3 rotation = new (1f,1f,1f);
    
        void Update()
        {
            transform.Rotate(rotation.x * speed, rotation.y * speed, rotation.z * speed);
        }
    }
}
