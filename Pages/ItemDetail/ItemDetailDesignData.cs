using aac2aal_UI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aac2aal_UI.Pages.ItemDetail
{
    public class ItemDetailDesignData : ItemDetailViewModel
    {
        public ItemDetailDesignData()
        {
            var group = DesignDataSource.CreateGroup(7);
            this.Group = group;
            this.Items = group.Items;
        }
    }
}
