using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;

namespace Assets.Scripts.DTO
{
    public class MainPopupDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public PopupType Type { get; set; }
        public UnityAction OkButtonClickAction { get; set; }
    }
}
