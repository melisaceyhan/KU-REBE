﻿#if UNITY_ANDROID
using VoxelBusters.CoreLibrary.NativePlugins.Android;
using VoxelBusters.EssentialKit.NativeUICore.Android;

namespace VoxelBusters.EssentialKit.NativeUICore.Android
{
    internal sealed class AlertDialog : NativeAlertDialogInterfaceBase, INativeAlertDialogInterface
    {
        #region Fields

        private NativeAlert m_instance;

        #endregion

        #region Constructors

        public AlertDialog(AlertDialogStyle alertStyle)
        {
            m_instance = new NativeAlert(NativeUnityPluginUtility.GetContext());
        }

        ~AlertDialog()
        {
            Dispose(false);
        }

        #endregion

        #region Base class methods

        public override void SetTitle(string value)
        {
            m_instance.SetTitle(value);
        }

        public override string GetTitle()
        {
            return m_instance.GetTitle();
        }
            
        public override void SetMessage(string value)
        {
            m_instance.SetMessage(value);
        }

        public override string GetMessage()
        {
            return m_instance.GetMessage();
        }

        public override void AddButton(string text, bool isCancelType)
        {
            m_instance.AddButton(text, isCancelType);
        }

        public override void Show()
        {
            m_instance.Show(new NativeButtonClickListener()
            {
                onClickCallback = (index) =>
                {
                    SendButtonClickEvent(index);
                }
            });
        }

        public override void Dismiss()
        {
            m_instance.Dismiss();
        }

        #endregion
    }
}
#endif