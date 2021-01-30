using UnityEngine;

namespace Assets.Scripts
{
    public class Container
    {
        public static Container Instance = new Container();
        public UIScript PopupService { get; set; }

        private Container()
        {
            //PopupService = GameObject.FindGameObjectWithTag("Management").GetComponent<UIScript>();
        }
    }
}