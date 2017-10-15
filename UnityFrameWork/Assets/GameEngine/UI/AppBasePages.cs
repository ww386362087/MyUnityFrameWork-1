using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.GameEngine
{
    public enum UIType
    {
        Normal = 0,
        PopUp
    }

    public enum UIMode
    {
        NeedBack = 0,
        HideOther,
    }

    public class AppBasePages : IOnFormUI
    {
        protected AppBasePages()
        {
        }

        protected AppBasePages(UIType type, UIMode mode, string path = "")
        {
            this.type = type;
            this.mode = mode;
            this.path = path;
        }

        public void Show()
        {
            if (this.CacheGameObject == null && this.path.IsNonNullOrEmpty())
            {
                CreateUI();
            }
            OnEnter();
            OnRefresh();
            AdjustDeep();
            CheakPageNodes(this);
        }

        private void AdjustDeep()
        {
            UIPanel[] panels = CacheTransform.TryGetChildComponent<UIPanel>(true);
            Array.ForEach(panels, p =>
            {
                p.depth = p.depth - panels[0].depth + UIDeep;
            });
            panels[0].depth = UIDeep;
            UIDeep += 1;
        }

        private Transform SetUIParent()
        {
            switch (type)
            {
                case UIType.Normal: return AppBootStrap.Instance.NormalRoot;
                case UIType.PopUp: return AppBootStrap.Instance.PopupRoot;
            }
            return null;
        }

        private void CreateUI()
        {
            this.CacheGameObject = GameObject.Instantiate(Resources.Load(path), SetUIParent()) as GameObject;
            this.CacheTransform = this.CacheGameObject.transform;
            OnInitUI();
        }

        public void Close()
        {
            CacheGameObject.SetActiveSafe(false);
            content = null;
            OnExit();
        }

        public virtual void OnEnter()
        {
            CacheGameObject.SetActiveSafe(true);
        }

        public virtual void OnRefresh()
        {
        }

        public virtual void OnExit()
        {
        }

        public virtual void OnInitUI()
        {
        }

        private UIType type;
        private UIMode mode;
        private string path;
        protected object content;
        protected GameObject CacheGameObject;
        protected Transform CacheTransform;
        public bool IsClearBackSequence { get { return mode == UIMode.HideOther; } }

        public static void CheakPageNodes(AppBasePages pages)
        {
            if (ShownPages.IsNull()) { ShownPages = new Dictionary<string, AppBasePages>(); }
            if (pages.IsClearBackSequence)
            {
                foreach (var item in ShownPages)
                {
                    item.Value.CacheGameObject.SetActiveSafe(false);
                    ShownPages.Remove(item.Key);
                }
            }
            bool isShown = false;
            foreach (var item in ShownPages)
            {
                if (item.Key == pages.CacheGameObject.name)
                {
                    isShown = false; break;
                }
            }
            if (isShown)
            {
                ShownPages.Remove(pages.CacheGameObject.name);
            }
            ShownPages.Add(pages.CacheGameObject.name, pages);
        }

        public static void ShowPage<T>() where T : AppBasePages, new()
        {
            string name = typeof(T).Name;
            if (AllPages.IsNonNullOrEmpty() && AllPages.ContainsKey(name))
            {
                ShowPage(name, AllPages[name], null, null);
            }
            else
            {
                T t = new T();
                ShowPage(name, t, null, null);
            }
        }

        public static void ShowPage(string name, AppBasePages pages, object content, Action callback = null)
        {
            if (AllPages.IsNull()) { AllPages = new Dictionary<string, AppBasePages>(); }
            AppBasePages page = null;
            if (!AllPages.ContainsKey(name))
            {
                AllPages.Add(name, pages);
            }
            page = AllPages[name];
            page.Show();
        }

        public static void ClosePage(string name, AppBasePages pages, Action callback = null)
        {
            if (ShownPages.IsNonNullOrEmpty() && pages.IsNonNull() && pages.CacheGameObject.IsNonNull())
            {
                if (ShownPages.ContainsKey(pages.CacheGameObject.name))
                {
                    ShownPages[pages.CacheGameObject.name].Close();
                    ShownPages.Remove(pages.CacheGameObject.name);
                }
            }
        }

        public static void ClosePage<T>()
        {
            string name = typeof(T).Name;
            if (AllPages.ContainsKey(name))
            {
                ClosePage(name, AllPages[name], null);
            }
        }

        private static int UIDeep = 5;
        public static Dictionary<string, AppBasePages> AllPages { get; set; }
        public static Dictionary<string, AppBasePages> ShownPages { get; set; }
    }
}