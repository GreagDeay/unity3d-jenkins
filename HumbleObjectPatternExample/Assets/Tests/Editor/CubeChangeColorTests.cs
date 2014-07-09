using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using Assets.TestLogic;
using Assets.UnityTestTools.UnitTesting;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Assets.Tests.Editor
{
    public class CubeChangeColorTests
    {
        [Test]
        public void IsColorChangedColor()
        {
            var colorObject = getChangeColorClass();
            var color = colorObject.GetColor();
            colorObject.ChangeColorPlease();
            Assert.AreNotEqual(color, colorObject.GetColor());
        }

        [Test]
        public void SeveralCallsTest()
        {
            var colorObject = getChangeColorClass();
            var color = colorObject.GetColor();
            colorObject.ChangeColorPlease();
            colorObject.ChangeColorPlease();
            colorObject.ChangeColorPlease();
            Assert.AreNotEqual(color, colorObject.GetColor());
        }

        [Test]
        public void CompareColorsAfter5SecWait()
        {
            var colorObject = getChangeColorClass();
            colorObject.ChangeColorPlease();
            var color = colorObject.GetColor();
            Thread.Sleep(5000);
            Assert.AreEqual(color, colorObject.GetColor());
        }

        private ChangeColor getChangeColorClass()
        {
            Debug.Log("instantiate");
            return new ScriptInstantiator().InstantiateScript<ChangeColor>();
        }
    }
}
