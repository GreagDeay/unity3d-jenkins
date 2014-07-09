using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace Assets.UnityTestTools.UnitTesting
{


    public class ScriptInstantiator
    {

        private List<GameObject> GameObjects { get; set; }



        public ScriptInstantiator()
        {

            GameObjects = new List<GameObject>();

        }



        public T InstantiateScript<T>() where T : MonoBehaviour
        {

            Debug.Log("create prefab");
            GameObject gameObject;

            object prefab = Resources.Load("Prefabs/" + typeof(T).Name);



            // If there is no prefab with the same name, just use an empty object

            //

            if (prefab == null)
            {
                Debug.Log("creating gameobject");
                gameObject = new GameObject();

            }

            else
            {

                gameObject = GameObject.Instantiate(Resources.Load("Prefabs/"

                   + typeof(T).Name)) as GameObject;

            }



            Debug.Log("naming gameobject" + typeof(T).Name);
            gameObject.name = typeof(T).Name + " (Test)";



            // Prefabs should already have the component

            T inst = gameObject.GetComponent<T>();

            if (inst == null)
            {

                Debug.Log("add component" + typeof(T).Name);
                inst = gameObject.AddComponent<T>();

            }



            // Call the start method to initialize the object

            //

            MethodInfo startMethod = typeof(T).GetMethod("Start");

            if (startMethod != null)
            {

                Debug.Log("invoke start");
                startMethod.Invoke(inst, null);

            }



            GameObjects.Add(gameObject);

            return inst;

        }



        public void CleanUp()
        {

            foreach (GameObject gameObject in GameObjects)
            {

                // Destroy() does not work in edit mode

                GameObject.DestroyImmediate(gameObject);

            }



            GameObjects.Clear();

        }

    }
}
