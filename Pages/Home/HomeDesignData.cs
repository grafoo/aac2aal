using aac2aal_UI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aac2aal_UI.Pages.Home
{
    public class HomeDesignData : HomeViewModel
    {
        public HomeDesignData()
        {
            this.Groups = DesignDataSource.CreateGroups();
        }
    }
}
