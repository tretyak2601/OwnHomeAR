using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using OwnHomeAR.UI;
using UnityEngine.Events;
using System;
using UnityEngine.Experimental.XR;

namespace OwnHomeAR.Gameplay
{
    public class ARController : MonoBehaviour
    {
        [SerializeField] ARSessionOrigin session;
        [SerializeField] Helper navigatePrefab;
        Helper Navigate;

        public Element ElementPrefab { get; set; }
        UnityEngine.Object elementObject;

        bool findPlane;
        public bool FindPlane { get; set; }

        public void Activate(bool flag, Element el, UnityEngine.Object obj)
        {
            FindPlane = true;
            ElementPrefab = el;
            elementObject = obj;

            if (Navigate)
            {
                Navigate.gameObject.SetActive(true);
                FindPlane = true;
            }
            else
                ARSubsystemManager.planeAdded += PlaneAddedHandler;
        }

        private void PlaneAddedHandler(UnityEngine.Experimental.XR.PlaneAddedEventArgs obj)
        {
            try
            {
                if (Navigate == null)
                {
                    Navigate = Instantiate(navigatePrefab, obj.Plane.Pose.position, Quaternion.identity);
                    Navigate.transform.localEulerAngles = new Vector3(90, 0, 0);
                    Navigate.Init(() =>
                    {
                        InstantiateObject(Navigate.transform.position);
                        FindPlane = false;
                        Navigate.gameObject.SetActive(false);
                    });

                    FindPlane = true;
                    StartCoroutine(SetPositionHelper());
                }

                if (!FindPlane)
                    return;
            }
            catch(Exception e)
            {
                Debug.LogAssertion(e.Message);
            }
        }

        public void Test()
        {
            GameObject parent = new GameObject("parent");
            parent.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

            var fl = Instantiate(ElementPrefab, Vector3.zero, Quaternion.identity, parent.transform);
            fl.InitElement(elementObject);
            fl.transform.localEulerAngles = new Vector3(-90, 0, 0);
            fl.transform.localPosition = new Vector3(0, 0, 30);
        }

        IEnumerator SetPositionHelper()
        {
            while (true)
            {
                while (FindPlane)
                {
                    ARSubsystemManager.raycastSubsystem.Start();

                    List<ARRaycastHit> hitResults = new List<ARRaycastHit>();

                    while (Navigate)
                    {
                        Ray ray = new Ray(session.camera.transform.position, session.camera.transform.TransformDirection(Vector3.forward) * 100);
                        int succesNum = 0;

                        if (session.Raycast(ray, hitResults, TrackableType.PlaneWithinBounds))
                        {
                            succesNum = hitResults.Count - 1;
                            Navigate.transform.position = hitResults[succesNum].sessionRelativePose.position;
                        }

                        yield return new WaitForSeconds(0.1f);
                    }
                }

                yield return new WaitForSeconds(0.1f);
            }
        }

        void InstantiateObject(Vector3 position)
        {
            GameObject parent = new GameObject("parent");
            parent.transform.position = position; //obj.Plane.Pose.position;
            parent.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

            Instantiate(ElementPrefab, position, Quaternion.identity, parent.transform).InitElement(elementObject);
        }
    }
}