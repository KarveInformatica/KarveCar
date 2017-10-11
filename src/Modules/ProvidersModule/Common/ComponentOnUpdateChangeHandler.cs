﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KarveCommon.Services;

namespace ProvidersModule.Common
{
    // This class notify the toolbar each time a component is changed in case of insert.
    class ComponentOnUpdateChange: IUiComponentChangeHandler
    {
        public void OnComponentChange(IDictionary<string, string> dictionary, IEventManager eventManager)
        {
            throw new NotImplementedException();
        }
    }
}