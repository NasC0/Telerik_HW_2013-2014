/* Task 11. Create a [Version] attribute that can be applied to structures, classes, interfaces, enumerations and methods 
 * and holds a version in the format major.minor (e.g. 2.11). 
 * Apply the version attribute to a sample class and display its version at runtime. */

namespace VersionAttribute
{
    using System;

    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Method | AttributeTargets.Interface | AttributeTargets.Class | AttributeTargets.Enum, AllowMultiple = false)]
    public class VersionAttribute : Attribute
    {
        public int Major { get; private set; }
        public int Minor { get; private set; }
        public string Version { get; private set; }

        public VersionAttribute(int major, int minor)
        {
            this.Major = major;
            this.Minor = minor;
            this.Version = String.Format("{0}.{1}", this.Major, this.Minor);
        }

    }
}
