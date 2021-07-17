using System;
using System.Collections.Generic;
using System.Text;

namespace App_RecepcaoVeiculo_Tracker.Menu
{
    public class MasterPageItem
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public Type TargetType { get; set; }
    }

    public class MasterPageActionItem
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Code { get; set; }
    }
}
