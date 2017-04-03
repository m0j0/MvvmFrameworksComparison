using System.Collections.Generic;

namespace Caliburn.Managers
{
    public interface IWindowManagerPortable
    {
        bool? ShowDialog(object rootModel, object context = null, IDictionary<string, object> settings = null);
    }
}