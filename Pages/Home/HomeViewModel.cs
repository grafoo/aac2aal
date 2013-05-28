using Okra.Core;
using Okra.Navigation;
using aac2aal_UI.Common;
using aac2aal_UI.Data;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Kernel;
using Windows.UI.Xaml;
using System.IO;
using Windows.Storage;
using Kernel.Stubs;
using Kernel.Services;

namespace aac2aal_UI.Pages.Home
{
    /// <summary>
    /// A view-model for displaying a grouped collection of items.
    /// </summary>
    [ViewModelExport("Home")]
    public class HomeViewModel : ViewModelBase
    {
        private IEnumerable<SampleDataGroup> groups;

        protected HomeViewModel()
        {
        }

        [ImportingConstructor]
        public HomeViewModel(INavigationContext navigationContext)
            : base(navigationContext)
        {
            //this.m();
            Initialize();
            InitializeCommands();
            
            
        }
        /*
        public async void m()
        {

            StorageFolder storageFolder = KnownFolders.DocumentsLibrary;
            StorageFile json = await storageFolder.GetFileAsync("json.txt");
            string text = await Windows.Storage.FileIO.ReadTextAsync(json);
            JsonUtils ju = new JsonUtils();
            this.ebm = ju.convertfromJson(text);
            Body body = ebm.Body;

        }*/


        public IEnumerable<SampleDataGroup> Groups
        {
            get
            {
                return groups;
            }
            protected set
            {
                SetProperty(ref groups, value);
            }
        }

        public ICommand NavigateToGroupDetailCommand { get; private set; }

        /// <summary>
        /// Initializes the page with content.
        /// </summary>
        private void Initialize()
        {
            // TODO: Create an appropriate data model for your problem domain to replace the sample data
            Data.SampleDataSource.RefreshDataSource();
            Groups = SampleDataSource.GetGroups("AllGroups");
        }

        /// <summary>
        /// Initializes all commands with their associates actions.
        /// </summary>
        private void InitializeCommands()
        {
            NavigateToGroupDetailCommand = new DelegateCommand<string>(NavigateToGroupDetail);
        }

        /// <summary>
        /// Navigates to the 'GroupDetail' page associated with the supplied unique-ID.
        /// </summary>
        /// <param name="uniqueId">The ID of the item to display.</param>
        private void NavigateToGroupDetail(string uniqueId)
        {
            NavigationManager.NavigateTo("GroupDetail", uniqueId);
        }

        /// <summary>
        /// Navigates to the 'ItemDetail' page associated with the supplied unique-ID.
        /// </summary>
        /// <param name="uniqueId">The ID of the item to display.</param>
        public void NavigateToItemDetail(string uniqueId)
        {
            NavigationManager.NavigateTo("ItemDetail", uniqueId);
        }
    }
}
