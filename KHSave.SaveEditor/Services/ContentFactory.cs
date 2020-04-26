﻿using KHSave.SaveEditor.Common.Contracts;
using KHSave.SaveEditor.Common.Services;
using KHSave.SaveEditor.Ff7Remake.ViewModels;
using KHSave.SaveEditor.Kh02.ViewModels;
using KHSave.SaveEditor.Kh2.ViewModels;
using KHSave.SaveEditor.Kh3.ViewModels;
using KHSave.SaveEditor.KhRecom.ViewModels;
using KHSave.SaveEditor.Kh1.ViewModels;
using KHSave.SaveEditor.ViewModels;
using KHSave.SaveEditor.Views;
using System;
using System.Windows.Controls;
using Unity;

namespace KHSave.SaveEditor.Services
{
    public enum ContentType
    {
        Unload,
        Archive,
        KingdomHearts,
        KingdomHearts2,
        KingdomHeartsRecom,
        KingdomHearts02,
        KingdomHearts3,
        FinalFantasy7Remake,
    }

    public class ContentResponse
    {
        public UserControl Control { get; set; }
        public IOpenStream OpenStream { get; set; }
        public IWriteToStream WriteToStream { get; set; }
        public IRefreshUi RefreshUi { get; set; }
    }

    public class ContentFactory
    {
        private readonly IUnityContainer container;

        public ContentFactory(IUnityContainer container)
        {
            this.container = container;
        }

        public ContentResponse Factory(ContentType saveType)
        {
            switch (saveType)
            {
                case ContentType.Unload: return FactoryView<HomeView, HomeViewModel>();
                case ContentType.KingdomHearts: return FactoryEditorView<Kh1.MainView, Kh1ViewModel>();
                case ContentType.KingdomHearts2: return FactoryEditorView<Kh2.MainView, Kh2ViewModel>();
                case ContentType.KingdomHeartsRecom: return FactoryEditorView<KhRecom.MainView, KhRecomViewModel>();
                case ContentType.KingdomHearts02: return FactoryEditorView<Kh02.MainView, Kh02ViewModel>();
                case ContentType.KingdomHearts3: return FactoryEditorView<Kh3.MainView, Kh3ViewModel>();
                case ContentType.FinalFantasy7Remake: return FactoryEditorView<Ff7Remake.Views.FF7RMainView, FF7RMainViewModel>();
                default: throw new Exception($"Factory for {saveType} not yet implemented.");
            }
        }

        public void LoadIconPack(ContentType saveType)
        {
            IconService.IconPack iconPack;
            switch (saveType)
            {
                case ContentType.Unload:
                    return;
                case ContentType.KingdomHearts:
                case ContentType.KingdomHearts2:
                case ContentType.KingdomHeartsRecom:
                case ContentType.KingdomHearts02:
                case ContentType.KingdomHearts3:
                    iconPack = IconService.IconPack.KingdomHearts2;
                    break;
                case ContentType.FinalFantasy7Remake:
                    iconPack = IconService.IconPack.FF7Remake;
                    break;
                default: throw new Exception($"IconPack for {saveType} not yet implemented.");
            }

            IconService.UseIconPack(iconPack);
        }

        private ContentResponse FactorySimpleView<TControl>()
            where TControl : UserControl => new ContentResponse
            {
                Control = container.Resolve<TControl>()
            };

        private ContentResponse FactoryView<TControl, TContext>()
            where TControl : UserControl
            where TContext : class
        {
            var control = container.Resolve<TControl>();
            control.DataContext = container.Resolve<TContext>();

            return new ContentResponse
            {
                Control = control,
            };
        }

        private ContentResponse FactoryEditorView<TControl, TContext>()
            where TControl : UserControl
            where TContext : IOpenStream, IWriteToStream, IRefreshUi
        {
            var context = container.Resolve<TContext>();
            var control = container.Resolve<TControl>();
            control.DataContext = context;

            return new ContentResponse
            {
                Control = control,
                OpenStream = context,
                WriteToStream = context,
                RefreshUi = context
            };
        }
    }
}
