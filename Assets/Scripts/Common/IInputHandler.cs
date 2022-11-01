using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Footkin.Common
{
    interface IInputHandler
    {
        public void BindInput();

        public void UnBindInput();
    }
}
