//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.9
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------

namespace Tizen.NUI {

using System;
using System.Runtime.InteropServices;


    internal class ObjectRegistry : BaseHandle {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal ObjectRegistry(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.ObjectRegistry_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(ObjectRegistry obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  public override void Dispose() {
    if (!Window.IsInstalled()) {
      DisposeQueue.Instance.Add(this);
      return;
    }

    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          NDalicPINVOKE.delete_ObjectRegistry(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }




public class ObjectCreatedEventArgs : EventArgs
{
   private BaseHandle _baseHandle;

   public BaseHandle BaseHandle
   {
      get
      {
         return _baseHandle;
      }
      set
      {
         _baseHandle = value;
      }
   }
}

public class ObjectDestroyedEventArgs : EventArgs
{
   private RefObject _refObject;

   public RefObject RefObject
   {
      get
      {
         return _refObject;
      }
      set
      {
         _refObject = value;
      }
   }
}


  [UnmanagedFunctionPointer(CallingConvention.StdCall)]
  private delegate void ObjectCreatedEventCallbackDelegate(IntPtr baseHandle);
  private DaliEventHandler<object,ObjectCreatedEventArgs> _objectRegistryObjectCreatedEventHandler;
  private ObjectCreatedEventCallbackDelegate _objectRegistryObjectCreatedEventCallbackDelegate;

  [UnmanagedFunctionPointer(CallingConvention.StdCall)]
  private delegate void ObjectDestroyedEventCallbackDelegate(IntPtr fefObject);
  private DaliEventHandler<object,ObjectDestroyedEventArgs> _objectRegistryObjectDestroyedEventHandler;
  private ObjectDestroyedEventCallbackDelegate _objectRegistryObjectDestroyedEventCallbackDelegate;

  public event DaliEventHandler<object,ObjectCreatedEventArgs> ObjectCreated
  {
     add
     {
        lock(this)
        {
           // Restricted to only one listener
           if (_objectRegistryObjectCreatedEventHandler == null)
           {
              _objectRegistryObjectCreatedEventHandler += value;

              _objectRegistryObjectCreatedEventCallbackDelegate = new ObjectCreatedEventCallbackDelegate(OnObjectCreated);
              this.ObjectCreatedSignal().Connect(_objectRegistryObjectCreatedEventCallbackDelegate);
           }
        }
     }

     remove
     {
        lock(this)
        {
           if (_objectRegistryObjectCreatedEventHandler != null)
           {
              this.ObjectCreatedSignal().Disconnect(_objectRegistryObjectCreatedEventCallbackDelegate);
           }

           _objectRegistryObjectCreatedEventHandler -= value;
        }
     }
  }

  // Callback for ObjectRegistry ObjectCreatedSignal
  private void OnObjectCreated(IntPtr baseHandle)
  {
     ObjectCreatedEventArgs e = new ObjectCreatedEventArgs();

     // Populate all members of "e" (ObjectCreatedEventArgs) with real data
     //e.BaseHandle = BaseHandle.GetBaseHandleFromPtr(baseHandle); //GetBaseHandleFromPtr() is not present in BaseHandle.cs. Not sure what is the reason?

     if (_objectRegistryObjectCreatedEventHandler != null)
     {
        //here we send all data to user event handlers
        _objectRegistryObjectCreatedEventHandler(this, e);
     }
  }

  public event DaliEventHandler<object,ObjectDestroyedEventArgs> ObjectDestroyed
  {
     add
     {
        lock(this)
        {
           // Restricted to only one listener
           if (_objectRegistryObjectDestroyedEventHandler == null)
           {
              _objectRegistryObjectDestroyedEventHandler += value;

              _objectRegistryObjectDestroyedEventCallbackDelegate = new ObjectDestroyedEventCallbackDelegate(OnObjectDestroyed);
              this.ObjectDestroyedSignal().Connect(_objectRegistryObjectDestroyedEventCallbackDelegate);
           }
        }
     }

     remove
     {
        lock(this)
        {
           if (_objectRegistryObjectDestroyedEventHandler != null)
           {
              this.ObjectDestroyedSignal().Disconnect(_objectRegistryObjectDestroyedEventCallbackDelegate);
           }

           _objectRegistryObjectDestroyedEventHandler -= value;
        }
     }
  }

  // Callback for ObjectRegistry ObjectDestroyedSignal
  private void OnObjectDestroyed(IntPtr refObject)
  {
     ObjectDestroyedEventArgs e = new ObjectDestroyedEventArgs();

     // Populate all members of "e" (ObjectDestroyedEventArgs) with real data
     e.RefObject = RefObject.GetRefObjectFromPtr(refObject);

     if (_objectRegistryObjectDestroyedEventHandler != null)
     {
        //here we send all data to user event handlers
        _objectRegistryObjectDestroyedEventHandler(this, e);
     }
  }


  public ObjectRegistry() : this(NDalicPINVOKE.new_ObjectRegistry__SWIG_0(), true) {
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public ObjectRegistry(ObjectRegistry handle) : this(NDalicPINVOKE.new_ObjectRegistry__SWIG_1(ObjectRegistry.getCPtr(handle)), true) {
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public ObjectRegistry Assign(ObjectRegistry rhs) {
    ObjectRegistry ret = new ObjectRegistry(NDalicPINVOKE.ObjectRegistry_Assign(swigCPtr, ObjectRegistry.getCPtr(rhs)), false);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public ObjectCreatedSignal ObjectCreatedSignal() {
    ObjectCreatedSignal ret = new ObjectCreatedSignal(NDalicPINVOKE.ObjectRegistry_ObjectCreatedSignal(swigCPtr), false);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public ObjectDestroyedSignal ObjectDestroyedSignal() {
    ObjectDestroyedSignal ret = new ObjectDestroyedSignal(NDalicPINVOKE.ObjectRegistry_ObjectDestroyedSignal(swigCPtr), false);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

}

}
