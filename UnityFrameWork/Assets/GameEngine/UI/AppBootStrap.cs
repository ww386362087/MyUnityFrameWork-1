using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.GameEngine
{
    public class AppBootStrap : MonoSingleton<AppBootStrap>
    {
        public override void OnInitialized()
        {
            base.OnInitialized();
            Init();
        }

        private void Init()
        {
            InitializedUIRoot();
            CacheComonpent();
            AppBasePages.ShowPage<UILoginPage>();
        }

        private void CacheComonpent()
        {
            CacheTransform.AddChild<EventHandler>();
            CacheTransform.AddChild<AsyncLoadTexture>();
            CacheTransform.AddChild<ModelMgr>();
        }

        private void InitializedUIRoot()
        {
            uIPanel = NGUITools.CreateUI(false);
            uIRoot = uIPanel.GetComponent<UIRoot>();
            uIRoot.scalingStyle = UIRoot.Scaling.ConstrainedOnMobiles;
            uIRoot.manualHeight = AppConst.ScreenHeight;
            uIRoot.manualWidth = AppConst.ScreenWeight;
            uIRoot.fitHeight = AppConst.IsRowMode;
            uIRoot.fitWidth = !AppConst.IsRowMode;

            NormalRoot = uIPanel.gameObject.AddChild().transform;
            NormalRoot.name = "NormalRoot";
            NormalRoot.transform.NodeInitialized();
            PopupRoot = uIPanel.gameObject.AddChild().transform;
            PopupRoot.name = "PopupRoot";
            PopupRoot.transform.NodeInitialized();
            uIPanel.transform.SetParent(this.transform);
            DontDestroyOnLoad(CacheTransform);
        }

        public override void OnDestory()
        {
            base.OnDestory();
            NormalRoot = PopupRoot = null;
        }

        public Transform NormalRoot { get; private set; }
        public Transform PopupRoot { get; private set; }
        public UIRoot uIRoot { get; private set; }
        public UIPanel uIPanel { get; private set; }
    }
}