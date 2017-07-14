
#region Apache Notice
/*****************************************************************************
 * $Revision: 408099 $
 * $LastChangedDate: 2008-06-28 09:50:38 -0600 (Sat, 28 Jun 2008) $
 * $LastChangedBy: gbayon $
 * 
 * iBATIS.NET Data Mapper
 * Copyright (C) 2008/2005 - The Apache Software Foundation
 *  
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *      http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * 
 ********************************************************************************/
#endregion

using Apache.Ibatis.Common.Contracts;

namespace Apache.Ibatis.DataMapper.Configuration.Module
{
    /// <summary>
    /// Base class for code configuration modules. 
    /// </summary>
    public abstract class Module : ModuleBuilder, IModule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Module"/> class.
        /// </summary>
        public Module()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Module"/> class.
        /// </summary>
        /// <param name="nameSpace">The name space.</param>
        public Module(string nameSpace)
            : base(nameSpace)
        {
        }

        /// <summary>
        /// Apply the module to the container.
        /// </summary>
        /// <param name="engine">The engine.</param>
        public void Configure(IConfigurationEngine engine)
        {
            Contract.Require.That(engine, Is.Not.Null).When("retrieving argument engine in Configure method");

            Load();
            Build(engine.ConfigurationStore);
        }

        /// <summary>
        /// Override to add code configuration mapping to the <see cref="IConfigurationEngine"/>.
        /// </summary>
        public abstract void Load();
    }
}
