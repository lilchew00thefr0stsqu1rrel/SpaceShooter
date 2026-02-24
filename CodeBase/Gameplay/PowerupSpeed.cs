using UnityEngine;

namespace SpaceShooter
{
    public class PowerupSpeed : Powerup
    {
        [SerializeField] private float m_Value;

        [SerializeField] private Transform m_DurationRemnantPrefab;

        [SerializeField] private float m_EffectDuration;
        public float EffectDuration => m_EffectDuration;



        protected override void OnPickedUp(SpaceShip ship)
        {
            ship.AddMaxLinearVelocity(m_Value); 
            Transform remnant = Instantiate(m_DurationRemnantPrefab, transform.position, Quaternion.identity);
            remnant.GetComponent<TemporaryEffect>()?.InitTimeCount(m_EffectDuration, ship);

        }

        

     

        
    }
}

