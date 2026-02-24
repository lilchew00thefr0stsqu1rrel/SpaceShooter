using UnityEngine;

namespace Common
{
    public abstract class ProjectileBase : Entity
    {
        // Для дальнейшего расширения игры.
        [Header("Properties: Scriptable Object")]
        [SerializeField] private ProjectileProperties m_Properties;

        [Header("Properties: Values")]
        [SerializeField] private float m_Velocity;

        [SerializeField] private float m_Lifetime;

        [SerializeField] protected int m_Damage;


        

        [SerializeField] private bool isHoming;


        [SerializeField] private float m_HomingRadius;

        [SerializeField] private float m_ExplosionRadius;

        private Vector3 m_EnemyPos;  // Gizmos

        private Vector2 m_Direction;

        private RaycastHit2D circleHit;

       

        //[SerializeField] private ExplosionEffect m_ExplosionEffect;

        protected virtual void OnHit(DestructibleBase destructible) { }
        protected virtual void OnHit(Collider2D collider2D) { }
        protected virtual void OnProjectileLifeEnd(Collider2D col, Vector2 pos) { }

        private float m_Timer;

        protected DestructibleBase m_Parent;

        private void Start()
        {
           

            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.Play();

            m_Direction = transform.up;

            //m_ExplosionEffect = GetComponent<ExplosionEffect>();


        }

        private void Update()
        {
            float stepLength = Time.deltaTime * m_Velocity;

            Vector2 step = m_Direction * stepLength;

            if (isHoming)
            {
                // Область самонаведения.
                RaycastHit2D circleHit = Physics2D.CircleCast(transform.position - 2 * transform.up, m_HomingRadius, transform.up, stepLength);


                //Debug.Log((bool) circleHit + " / Ayato");

                if (circleHit)
                {
                    //Debug.Log(circleHit.transform.position + " / Lauma");

                    

                    DestructibleBase destHoming = circleHit.transform.root.GetComponent<DestructibleBase>();

                    //Debug.Log((bool) destHoming + " / Dolls");

                   

                    if (destHoming != null && destHoming.TeamId != m_Parent.TeamId)
                    {
                        // Позиция цели.
                        m_EnemyPos = destHoming.transform.position;

                        
                        //Debug.Log(destHoming.transform.root.name + " / Kuutar42913");

                        // отрезок, соединяющий позиции снаряда и цели. 
                        Vector2 arrowToTarget = (Vector2)(m_EnemyPos - transform.position);

                       

                        m_Direction = arrowToTarget.normalized;
                        

                        //Debug.Log(m_Direction + " / Nefer");

                       

                        //destHoming.ApplyDamage(m_Damage);

                        
                        

                    }
                }
                
            }

            else  // Если не самонаводящийся снаряд
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, stepLength);
                
                if (hit)
                {
                    OnHit(hit.collider);

                    DestructibleBase dest = hit.collider.transform.root.GetComponent<DestructibleBase>();

                    if (dest != null && dest != m_Parent)
                    {
                        //Debug.Log(m_Damage.ToString() + " Mwah");
                        dest.ApplyDamage(m_Damage);   
                        
                        OnHit(dest); 

                        
                    }

                    OnProjectileLifeEnd(hit.collider, hit.point);
                }
                m_Timer += Time.deltaTime;

                if (m_Timer > m_Lifetime) 
                    OnProjectileLifeEnd(hit.collider, hit.point);
            }

                

             

            transform.position += new Vector3(step.x, step.y, 0);

            
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log("lemur " + collision.gameObject.name);

            if (m_Parent == null)
            {
                //BeforeDestroy();
                //Destroy(gameObject);

                OnProjectileLifeEnd(collision, collision.transform.position);
            }

            if (m_Parent != null && collision.transform.root != m_Parent.transform)
            {
                //BeforeDestroy();
                //Destroy(gameObject);  // Уничтожить снаряд.

                OnProjectileLifeEnd(collision, collision.transform.position);
            }         
        }



     


        public void SetParentShooter(DestructibleBase parent)
        {
            m_Parent = parent;
        }


       

        private void BeforeDestroy()
        {
           // if (m_ExplosionEffect != null)
            {
             //   m_ExplosionEffect.Explode(transform.position, m_Parent, m_Damage);
            }
          //  OnDestroy();
        }


        //private void OnDestroy()
        //{

            

        //}




#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            //if (m_EnemyPos == Vector3.zero) return;



            //Gizmos.color = Color.red;
            //Gizmos.DrawLine(transform.position + new Vector3(0, -m_HomingRadius, 0), m_EnemyPos);

            Gizmos.color = Color.blue;
        }
#endif
    }
}

