using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.TestLogic
{
    public interface IChangeColor
    {
        void ChangeColorPlease();
        Color GetColor();
        GameObject GetGameObject();
    }
}
