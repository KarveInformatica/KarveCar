using System;
using System.Reflection;
using System.Reflection.Emit;

namespace MultiEventCommandBinder
{
    /// <summary>
    /// Generates delegates according to the specified signature on runtime
    /// </summary>
    public static class EventHandlerGenerator
    {
        /// <summary>
        /// Generates a delegate with a matching signature of the supplied eventHandlerType
        /// This method only supports Events that have a delegate of type void
        /// </summary>

        public static Delegate CreateDelegate(Type eventHandlerType, MethodInfo methodToInvoke, object methodInvoker,
                                              string eventName)
        {
            //Get the eventHandlerType signature
            MethodInfo eventHandlerInfo = eventHandlerType.GetMethod("Invoke");

            if (eventHandlerInfo.ReturnParameter != null)
            {
                Type returnType = eventHandlerInfo.ReturnParameter.ParameterType;
                if (returnType != typeof(void))
                    throw new ApplicationException(
                        "Delegate has a return type. This only supprts event handlers that are void");
            }

            ParameterInfo[] delegateParameters = eventHandlerInfo.GetParameters();
            //Get the list of type of parameters. Please know that we do + 1 because we have to push the object where the method resides i.e methodInvoker parameter
            var hookupParameters = new Type[delegateParameters.Length + 1];
            hookupParameters[0] = methodInvoker.GetType();
            for (int i = 0; i < delegateParameters.Length; i++)
                hookupParameters[i + 1] = delegateParameters[i].ParameterType;

            var handler = new DynamicMethod("", null,
                                            hookupParameters, typeof(EventHandlerGenerator));

            ILGenerator eventIl = handler.GetILGenerator();

            //load the parameters or everything will just BAM :)
            LocalBuilder local = eventIl.DeclareLocal(typeof(object[]));
            eventIl.Emit(OpCodes.Ldc_I4, delegateParameters.Length + 1);
            eventIl.Emit(OpCodes.Newarr, typeof(object));
            eventIl.Emit(OpCodes.Stloc, local);

            //start from 1 because the first item is the instance. Load up all the arguments
            for (int i = 1; i < delegateParameters.Length + 1; i++)
            {
                eventIl.Emit(OpCodes.Ldloc, local);
                eventIl.Emit(OpCodes.Ldc_I4, i);
                eventIl.Emit(OpCodes.Ldarg, i);
                eventIl.Emit(OpCodes.Stelem_Ref);
            }

            eventIl.Emit(OpCodes.Ldloc, local);
            //Load as first argument the instance of the object for the methodToInvoke i.e methodInvoker
            eventIl.Emit(OpCodes.Ldarg_0);
            eventIl.Emit(OpCodes.Ldstr, eventName);
            eventIl.Emit(OpCodes.Ldloc, local);
            eventIl.Emit(OpCodes.Ldc_I4, 2);
            eventIl.Emit(OpCodes.Ldarg, 2);
            eventIl.Emit(OpCodes.Stelem_Ref);
            eventIl.Emit(OpCodes.Ldloc, local);
            //Now that we have it all set up call the actual method that we want to call for the binding
            eventIl.EmitCall(OpCodes.Call, methodToInvoke, null);
            eventIl.Emit(OpCodes.Pop);
            eventIl.Emit(OpCodes.Ret);
            //create a delegate from the dynamic method
            return handler.CreateDelegate(eventHandlerType, methodInvoker);
        }
    }
}
