using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.ApplicationModel.Resources.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using System.Collections.Specialized;
using aac2aal_UI.Pages.Home;
using Kernel;
using Kernel.Services;
using Kernel.Stubs;
using System.Threading.Tasks;

// The data model defined by this file serves as a representative example of a strongly-typed
// model that supports notification when members are added, removed, or modified.  The property
// names chosen coincide with data bindings in the standard item templates.
//
// Applications may use this model as a starting point and build on it, or discard it entirely and
// replace it with something appropriate to their needs.

namespace aac2aal_UI.Data
{
    /// <summary>
    /// Base class for <see cref="SampleDataItem"/> and <see cref="SampleDataGroup"/> that
    /// defines properties common to both.
    /// </summary>
    [Windows.Foundation.Metadata.WebHostHidden]
    public abstract class SampleDataCommon : aac2aal_UI.Common.BindableBase
    {
        private static Uri _baseUri = new Uri("ms-appx:///");

        public SampleDataCommon(String uniqueId, String title, String subtitle, String imagePath, String description)
        {
            this._uniqueId = uniqueId;
            this._title = title;
            this._subtitle = subtitle;
            this._description = description;
            this._imagePath = imagePath;
        }

        private string _uniqueId = string.Empty;
        public string UniqueId
        {
            get { return this._uniqueId; }
            set { this.SetProperty(ref this._uniqueId, value); }
        }

        private string _title = string.Empty;
        public string Title
        {
            get { return this._title; }
            set { this.SetProperty(ref this._title, value); }
        }

        private string _subtitle = string.Empty;
        public string Subtitle
        {
            get { return this._subtitle; }
            set { this.SetProperty(ref this._subtitle, value); }
        }

        private string _description = string.Empty;
        public string Description
        {
            get { return this._description; }
            set { this.SetProperty(ref this._description, value); }
        }

        private ImageSource _image = null;
        private String _imagePath = null;
        public ImageSource Image
        {
            get
            {
                if (this._image == null && this._imagePath != null)
                {
                    this._image = new BitmapImage(new Uri(SampleDataCommon._baseUri, this._imagePath));
                }
                return this._image;
            }

            set
            {
                this._imagePath = null;
                this.SetProperty(ref this._image, value);
            }
        }

        public void SetImage(String path)
        {
            this._image = null;
            this._imagePath = path;
            this.OnPropertyChanged("Image");
        }

        public override string ToString()
        {
            return this.Title;
        }
    }

    /// <summary>
    /// Generic item data model.
    /// </summary>
    public class SampleDataItem : SampleDataCommon
    {
        public SampleDataItem(String uniqueId, String title, String subtitle, String imagePath, String description, String content, SampleDataGroup group)
            : base(uniqueId, title, subtitle, imagePath, description)
        {
            this._content = content;
            this._group = group;
        }

        private string _content = string.Empty;
        public string Content
        {
            get { return this._content; }
            set { this.SetProperty(ref this._content, value); }
        }

        private SampleDataGroup _group;
        public SampleDataGroup Group
        {
            get { return this._group; }
            set { this.SetProperty(ref this._group, value); }
        }
    }

    /// <summary>
    /// Generic group data model.
    /// </summary>
    public class SampleDataGroup : SampleDataCommon
    {
        public SampleDataGroup(String uniqueId, String title, String subtitle, String imagePath, String description)
            : base(uniqueId, title, subtitle, imagePath, description)
        {
            Items.CollectionChanged += ItemsCollectionChanged;
        }

        private void ItemsCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // Provides a subset of the full items collection to bind to from a GroupedItemsPage
            // for two reasons: GridView will not virtualize large items collections, and it
            // improves the user experience when browsing through groups with large numbers of
            // items.
            //
            // A maximum of 12 items are displayed because it results in filled grid columns
            // whether there are 1, 2, 3, 4, or 6 rows displayed

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (e.NewStartingIndex < 12)
                    {
                        TopItems.Insert(e.NewStartingIndex, Items[e.NewStartingIndex]);
                        if (TopItems.Count > 12)
                        {
                            TopItems.RemoveAt(12);
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Move:
                    if (e.OldStartingIndex < 12 && e.NewStartingIndex < 12)
                    {
                        TopItems.Move(e.OldStartingIndex, e.NewStartingIndex);
                    }
                    else if (e.OldStartingIndex < 12)
                    {
                        TopItems.RemoveAt(e.OldStartingIndex);
                        TopItems.Add(Items[11]);
                    }
                    else if (e.NewStartingIndex < 12)
                    {
                        TopItems.Insert(e.NewStartingIndex, Items[e.NewStartingIndex]);
                        TopItems.RemoveAt(12);
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    if (e.OldStartingIndex < 12)
                    {
                        TopItems.RemoveAt(e.OldStartingIndex);
                        if (Items.Count >= 12)
                        {
                            TopItems.Add(Items[11]);
                        }
                    }
                    break;
                case NotifyCollectionChangedAction.Replace:
                    if (e.OldStartingIndex < 12)
                    {
                        TopItems[e.OldStartingIndex] = Items[e.OldStartingIndex];
                    }
                    break;
                case NotifyCollectionChangedAction.Reset:
                    TopItems.Clear();
                    while (TopItems.Count < Items.Count && TopItems.Count < 12)
                    {
                        TopItems.Add(Items[TopItems.Count]);
                    }
                    break;
            }
        }

        private ObservableCollection<SampleDataItem> _items = new ObservableCollection<SampleDataItem>();
        public ObservableCollection<SampleDataItem> Items
        {
            get { return this._items; }
        }

        private ObservableCollection<SampleDataItem> _topItem = new ObservableCollection<SampleDataItem>();
        public ObservableCollection<SampleDataItem> TopItems
        {
            get { return this._topItem; }
        }
    }

    /// <summary>
    /// Creates a collection of groups and items with hard-coded content.
    /// 
    /// SampleDataSource initializes with placeholder data rather than live production
    /// data so that sample data is provided at both design-time and run-time.
    /// </summary>
    public sealed class SampleDataSource
    {
        private static SampleDataSource _sampleDataSource = new SampleDataSource();


        private ObservableCollection<SampleDataGroup> _allGroups = new ObservableCollection<SampleDataGroup>();
        public ObservableCollection<SampleDataGroup> AllGroups
        {
            get { return this._allGroups; }
        }

        public static IEnumerable<SampleDataGroup> GetGroups(string uniqueId)
        {
            if (!uniqueId.Equals("AllGroups")) throw new ArgumentException("Only 'AllGroups' is supported as a collection of groups");
            //RefreshDataSource();
            return _sampleDataSource.AllGroups;
        }

        public static SampleDataGroup GetGroup(string uniqueId)
        {
            // Simple linear search is acceptable for small data sets
            var matches = _sampleDataSource.AllGroups.Where((group) => group.UniqueId.Equals(uniqueId));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        public static SampleDataItem GetItem(string uniqueId)
        {
            // Simple linear search is acceptable for small data sets
            var matches = _sampleDataSource.AllGroups.SelectMany(group => group.Items).Where((item) => item.UniqueId.Equals(uniqueId));
            if (matches.Count() == 1) return matches.First();
            return null;
        }

        public SampleDataSource() 
        {
           // RefreshDataSource();
        }


        public static void RefreshDataSource()
        {

            IJsonUtils iju = new JsonUtils();
            EventbusMessage ebm = iju.convertfromJson(getJsonString());
            List<String> groups = new List<String>();
            List<SampleDataGroup> sampleDataGroups = new List<SampleDataGroup>();
            /*groups.Add("SENSOR");
            groups.Add("ACTUATOR");
            foreach (var group in groups)
            {
                var sampleDataGroup = new SampleDataGroup(
                    group,
                    group,
                    group,
                    "Assets/LightGray.png",
                    group);

                _sampleDataSource.AllGroups.Add(sampleDataGroup);

                foreach (var Device in ebm.Body.Devices)
                {
                    String cat = Device.Category;
                    switch (cat)
                    {
                        case "SENSOR":
                            if (Device.Metavalues.CONFIGURATION != null)
                            {
                                sampleDataGroup.Items.Add(new SampleDataItem(
                                    Convert.ToString(Device.Id),
                                    Device.Metavalues.CONFIGURATION.Value,
                                    Device.Metavalues.CONFIGURATION.Value,
                                    "Assets/LightGray.png",
                                    "DESCRIPTION",
                                    "CONTENT",
                                    sampleDataGroup));
                                break;
                            }
                                break;

                           
                            
                        case "ACTUATOR":
                                if (Device.Metavalues.CONFIGURATION != null)
                                {
                                    sampleDataGroup.Items.Add(new SampleDataItem(
                                        Convert.ToString(Device.Id),
                                        Device.Metavalues.CONFIGURATION.Value,
                                        Device.Metavalues.CONFIGURATION.Value,
                                        "Assets/LightGray.png",
                                        "DESCRIPTION",
                                        "CONTENT",
                                        sampleDataGroup));
                                    break;
                                }
                                break;
                    }
                }

            }*/

            foreach (var Device in ebm.Body.Devices)
            {
                
                if (Device.Category.Equals("SENSOR"))
                {
                    if (!groups.Contains("SENSOR"))
                    {
                        groups.Add(Device.Category);
                        var sampleDataGroup = new SampleDataGroup(
                        Device.Category,
                        Device.Category,
                        Device.Category,
                        "Assets/LightGray.png",
                        "DESCRIPTION");
                        _sampleDataSource._allGroups.Add(sampleDataGroup);
                        sampleDataGroups.Add(sampleDataGroup);

                    }
                }
                else
                {
                    if (!groups.Contains("ACTUATOR"))
                    {
                        groups.Add(Device.Category);
                        var sampleDataGroup = new SampleDataGroup(
                        Device.Category,
                        Device.Category,
                        Device.Category,
                        "Assets/LightGray.png",
                        "DESCRIPTION");
                        _sampleDataSource._allGroups.Add(sampleDataGroup);
                        sampleDataGroups.Add(sampleDataGroup);
                    }

                }
            }

            foreach (var Device in ebm.Body.Devices)
            {
                if (Device.Category.Equals("SENSOR"))
                {
                    if (Device.Metavalues.CONFIGURATION != null)
                    {
                        SampleDataGroup sampleDataGroup = sampleDataGroups[0];
                        sampleDataGroup.Items.Add(new SampleDataItem(
                            Convert.ToString(Device.Id),
                            Device.Metavalues.CONFIGURATION.Value,
                            Device.Metavalues.CONFIGURATION.Value,
                            "Assets/LightGray.png",
                            "DESCRIPTION",
                            "CONTENT",
                            sampleDataGroup));
                    }
                }
                else if(Device.Category.Equals("ACTUATOR"))
                {
                    if (Device.Metavalues.CONFIGURATION != null)
                    {
                        sampleDataGroups[1].Items.Add(new SampleDataItem(
                            Convert.ToString(Device.Id),
                            Device.Metavalues.CONFIGURATION.Value,
                            Device.Metavalues.CONFIGURATION.Value,
                            "Assets/LightGray.png",
                            "DESCRIPTION",
                            "CONTENT",
                            sampleDataGroups[1]));
                    }
                }

                
            }
            
           
        }
        

        private SampleDataGroup AddToGroup(Device device)
        {
            SampleDataGroup sampleDataGroup = new SampleDataGroup(
                        device.Category,
                        device.Category,
                        device.Category,
                        "Assets/LightGray.png",
                        "DESCRIPTION");
            _sampleDataSource.AllGroups.Add(sampleDataGroup);

            return sampleDataGroup;
        }

        public static String getJsonString()
        {
            String jsonString = "{\"address\":\"demoClient\",\"mode\":\"send\",\"bodyType\":\"at.ac.ait.hbs.homer.core.common.flat.Flat\",\"senderId\":\"HOME_CONTROL_SERVICE\",\"body\":{\"id\":1,\"devices\":[{\"id\":1,\"type\":11,\"category\":\"SENSOR\",\"roomId\":1,\"coordinate\":{\"index\":0,\"x\":1622.0,\"y\":825.0},\"areaCoordinates\":[],\"metavalues\":{\"HARDWARE_ID\":{\"key\":\"HARDWARE_ID\",\"type\":\"NUMERIC\",\"value\":\"23\"},\"CONFIGURATION\":{\"key\":\"CONFIGURATION\",\"type\":\"STRING\",\"value\":\"Microwave \"},\"MANUFACTURER\":{\"key\":\"MANUFACTURER\",\"type\":\"STRING\",\"value\":\"EATON\"},\"GATEWAY\":{\"key\":\"GATEWAY\",\"type\":\"NUMERIC\",\"value\":\"1\"}}},{\"id\":4,\"type\":10,\"category\":\"SENSOR\",\"roomId\":1,\"coordinate\":{\"index\":0,\"x\":1636.0,\"y\":950.0},\"areaCoordinates\":[],\"metavalues\":{\"HARDWARE_ID\":{\"key\":\"HARDWARE_ID\",\"type\":\"NUMERIC\",\"value\":\"7\"},\"CONFIGURATION\":{\"key\":\"CONFIGURATION\",\"type\":\"STRING\",\"value\":\"Cups cupboard \"},\"MANUFACTURER\":{\"key\":\"MANUFACTURER\",\"type\":\"STRING\",\"value\":\"EATON\"},\"GATEWAY\":{\"key\":\"GATEWAY\",\"type\":\"NUMERIC\",\"value\":\"1\"}}},{\"id\":5,\"type\":0,\"category\":\"SENSOR\",\"roomId\":1,\"coordinate\":{\"index\":0,\"x\":1323.0,\"y\":827.0},\"areaCoordinates\":[],\"metavalues\":{\"HARDWARE_ID\":{\"key\":\"HARDWARE_ID\",\"type\":\"NUMERIC\",\"value\":\"8\"},\"CONFIGURATION\":{\"key\":\"CONFIGURATION\",\"type\":\"STRING\",\"value\":\"Fridge \"},\"MANUFACTURER\":{\"key\":\"MANUFACTURER\",\"type\":\"STRING\",\"value\":\"EATON\"},\"GATEWAY\":{\"key\":\"GATEWAY\",\"type\":\"NUMERIC\",\"value\":\"1\"}}},{\"id\":6,\"type\":0,\"category\":\"SENSOR\",\"roomId\":1,\"coordinate\":{\"index\":0,\"x\":1470.0,\"y\":950.0},\"areaCoordinates\":[],\"metavalues\":{\"HARDWARE_ID\":{\"key\":\"HARDWARE_ID\",\"type\":\"NUMERIC\",\"value\":\"20\"},\"CONFIGURATION\":{\"key\":\"CONFIGURATION\",\"type\":\"STRING\",\"value\":\"Plates cupboard \"},\"MANUFACTURER\":{\"key\":\"MANUFACTURER\",\"type\":\"STRING\",\"value\":\"EATON\"},\"GATEWAY\":{\"key\":\"GATEWAY\",\"type\":\"NUMERIC\",\"value\":\"1\"}}},{\"id\":8,\"type\":11,\"category\":\"SENSOR\",\"roomId\":1,\"coordinate\":{\"index\":0,\"x\":1260.0,\"y\":825.0},\"areaCoordinates\":[],\"metavalues\":{\"HARDWARE_ID\":{\"key\":\"HARDWARE_ID\",\"type\":\"NUMERIC\",\"value\":\"1\"},\"CONFIGURATION\":{\"key\":\"CONFIGURATION\",\"type\":\"STRING\",\"value\":\"dishwasher 1\"},\"MANUFACTURER\":{\"key\":\"MANUFACTURER\",\"type\":\"STRING\",\"value\":\"EATON\"},\"GATEWAY\":{\"key\":\"GATEWAY\",\"type\":\"NUMERIC\",\"value\":\"1\"}}},{\"id\":10,\"type\":11,\"category\":\"SENSOR\",\"roomId\":1,\"coordinate\":{\"index\":0,\"x\":1561.0,\"y\":825.0},\"areaCoordinates\":[],\"metavalues\":{\"HARDWARE_ID\":{\"key\":\"HARDWARE_ID\",\"type\":\"NUMERIC\",\"value\":\"12\"},\"CONFIGURATION\":{\"key\":\"CONFIGURATION\",\"type\":\"STRING\",\"value\":\"Freezer 1\"},\"MANUFACTURER\":{\"key\":\"MANUFACTURER\",\"type\":\"STRING\",\"value\":\"EATON\"},\"GATEWAY\":{\"key\":\"GATEWAY\",\"type\":\"NUMERIC\",\"value\":\"1\"}}},{\"id\":11,\"type\":10,\"category\":\"SENSOR\",\"roomId\":1,\"coordinate\":{\"index\":0,\"x\":1335.0,\"y\":951.0},\"areaCoordinates\":[],\"metavalues\":{\"HARDWARE_ID\":{\"key\":\"HARDWARE_ID\",\"type\":\"NUMERIC\",\"value\":\"5\"},\"CONFIGURATION\":{\"key\":\"CONFIGURATION\",\"type\":\"STRING\",\"value\":\"Pans cupboard 1\"},\"MANUFACTURER\":{\"key\":\"MANUFACTURER\",\"type\":\"STRING\",\"value\":\"EATON\"},\"GATEWAY\":{\"key\":\"GATEWAY\",\"type\":\"NUMERIC\",\"value\":\"1\"}}},{\"id\":12,\"type\":11,\"category\":\"SENSOR\",\"roomId\":1,\"coordinate\":{\"index\":0,\"x\":1474.0,\"y\":823.0},\"areaCoordinates\":[],\"metavalues\":{\"HARDWARE_ID\":{\"key\":\"HARDWARE_ID\",\"type\":\"NUMERIC\",\"value\":\"14\"},\"CONFIGURATION\":{\"key\":\"CONFIGURATION\",\"type\":\"STRING\",\"value\":\"Washingmachine 2\"},\"MANUFACTURER\":{\"key\":\"MANUFACTURER\",\"type\":\"STRING\",\"value\":\"EATON\"},\"GATEWAY\":{\"key\":\"GATEWAY\",\"type\":\"NUMERIC\",\"value\":\"1\"}}},{\"id\":13,\"type\":10,\"category\":\"SENSOR\",\"roomId\":1,\"coordinate\":{\"index\":0,\"x\":1228.0,\"y\":953.0},\"areaCoordinates\":[],\"metavalues\":{\"HARDWARE_ID\":{\"key\":\"HARDWARE_ID\",\"type\":\"NUMERIC\",\"value\":\"6\"},\"CONFIGURATION\":{\"key\":\"CONFIGURATION\",\"type\":\"STRING\",\"value\":\"groceries cupboard 2\"},\"MANUFACTURER\":{\"key\":\"MANUFACTURER\",\"type\":\"STRING\",\"value\":\"EATON\"},\"GATEWAY\":{\"key\":\"GATEWAY\",\"type\":\"NUMERIC\",\"value\":\"1\"}}},{\"id\":1,\"type\":1001,\"category\":\"ACTUATOR\",\"roomId\":1,\"coordinate\":{\"index\":0,\"x\":1392.0,\"y\":888.0},\"areaCoordinates\":[],\"metavalues\":{\"HARDWARE_ID\":{\"key\":\"HARDWARE_ID\",\"type\":\"NUMERIC\",\"value\":\"-1\"},\"CONFIGURATION\":{\"key\":\"CONFIGURATION\",\"type\":\"STRING\",\"value\":\"test123\"},\"MANUFACTURER\":{\"key\":\"MANUFACTURER\",\"type\":\"STRING\",\"value\":\"KNX\"}}},{\"id\":2,\"type\":1001,\"category\":\"ACTUATOR\",\"roomId\":1,\"coordinate\":{\"index\":0,\"x\":1142.0,\"y\":906.0},\"areaCoordinates\":[],\"metavalues\":{\"MANUFACTURER\":{\"key\":\"MANUFACTURER\",\"type\":\"STRING\",\"value\":\"ARC\"}}},{\"id\":15,\"type\":10,\"category\":\"SENSOR\",\"roomId\":3,\"coordinate\":{\"index\":0,\"x\":1516.0,\"y\":648.0},\"areaCoordinates\":[],\"metavalues\":{\"HARDWARE_ID\":{\"key\":\"HARDWARE_ID\",\"type\":\"NUMERIC\",\"value\":\"3464\"},\"MANUFACTURER\":{\"key\":\"MANUFACTURER\",\"type\":\"STRING\",\"value\":\"EATON\"},\"GATEWAY\":{\"key\":\"GATEWAY\",\"type\":\"NUMERIC\",\"value\":\"1\"}}},{\"id\":2,\"type\":10,\"category\":\"SENSOR\",\"roomId\":5,\"coordinate\":{\"index\":0,\"x\":940.0,\"y\":326.0},\"areaCoordinates\":[],\"metavalues\":{\"HARDWARE_ID\":{\"key\":\"HARDWARE_ID\",\"type\":\"NUMERIC\",\"value\":\"18\"},\"CONFIGURATION\":{\"key\":\"CONFIGURATION\",\"type\":\"STRING\",\"value\":\"Hall-Toilet door 5\"},\"MANUFACTURER\":{\"key\":\"MANUFACTURER\",\"type\":\"STRING\",\"value\":\"EATON\"},\"GATEWAY\":{\"key\":\"GATEWAY\",\"type\":\"NUMERIC\",\"value\":\"1\"}}},{\"id\":3,\"type\":0,\"category\":\"SENSOR\",\"roomId\":5,\"coordinate\":{\"index\":0,\"x\":942.0,\"y\":500.0},\"areaCoordinates\":[],\"metavalues\":{\"HARDWARE_ID\":{\"key\":\"HARDWARE_ID\",\"type\":\"NUMERIC\",\"value\":\"9\"},\"CONFIGURATION\":{\"key\":\"CONFIGURATION\",\"type\":\"STRING\",\"value\":\"Hall-Bathroom door \"},\"MANUFACTURER\":{\"key\":\"MANUFACTURER\",\"type\":\"STRING\",\"value\":\"EATON\"},\"GATEWAY\":{\"key\":\"GATEWAY\",\"type\":\"NUMERIC\",\"value\":\"1\"}}},{\"id\":7,\"type\":10,\"category\":\"SENSOR\",\"roomId\":5,\"coordinate\":{\"index\":0,\"x\":1102.0,\"y\":111.0},\"areaCoordinates\":[],\"metavalues\":{\"HARDWARE_ID\":{\"key\":\"HARDWARE_ID\",\"type\":\"NUMERIC\",\"value\":\"17\"},\"CONFIGURATION\":{\"key\":\"CONFIGURATION\",\"type\":\"STRING\",\"value\":\"frontdoor 1\"},\"MANUFACTURER\":{\"key\":\"MANUFACTURER\",\"type\":\"STRING\",\"value\":\"EATON\"},\"GATEWAY\":{\"key\":\"GATEWAY\",\"type\":\"NUMERIC\",\"value\":\"1\"}}},{\"id\":14,\"type\":10,\"category\":\"SENSOR\",\"roomId\":5,\"coordinate\":{\"index\":0,\"x\":1104.0,\"y\":434.0},\"areaCoordinates\":[],\"metavalues\":{\"HARDWARE_ID\":{\"key\":\"HARDWARE_ID\",\"type\":\"NUMERIC\",\"value\":\"13\"},\"CONFIGURATION\":{\"key\":\"CONFIGURATION\",\"type\":\"STRING\",\"value\":\"Hall-Bedroom door 2\"},\"MANUFACTURER\":{\"key\":\"MANUFACTURER\",\"type\":\"STRING\",\"value\":\"EATON\"},\"GATEWAY\":{\"key\":\"GATEWAY\",\"type\":\"NUMERIC\",\"value\":\"1\"}}},{\"id\":9,\"type\":11,\"category\":\"SENSOR\",\"roomId\":7,\"coordinate\":{\"index\":0,\"x\":753.0,\"y\":304.0},\"areaCoordinates\":[],\"metavalues\":{\"HARDWARE_ID\":{\"key\":\"HARDWARE_ID\",\"type\":\"NUMERIC\",\"value\":\"24\"},\"CONFIGURATION\":{\"key\":\"CONFIGURATION\",\"type\":\"STRING\",\"value\":\"ToiletFlush 1\"},\"MANUFACTURER\":{\"key\":\"MANUFACTURER\",\"type\":\"STRING\",\"value\":\"EATON\"},\"GATEWAY\":{\"key\":\"GATEWAY\",\"type\":\"NUMERIC\",\"value\":\"1\"}}}],\"rooms\":[{\"id\":1,\"type\":\"MDC_AI_LOCATION_KITCHEN\",\"coordinates\":[{\"index\":1,\"x\":1108.0,\"y\":982.0},{\"index\":2,\"x\":1108.0,\"y\":802.0},{\"index\":3,\"x\":1677.0,\"y\":802.0},{\"index\":4,\"x\":1677.0,\"y\":982.0}],\"metavalues\":{\"DESCRIPTION\":{\"key\":\"DESCRIPTION\",\"type\":\"STRING\",\"value\":\"Kitchen\"}}},{\"id\":3,\"type\":\"MDC_AI_LOCATION_BEDROOM\",\"coordinates\":[{\"index\":1,\"x\":1109.0,\"y\":802.0},{\"index\":2,\"x\":1677.0,\"y\":802.0},{\"index\":3,\"x\":1677.0,\"y\":397.0},{\"index\":4,\"x\":1112.0,\"y\":397.0}],\"metavalues\":{\"DESCRIPTION\":{\"key\":\"DESCRIPTION\",\"type\":\"STRING\",\"value\":\"Sleeping room\"}}},{\"id\":4,\"type\":\"MDC_AI_LOCATION_LIVINGROOM\",\"coordinates\":[{\"index\":1,\"x\":1112.0,\"y\":982.0},{\"index\":2,\"x\":500.0,\"y\":982.0},{\"index\":3,\"x\":500.0,\"y\":253.0},{\"index\":4,\"x\":738.0,\"y\":253.0},{\"index\":5,\"x\":738.0,\"y\":545.0},{\"index\":6,\"x\":1112.0,\"y\":545.0}],\"metavalues\":{\"DESCRIPTION\":{\"key\":\"DESCRIPTION\",\"type\":\"STRING\",\"value\":\"Living room\"}}},{\"id\":5,\"type\":\"MDC_AI_LOCATION_HALL\",\"coordinates\":[{\"index\":1,\"x\":933.0,\"y\":545.0},{\"index\":2,\"x\":933.0,\"y\":17.0},{\"index\":3,\"x\":1112.0,\"y\":17.0},{\"index\":4,\"x\":1112.0,\"y\":545.0}],\"metavalues\":{\"DESCRIPTION\":{\"key\":\"DESCRIPTION\",\"type\":\"STRING\",\"value\":\"Hall\"}}},{\"id\":6,\"type\":\"MDC_AI_LOCATION_SHOWERROOM\",\"coordinates\":[{\"index\":1,\"x\":738.0,\"y\":545.0},{\"index\":2,\"x\":738.0,\"y\":357.0},{\"index\":3,\"x\":933.0,\"y\":357.0},{\"index\":4,\"x\":933.0,\"y\":545.0}],\"metavalues\":{\"DESCRIPTION\":{\"key\":\"DESCRIPTION\",\"type\":\"STRING\",\"value\":\"Bathroom\"}}},{\"id\":7,\"type\":\"MDC_AI_LOCATION_TOILET\",\"coordinates\":[{\"index\":1,\"x\":738.0,\"y\":357.0},{\"index\":2,\"x\":738.0,\"y\":253.0},{\"index\":3,\"x\":933.0,\"y\":253.0},{\"index\":4,\"x\":933.0,\"y\":357.0}],\"metavalues\":{\"DESCRIPTION\":{\"key\":\"DESCRIPTION\",\"type\":\"STRING\",\"value\":\"Toilet\"}}},{\"id\":8,\"type\":\"MDC_AI_LOCATION_STUDY\",\"coordinates\":[{\"index\":1,\"x\":585.0,\"y\":253.0},{\"index\":2,\"x\":585.0,\"y\":-30.0},{\"index\":3,\"x\":933.0,\"y\":-30.0},{\"index\":4,\"x\":933.0,\"y\":253.0}],\"metavalues\":{\"DESCRIPTION\":{\"key\":\"DESCRIPTION\",\"type\":\"STRING\",\"value\":\"Student room\"}}}],\"doors\":[{\"id\":2,\"coordinates\":[{\"index\":1,\"x\":1112.0,\"y\":506.0},{\"index\":2,\"x\":1112.0,\"y\":425.0}],\"rooms\":[{\"id\":3},{\"id\":5}]},{\"id\":4,\"coordinates\":[{\"index\":1,\"x\":933.0,\"y\":493.0},{\"index\":2,\"x\":933.0,\"y\":408.0}],\"rooms\":[{\"id\":5},{\"id\":6}]},{\"id\":3,\"coordinates\":[{\"index\":1,\"x\":973.0,\"y\":545.0},{\"index\":2,\"x\":1070.0,\"y\":545.0}],\"rooms\":[{\"id\":4},{\"id\":5}]},{\"id\":5,\"coordinates\":[{\"index\":1,\"x\":933.0,\"y\":332.0},{\"index\":2,\"x\":933.0,\"y\":269.0}],\"rooms\":[{\"id\":5},{\"id\":7}]},{\"id\":1,\"coordinates\":[{\"index\":1,\"x\":1112.0,\"y\":943.0},{\"index\":2,\"x\":1112.0,\"y\":850.0}],\"rooms\":[{\"id\":1}]},{\"id\":6,\"coordinates\":[{\"index\":1,\"x\":933.0,\"y\":155.0},{\"index\":2,\"x\":933.0,\"y\":65.0}],\"rooms\":[{\"id\":5},{\"id\":8}]}],\"metavalues\":{\"DESCRIPTION\":{\"key\":\"DESCRIPTION\",\"type\":\"STRING\",\"value\":\"Demo Flat\"},\"ADDRESS\":{\"key\":\"ADDRESS\",\"type\":\"STRING\"},\"GATEWAYS\":{\"key\":\"GATEWAYS\",\"type\":\"JSON\",\"value\":\"[{\\\"gatewayId\\\":1,\\\"serialNr\\\":1234567,\\\"description\\\":\\\"dummy gateway\\\"}]\"}}}}";
            return jsonString;
        }
    }
}
