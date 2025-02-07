using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Event
{
    public class ButtonPressEvent : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {

        public Action eventPressBTN;
        public Action eventReleaseBTN;

        public void OnPointerDown(PointerEventData eventData)
        {
            eventPressBTN.Invoke();

        }

        public void OnPointerUp(PointerEventData eventData)
        {
            eventReleaseBTN.Invoke();
        }
    }
}
