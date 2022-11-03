using Footkin.Base;
using UnityEngine;

namespace Footkin.Controller
{
    public class ProjectileController : MonoBehaviour
    {
        [SerializeField] float speed = 10f;
        [SerializeField] GameObject deathVFX;

        CharacterController characterController;
        float lifetime = 2f;
        int damage;
        Vector3 Direction;

        [SerializeField] AudioClip destroyClip;

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
            if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Enemy"))
            {
                AudioSource.PlayClipAtPoint(destroyClip, transform.position);
                other.gameObject.GetComponent<Character>().ReceiveDamage(damage);
                Destroy(this.gameObject);
                Instantiate(deathVFX, transform.position, Quaternion.identity);
            }
        }
    }
}