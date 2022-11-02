using Footkin.Base;
using UnityEngine;

namespace Footkin.Controller
{
    public class ProjectileController : MonoBehaviour
    {

        CharacterController characterController;

        [SerializeField]
        float speed = 10f;
        float lifetime = 2f;
        int damage;
        Vector3 Direction;

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
        }

        public void SetDamage(int damage)
        {
            this.damage = damage;
        }

        public void SetDirection(Vector3 direction)
        {
            Direction = direction;
        }

        private void Update()
        {
            characterController.Move(Direction * Time.deltaTime * speed);
            lifetime -= Time.deltaTime;
            if(lifetime < 0)
            {
                Destroy(this.gameObject);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.gameObject.tag);
            if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Enemy"))
            {
                other.gameObject.GetComponent<Character>().ReceiveDamage(damage);
                Destroy(this.gameObject);
            }
        }
    }
}