using System;
using System.Reflection;
using System.Security;
//
// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
//
[assembly: CLSCompliant(true)]
[assembly: AllowPartiallyTrustedCallers]
[assembly: AssemblyCompany("http://ibatis.apache.org/")]
[assembly: AssemblyProduct("iBATIS.NET")]
[assembly: AssemblyCopyright("Copyright 2009,2005 The Apache Software Foundation")]
[assembly: AssemblyTrademark("Licensed under the Apache License, Version 2.0")]
[assembly: AssemblyCulture("")]

#if DEBUG
#else
    [assembly: AssemblyConfiguration("net-2.0.win32; Release")]
    [assembly: AssemblyDelaySign(false)]
    [assembly: AssemblyKeyFile("..\\..\\..\\AssemblyKey.snk")]
#endif

[assembly: AssemblyTitle("Apache.Ibatis.Common")]
[assembly: AssemblyDescription("Common object used by DataMapper component in iBATIS")]
	
[assembly: AssemblyVersion("3.0.0")]

