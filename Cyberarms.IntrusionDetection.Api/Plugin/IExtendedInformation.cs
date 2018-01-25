using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Cyberarms.IntrusionDetection.Api.Plugin {
    public interface IExtendedInformation {
        string DisplayName { get; set; }
        Image Icon { get; set; }
        Image SelectedIcon { get; set; }
        Image UnselectedIcon { get; set; }
        Guid Id { get; }
    }
}
