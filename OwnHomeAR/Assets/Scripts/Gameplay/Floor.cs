using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OwnHomeAR.Gameplay
{
    [RequireComponent(typeof(MeshRenderer))]
    public class Floor : Element
    {
        [SerializeField] float scaleSpeed;
        [SerializeField] List<Border> borders;

        MeshRenderer mesh;

        bool needSetSize;
        public bool NeedSetSize
        {
            get
            {
                return needSetSize;
            }
            set
            {
                needSetSize = value;

                foreach (var b in borders)
                    b.gameObject.SetActive(value);
            }
        }

        void Awake()
        {
            mesh = GetComponent<MeshRenderer>();
        }

        void Start()
        {
            foreach (var b in borders)
                b.InitBorder(transform, scaleSpeed);
        }

        public override void InitElement(UnityEngine.Object obj, Action<bool> showMenuAction, Transform parentScale)
        {
            base.InitElement(obj, showMenuAction, parentScale);

            Texture2D texture = obj as Texture2D;
            Material mat = new Material(mesh.sharedMaterial);
            mesh.material = mat;
            mesh.material.mainTexture = texture;
        }

        public override void ShowMenu(bool flag)
        {
            base.ShowMenu(flag);
            NeedSetSize = flag;
        }

        void Update()
        {
            if (needSetSize)
                SetSize();
        }

        public void SetSize()
        {
            mesh.material.mainTextureScale = new Vector2(transform.localScale.x, transform.localScale.z);

            foreach (var border in borders)
                border.UpdateSize();
        }
    }
}
