#region Apache Notice
/*****************************************************************************
 * $Revision: 387044 $
 * $LastChangedDate: 2008-10-11 10:07:44 -0600 (Sat, 11 Oct 2008) $
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

using System.Collections.Generic;
using Apache.Ibatis.Common.Configuration;
using Apache.Ibatis.Common.Exceptions;
using CommonExceptions = Apache.Ibatis.Common.Exceptions;

namespace Apache.Ibatis.Common.Data
{
    /// <summary>
    /// Create DbProviders based on configuration information from resource
    /// providers.config
    /// </summary>
    public class DbProviderFactory
    {
        /// <summary>
        /// Default provider name
        /// </summary>
        private const string DEFAULT_PROVIDER_NAME = "_DEFAULT_PROVIDER_NAME";

        private readonly IDictionary<string, IDbProvider> repository = new Dictionary<string, IDbProvider>();
        
        /// <summary>
        /// Initializes a new instance of the <see cref="DbProviderFactory"/> class.
        /// </summary>
        /// <param name="providers">The providers.</param>
        public DbProviderFactory(IConfiguration[] providers)
        {
            foreach (IConfiguration config in providers)
            {
                IDbProvider provider = ProviderDeSerializer.Deserialize(config);

                if (provider.IsEnabled)
                {
                    //_configScope.ErrorContext.ObjectId = provider.Name;
                    //_configScope.ErrorContext.MoreInfo = "initialize provider";

                    provider.Initialize();
                    repository.Add(provider.Id, provider);

                    if (provider.IsDefault)
                    {
                        if (!repository.ContainsKey(DEFAULT_PROVIDER_NAME))
                        {
                            repository.Add(DEFAULT_PROVIDER_NAME, provider);
                        }
                        else
                        {
                            throw new ConfigurationException(
                                string.Format("Error while configuring the Provider named \"{0}\" There can be only one default Provider.", provider.Id));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets the IDbProvider given an identifying name.
        /// </summary>
        /// <remarks>
        /// Familiar names for the .NET 2.0 provider model are supported, i.e.
        /// System.Data.SqlClient.  Refer to the documentation for a complete
        /// listing of supported DbProviders and their names.  
        /// </remarks>
        /// <param name="providerInvariantName">Name of the provider invariant.</param>
        /// <returns>An IDbProvider</returns>
        public IDbProvider GetDbProvider(string providerInvariantName)
        {
            if (repository.ContainsKey(providerInvariantName))
            {
                return repository[providerInvariantName];
            }
            throw new ConfigurationException("There's no provider with the name '" + providerInvariantName + "'. Cause you give a wrong name or the provider is disabled in the providers.config file.");
        }
    }
}
