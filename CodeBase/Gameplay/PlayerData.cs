using UnityEngine;

namespace SpaceShooter
{
    [CreateAssetMenu]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] private bool m_HasRockets;

        public bool HasRockets { get; set; }


        [SerializeField] private int m_ShipMaxHitPoints;
        public int ShipMaxHitPoints
        {
            get
            {
                return m_ShipMaxHitPoints;
            }
            set
            {
                if (m_ShipMaxHitPoints > 0)
                {
                    m_ShipMaxHitPoints = value;
                }
            }
        }

    }
}

