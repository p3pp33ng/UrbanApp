using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanApp
{

    public class UrbanNavigationPageMenuItem
    {
        public UrbanNavigationPageMenuItem()
        {
            TargetType = typeof(UrbanNavigationPageDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}