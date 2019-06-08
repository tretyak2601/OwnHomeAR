using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using OwnHomeAR.UI;
using UnityEngine.Events;
using System;
using UnityEngine.Experimental.XR;
using OwnHomeAR.ObjectControllers;

namespace OwnHomeAR.Gameplay
{
    public class ARController : MonoBehaviour
    {
        [SerializeField] ScaleController scale;
        [SerializeField] RotateController rotate;
        [SerializeField] MoveController move;

        [SerializeField] GameObject helpMenu;
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

            var temp = Instantiate(ElementPrefab, position, Quaternion.identity, parent.transform);
            temp.InitElement(elementObject, ShowMenu, parent.transform);
            scale.InitController(parent.transform, temp);
            rotate.InitController(parent.transform, temp);
            move.InitController(parent.transform, temp);
        }

        void ShowMenu(bool flag) => helpMenu.SetActive(flag);
    }
}