﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ILRuntime.CLR.TypeSystem;
using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Stack;
using ILRuntime.Runtime.Enviorment;

namespace ILRuntime.Runtime.Intepreter
{
    #region Functions
    class FunctionDelegateAdapter<TResult> : DelegateAdapter, IDelegateAdapter
    {
        Func<TResult> action;

        public FunctionDelegateAdapter()
        {

        }

        private FunctionDelegateAdapter(Enviorment.AppDomain appdomain, ILTypeInstance instance, ILMethod method)
            : base(appdomain, instance, method)
        {
            action = InvokeILMethod;
        }

        public override Delegate Delegate
        {
            get
            {
                return action;
            }
        }

        TResult InvokeILMethod()
        {
            if (method.HasThis)
                return (TResult)appdomain.Invoke(method, instance);
            else
                return (TResult)appdomain.Invoke(method);
        }

        public override IDelegateAdapter Instantiate(Enviorment.AppDomain appdomain, ILTypeInstance instance, ILMethod method)
        {
            return new FunctionDelegateAdapter<TResult>(appdomain, instance, method);
        }

        public override void Combine(Delegate dele)
        {
            action += (Func<TResult>)dele;
        }
    }

    class FunctionDelegateAdapter<T1, TResult> : DelegateAdapter, IDelegateAdapter
    {
        Func<T1, TResult> action;

        public FunctionDelegateAdapter()
        {

        }

        private FunctionDelegateAdapter(Enviorment.AppDomain appdomain, ILTypeInstance instance, ILMethod method)
            : base(appdomain, instance, method)
        {
            action = InvokeILMethod;
        }

        public override Delegate Delegate
        {
            get
            {
                return action;
            }
        }

        TResult InvokeILMethod(T1 p1)
        {
            if (method.HasThis)
                return (TResult)appdomain.Invoke(method, instance, p1);
            else
                return (TResult)appdomain.Invoke(method, p1);
        }

        public override IDelegateAdapter Instantiate(Enviorment.AppDomain appdomain, ILTypeInstance instance, ILMethod method)
        {
            return new FunctionDelegateAdapter<T1, TResult>(appdomain, instance, method);
        }

        public override void Combine(Delegate dele)
        {
            action += (Func<T1, TResult>)dele;
        }
    }

    class FunctionDelegateAdapter<T1, T2, TResult> : DelegateAdapter, IDelegateAdapter
    {
        Func<T1, T2, TResult> action;

        public FunctionDelegateAdapter()
        {

        }

        private FunctionDelegateAdapter(Enviorment.AppDomain appdomain, ILTypeInstance instance, ILMethod method)
            : base(appdomain, instance, method)
        {
            action = InvokeILMethod;
        }

        public override Delegate Delegate
        {
            get
            {
                return action;
            }
        }

        TResult InvokeILMethod(T1 p1, T2 p2)
        {
            if (method.HasThis)
                return (TResult)appdomain.Invoke(method, instance, p1, p2);
            else
                return (TResult)appdomain.Invoke(method, p1, p2);
        }

        public override IDelegateAdapter Instantiate(Enviorment.AppDomain appdomain, ILTypeInstance instance, ILMethod method)
        {
            return new FunctionDelegateAdapter<T1, T2, TResult>(appdomain, instance, method);
        }

        public override void Combine(Delegate dele)
        {
            action += (Func<T1, T2, TResult>)dele;
        }
    }

    class FunctionDelegateAdapter<T1, T2, T3, TResult> : DelegateAdapter, IDelegateAdapter
    {
        Func<T1, T2, T3, TResult> action;

        public FunctionDelegateAdapter()
        {

        }

        private FunctionDelegateAdapter(Enviorment.AppDomain appdomain, ILTypeInstance instance, ILMethod method)
            : base(appdomain, instance, method)
        {
            action = InvokeILMethod;
        }

        public override Delegate Delegate
        {
            get
            {
                return action;
            }
        }

        TResult InvokeILMethod(T1 p1, T2 p2, T3 p3)
        {
            if (method.HasThis)
                return (TResult)appdomain.Invoke(method, instance, p1, p2, p3);
            else
                return (TResult)appdomain.Invoke(method, p1, p2, p3);
        }

        public override IDelegateAdapter Instantiate(Enviorment.AppDomain appdomain, ILTypeInstance instance, ILMethod method)
        {
            return new FunctionDelegateAdapter<T1, T2, T3, TResult>(appdomain, instance, method);
        }

        public override void Combine(Delegate dele)
        {
            action += (Func<T1, T2, T3, TResult>)dele;
        }
    }

    class FunctionDelegateAdapter<T1, T2, T3, T4, TResult> : DelegateAdapter, IDelegateAdapter
    {
        Func<T1, T2, T3, T4, TResult> action;

        public FunctionDelegateAdapter()
        {

        }

        private FunctionDelegateAdapter(Enviorment.AppDomain appdomain, ILTypeInstance instance, ILMethod method)
            : base(appdomain, instance, method)
        {
            action = InvokeILMethod;
        }

        public override Delegate Delegate
        {
            get
            {
                return action;
            }
        }

        TResult InvokeILMethod(T1 p1, T2 p2, T3 p3, T4 p4)
        {
            if (method.HasThis)
                return (TResult)appdomain.Invoke(method, instance, p1, p2, p3, p4);
            else
                return (TResult)appdomain.Invoke(method, p1, p2, p3, p4);
        }

        public override IDelegateAdapter Instantiate(Enviorment.AppDomain appdomain, ILTypeInstance instance, ILMethod method)
        {
            return new FunctionDelegateAdapter<T1, T2, T3, T4, TResult>(appdomain, instance, method);
        }

        public override void Combine(Delegate dele)
        {
            action += (Func<T1, T2, T3, T4, TResult>)dele;
        }
    }
    #endregion

    #region Methods
    class MethodDelegateAdapter<T1> : DelegateAdapter, IDelegateAdapter
    {
        Action<T1> action;

        public MethodDelegateAdapter()
        {

        }

        private MethodDelegateAdapter(Enviorment.AppDomain appdomain, ILTypeInstance instance, ILMethod method)
            : base(appdomain, instance, method)
        {
            action = InvokeILMethod;
        }

        public override Delegate Delegate
        {
            get
            {
                return action;
            }
        }

        void InvokeILMethod(T1 p1)
        {
            if (method.HasThis)
                appdomain.Invoke(method, instance, p1);
            else
                appdomain.Invoke(method, p1);
        }

        public override IDelegateAdapter Instantiate(Enviorment.AppDomain appdomain, ILTypeInstance instance, ILMethod method)
        {
            return new MethodDelegateAdapter<T1>(appdomain, instance, method);
        }

        public override void Combine(Delegate dele)
        {
            action += (Action<T1>)dele;
        }
    }

    class MethodDelegateAdapter<T1, T2> : DelegateAdapter, IDelegateAdapter
    {
        Action<T1, T2> action;

        public MethodDelegateAdapter()
        {

        }

        private MethodDelegateAdapter(Enviorment.AppDomain appdomain, ILTypeInstance instance, ILMethod method)
            : base(appdomain, instance, method)
        {
            action = InvokeILMethod;
        }

        public override Delegate Delegate
        {
            get
            {
                return action;
            }
        }

        void InvokeILMethod(T1 p1, T2 p2)
        {
            if (method.HasThis)
                appdomain.Invoke(method, instance, p1, p2);
            else
                appdomain.Invoke(method, p1, p2);
        }

        public override IDelegateAdapter Instantiate(Enviorment.AppDomain appdomain, ILTypeInstance instance, ILMethod method)
        {
            return new MethodDelegateAdapter<T1, T2>(appdomain, instance, method);
        }

        public override void Combine(Delegate dele)
        {
            action += (Action<T1, T2>)dele;
        }
    }

    class MethodDelegateAdapter<T1, T2, T3> : DelegateAdapter, IDelegateAdapter
    {
        Action<T1, T2, T3> action;

        public MethodDelegateAdapter()
        {

        }

        private MethodDelegateAdapter(Enviorment.AppDomain appdomain, ILTypeInstance instance, ILMethod method)
            : base(appdomain, instance, method)
        {
            action = InvokeILMethod;
        }

        public override Delegate Delegate
        {
            get
            {
                return action;
            }
        }

        void InvokeILMethod(T1 p1, T2 p2, T3 p3)
        {
            if (method.HasThis)
                appdomain.Invoke(method, instance, p1, p2, p3);
            else
                appdomain.Invoke(method, p1, p2, p3);
        }

        public override IDelegateAdapter Instantiate(Enviorment.AppDomain appdomain, ILTypeInstance instance, ILMethod method)
        {
            return new MethodDelegateAdapter<T1, T2, T3>(appdomain, instance, method);
        }

        public override void Combine(Delegate dele)
        {
            action += (Action<T1, T2, T3>)dele;
        }
    }

    class MethodDelegateAdapter<T1, T2, T3, T4> : DelegateAdapter, IDelegateAdapter
    {
        Action<T1, T2, T3, T4> action;

        public MethodDelegateAdapter()
        {

        }

        private MethodDelegateAdapter(Enviorment.AppDomain appdomain, ILTypeInstance instance, ILMethod method)
            : base(appdomain, instance, method)
        {
            action = InvokeILMethod;
        }

        public override Delegate Delegate
        {
            get
            {
                return action;
            }
        }

        void InvokeILMethod(T1 p1, T2 p2, T3 p3, T4 p4)
        {
            if (method.HasThis)
                appdomain.Invoke(method, instance, p1, p2, p3, p4);
            else
                appdomain.Invoke(method, p1, p2, p3, p4);
        }

        public override IDelegateAdapter Instantiate(Enviorment.AppDomain appdomain, ILTypeInstance instance, ILMethod method)
        {
            return new MethodDelegateAdapter<T1, T2, T3, T4>(appdomain, instance, method);
        }

        public override void Combine(Delegate dele)
        {
            action += (Action<T1, T2, T3, T4>)dele;
        }
    }

    class MethodDelegateAdapter : DelegateAdapter
    {
        Action action;
        
        public MethodDelegateAdapter()
        {

        }

        protected MethodDelegateAdapter(Enviorment.AppDomain appdomain, ILTypeInstance instance, ILMethod method)
            : base(appdomain, instance, method)
        {
            action = InvokeILMethod;
        }

        public override Delegate Delegate
        {
            get
            {
                return action;
            }
        }

        void InvokeILMethod()
        {
            if (method.HasThis)
                appdomain.Invoke(method, instance);
            else
                appdomain.Invoke(method);
        }

        public override IDelegateAdapter Instantiate(Enviorment.AppDomain appdomain, ILTypeInstance instance, ILMethod method)
        {
            return new MethodDelegateAdapter(appdomain, instance, method);
        }

        public override void Combine(Delegate dele)
        {
            action += (Action)dele;
        }
    }
    #endregion
    abstract class DelegateAdapter : ILTypeInstance, IDelegateAdapter
    {
        protected ILMethod method;
        protected ILTypeInstance instance;
        protected Enviorment.AppDomain appdomain;
        IDelegateAdapter next;

        public abstract Delegate Delegate { get; }

        protected DelegateAdapter() { }

        protected DelegateAdapter(Enviorment.AppDomain appdomain, ILTypeInstance instance, ILMethod method)
        {
            this.appdomain = appdomain;
            this.instance = instance;
            this.method = method;
        }

        public override bool IsValueType
        {
            get
            {
                return false;
            }
        }

        public unsafe StackObject* ILInvoke(ILIntepreter intp, StackObject* esp, List<object> mStack)
        {
            var ebp = esp;
            esp = ILInvokeSub(intp, esp, mStack);
            return ClearStack(intp, esp, ebp, mStack);
        }

        unsafe StackObject* ILInvokeSub(ILIntepreter intp, StackObject* esp, List<object> mStack)
        {
            var ebp = esp;
            bool unhandled;
            if (method.HasThis)
                esp = ILIntepreter.PushObject(esp, mStack, instance);
            int paramCnt = method.ParameterCount;
            for(int i = paramCnt; i > 0; i--)
            {
                intp.CopyToStack(esp, ebp - paramCnt, mStack);
                esp++;
            }
            var ret = intp.Execute(method, esp, out unhandled);
            if (next != null)
            {
                if (method.ReturnType != appdomain.VoidType)
                {
                    intp.Free(ret - 1);//Return value for multicast delegate doesn't make sense, only return the last one's value
                }
                DelegateAdapter n = (DelegateAdapter)next;
                ret = n.ILInvokeSub(intp, ebp, mStack);

            }
            return ret;
        }

        unsafe StackObject* ClearStack(ILIntepreter intp, StackObject* esp, StackObject* ebp, List<object> mStack)
        {
            int paramCnt = method.ParameterCount;
            object retObj = null;
            StackObject retSObj = StackObject.Null;
            bool hasReturn = method.ReturnType != appdomain.VoidType;
            if (hasReturn)
            {
                var ret = esp - 1;
                retSObj = *ret;
                if(ret->ObjectType>= ObjectTypes.Object)
                {
                    retObj = mStack[ret->Value];
                }
                intp.Free(ret);
            }
            for (int i = 1; i <= paramCnt; i++)
            {
                intp.Free(ebp - i);
            }
            var returnVal = ebp - paramCnt - 1;
            intp.Free(returnVal);//Free delegateInstance
            if (hasReturn)
            {
                *returnVal = retSObj;
                if(retObj != null)
                {
                    returnVal->Value = mStack.Count;
                    mStack.Add(retObj);
                }
                returnVal++;
            }
            return returnVal;
        }

        public abstract IDelegateAdapter Instantiate(Enviorment.AppDomain appdomain, ILTypeInstance instance, ILMethod method);

        public virtual void Combine(IDelegateAdapter adapter)
        {
            if (next != null)
                next.Combine(adapter);
            else
                next = adapter;
        }

        public abstract void Combine(Delegate dele);

        public override string ToString()
        {
            return method.ToString();
        }
    }

    unsafe interface IDelegateAdapter
    {
        Delegate Delegate { get; }
        StackObject* ILInvoke(ILIntepreter intp, StackObject* esp, List<object> mStack);
        IDelegateAdapter Instantiate(Enviorment.AppDomain appdomain, ILTypeInstance instance, ILMethod method);
        void Combine(IDelegateAdapter adapter);
        void Combine(Delegate dele);
    }
}