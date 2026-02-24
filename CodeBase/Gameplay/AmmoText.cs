using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter
{
    public class AmmoText : MonoBehaviour
    {
        [SerializeField] private Text m_AmmoText;

        private void Update()
        {
            SpaceShip ship = Player.Instance.ActiveShip;
            
            if (ship != null)
            {
                int ammo = ship.SecondaryAmmo;

                if (Player.Instance.UsedData.HasRockets)
                {
                    m_AmmoText.text = ship.SecondaryAmmo.ToString();
                }
                else
                {
                    m_AmmoText.text = "You haven't got rocket weapon!";
                }
            }
            else
            {
                m_AmmoText.text = "You lack space ship!";
            }

            
            
        }
    }
}

