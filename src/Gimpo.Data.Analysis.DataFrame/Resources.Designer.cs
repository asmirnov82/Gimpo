﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gimpo.Data.Analysis {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Gimpo.Data.Analysis.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Column with the name &apos;{0}&apos; is already attached to a parent dataframe..
        /// </summary>
        internal static string ColumnIsNotDetached {
            get {
                return ResourceManager.GetString("ColumnIsNotDetached", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Column with the name &apos;{0}&apos; has already been added..
        /// </summary>
        internal static string DuplicateColumnName {
            get {
                return ResourceManager.GetString("DuplicateColumnName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Column with the name &apos;{0}&apos; does not exist..
        /// </summary>
        internal static string InvalidColumnName {
            get {
                return ResourceManager.GetString("InvalidColumnName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Column with the name &apos;{0}&apos; has incorrect length..
        /// </summary>
        internal static string MismatchedColumnLengths {
            get {
                return ResourceManager.GetString("MismatchedColumnLengths", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed on attempt to add a row to the DataFrame (row has different amount of columns)..
        /// </summary>
        internal static string WrongNumberOfColumns {
            get {
                return ResourceManager.GetString("WrongNumberOfColumns", resourceCulture);
            }
        }
    }
}