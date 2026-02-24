using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter
{
    public class HitpointText : MonoBehaviour
    {
        [SerializeField] private Text m_Text;

        private float lastHitPoints;
        private float lastMaxHitPoints;

        private string m_HPTextString;
        private string m_MHPTextString;

        private void Update()
        {
            if (Player.Instance == null) return;

            int hitPoints = Mathf.Max(Player.Instance.ActiveShip.HitPoints, 0);
            int maxHitPoints = Player.Instance.ActiveShip.MaxHitPoints;

            if (hitPoints != lastHitPoints)
            {
                m_HPTextString = hitPoints.ToString();
                lastHitPoints = hitPoints;
            }

            if (maxHitPoints != lastMaxHitPoints)
            {
                m_MHPTextString = maxHitPoints.ToString();
                lastMaxHitPoints = maxHitPoints;
            }

            m_Text.text = m_HPTextString + "/" + m_MHPTextString;
        }
    }
}
