using UnityEngine;

namespace SpaceShooter
{
    public class PowerupWeapon : Powerup
    {
        [SerializeField] private TurretProperties m_Properties;
        [SerializeField] private Player m_Player;
        
        protected override void OnPickedUp(SpaceShip ship)
        {
            ship.AssignWeapon(m_Properties);
            m_Player.UsedData.HasRockets = true;
        }
    }

}
