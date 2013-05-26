using aac2aal_UI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aac2aal_UI.Pages.GroupDetail
{
    public class GroupDetailDesignData : GroupDetailViewModel
    {
        public GroupDetailDesignData()
        {
            var group = DesignDataSource.CreateGroup(7);
            this.Group = group;
            this.Items = group.Items;
        }
    }
}
