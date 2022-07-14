using KHSave.SaveEditor.Common.Contracts;
using KHSave.SaveEditor.Common.Services;
using KHSave.SaveEditor.Ff7Remake.ViewModels;
using KHSave.SaveEditor.Kh02.ViewModels;
using KHSave.SaveEditor.Kh1.ViewModels;
using KHSave.SaveEditor.Kh2.ViewModels;
using KHSave.SaveEditor.Kh3.ViewModels;
using KHSave.SaveEditor.KhBbs.ViewModels;
using KHSave.SaveEditor.KhRecom.ViewModels;
using KHSave.SaveEditor.Persona5.ViewModels;
using KHSave.SaveEditor.KhDDD.ViewModels;
using KHSave.SaveEditor.ViewModels;
using KHSave.SaveEditor.Views;
using System;
using System.Windows.Controls;
using Unity;
using KHSave.LibPersona3.Models;
using KHSave.SaveEditor.Persona3.ViewModels;

namespace KHSave.SaveEditor.Services
{
    public enum ContentType
    {
        Unload,
        Archive,
        KingdomHearts,
        KingdomHearts2,
        KingdomHeartsBbs,
        KingdomHeartsDDD,
        KingdomHeartsRecom,
        KingdomHearts02,
        KingdomHearts3,
        FinalFantasy7Remake,
        Persona3,
        Persona5,
    }

    public class ContentResponse
    {
        public UserControl Control { get; set; }
        public IOpenStream OpenStream { get; set; }
        public IWriteToStream WriteToStream { get; set; }
        public IRefreshUi RefreshUi { get; set; }
        public IGetSave GetSave { get; set; }
    }

    public class ContentFactory
    {
        private readonly IUnityContainer container;

        public ContentFactory(IUnityContainer container)
        {
            this.container = container;
        }

        public ContentResponse Factory(ContentType saveType) => saveType switch
        {
            ContentType.Unload => FactoryView<HomeView, HomeViewModel>(),
            ContentType.KingdomHearts => FactoryEditorView<Kh1.MainView, Kh1ViewModel>(),
            ContentType.KingdomHearts2 => FactoryEditorView<Kh2.MainView, Kh2ViewModel>(),
            ContentType.KingdomHeartsBbs => FactoryEditorView<KhBbs.MainView, KhBbsViewModel>(),
            ContentType.KingdomHeartsDDD => FactoryEditorView<KhDDD.MainView, KhDDDViewModel>(),
            ContentType.KingdomHeartsRecom => FactoryEditorView<KhRecom.MainView, KhRecomViewModel>(),
            ContentType.KingdomHearts02 => FactoryEditorView<Kh02.MainView, Kh02ViewModel>(),
            ContentType.KingdomHearts3 => FactoryEditorView<Kh3.MainView, Kh3ViewModel>(),
            ContentType.FinalFantasy7Remake => FactoryEditorView<Ff7Remake.Views.FF7RMainView, FF7RMainViewModel>(),
            ContentType.Persona3 => FactoryEditorView<Persona3.Views.Persona3MainView, Persona3MainViewModel>(),
            ContentType.Persona5 => FactoryEditorView<Persona5.Views.Persona5MainView, Persona5MainViewModel>(),
            _ => throw new Exception($"Factory for {saveType} not yet implemented."),
        };

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
                case ContentType.KingdomHeartsBbs:
                    iconPack = IconService.IconPack.KingdomHeartsBbs;
                    break;
                case ContentType.KingdomHeartsDDD:
                    iconPack = IconService.IconPack.KingdomHeartsDdd;
                    break;
                case ContentType.FinalFantasy7Remake:
                    iconPack = IconService.IconPack.FF7Remake;
                    break;
                case ContentType.Persona3:
                case ContentType.Persona5:
                    iconPack = IconService.IconPack.Persona5;
                    break;
                default:
                    throw new Exception($"IconPack for {saveType} not yet implemented.");
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
                RefreshUi = context,
                GetSave = context as IGetSave,
            };
        }
    }
}
