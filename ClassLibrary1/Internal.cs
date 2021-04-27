using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace WinRT
{
    internal class DefaultComWrappers
    { 
        internal static int defaulto { get; }
       
        static DefaultComWrappers()
        {
            defaulto = 38;
        }
    }

    internal static partial class ComWrappersSupport
    {
        // Instance field and property for Singleton pattern: ComWrappers `set` method should be idempotent 
        private static DefaultComWrappers _instance;
        private static DefaultComWrappers DefaultComWrappersInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DefaultComWrappers();
                }
                return _instance;
            }
        }

        private static object _comWrappersLock = new object();
        private static ComWrappers _comWrappers;

        public static ComWrappers ComWrappers
        {
            get
            {
                if (_comWrappers is null)
                {
                    lock (_comWrappersLock)
                    {
                        if (_comWrappers is null)
                        {
                             var comWrappersToSet = DefaultComWrappersInstance;
                             /* add these back when we have fully transformed sources 
                              
                                ComWrappers.RegisterForTrackerSupport(comWrappersToSet);
                              */ 
                            //_comWrappers = comWrappersToSet;
                        }
                    }
                }
                return _comWrappers;
            }
            set
            {
                lock (_comWrappersLock)
                {
                    if (value == null /*&& _comWrappers == DefaultComWrappersInstance*/)
                    {
                        return;
                    }
                    var comWrappersToSet = value /*?? DefaultComWrappersInstance*/;
                    // ComWrappers.RegisterForTrackerSupport(comWrappersToSet);
                    // _comWrappers = comWrappersToSet;
                }
            }
        }
    }
    
}
