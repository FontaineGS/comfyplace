using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viewer.ViewModel
{
    public class MainformViewModel
    {
        private WorldViewModel _model = new WorldViewModel();

        public MainformViewModel()
        {
            _model.InitComponent();
        }
    }
}
