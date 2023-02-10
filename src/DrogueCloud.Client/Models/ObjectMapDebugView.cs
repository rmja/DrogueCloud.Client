using System.Diagnostics;
using System.Reflection;
using System.Text.Json;

namespace DrogueCloud.Client.Models;

internal class ObjectMapDebugView<T> where T : Dictionary<string, JsonElement>
{
    private readonly T _map;

    public ObjectMapDebugView(T map)
    {
        _map = map;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
    public KeyValuePair<string, object?>[] Entries
    {
        get
        {
            var properties = _map.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.DeclaredOnly);
            var entries = new KeyValuePair<string, object?>[properties.Length + _map.Count];

            var i = 0;
            foreach (var property in properties)
            {
                entries[i++] = new(property.Name, property.GetValue(_map));
            }

            foreach (var (key, value) in _map)
            {
                entries[i++] = new(key, value);
            }

            return entries;
        }
    }
}
