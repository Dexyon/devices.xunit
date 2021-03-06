using System.Collections.Generic;
using Windows.ApplicationModel;

namespace System.IO
{
    static class Directory
    {
        public static bool Exists(string path)
        {
            if (Package.Current.InstalledLocation.Path.Contains(path))
                return true;

            return false;
        }

        public static string[] GetFiles(string path, string searchOption)
        {
            var list = new List<string>();
            var extension = Path.GetExtension(searchOption);
            var filesAsync = Package.Current.InstalledLocation.GetFilesAsync().AsTask().GetAwaiter().GetResult();

            foreach (var file in filesAsync)
                if (string.Equals(Path.GetExtension(file.Path), extension, StringComparison.OrdinalIgnoreCase))
                    list.Add(file.Path);

            return list.ToArray();
        }
    }
}