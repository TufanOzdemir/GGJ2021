using UnityEngine;

namespace Assets.Scripts
{
    public class Container
    {
        public static Container Instance = new Container();
        public UIScript PopupService { get; set; }
        public PlayerStats PlayerStats { get; set; }
        public PlayerHealth PlayerHealth { get; set; }

        private Container()
        {
            PopupService = GameObject.FindGameObjectWithTag("Management").GetComponent<UIScript>();
            PlayerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
            PlayerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        }
    }
}