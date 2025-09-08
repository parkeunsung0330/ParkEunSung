using UnityEngine;
using System.Runtime.CompilerServices;
using UnityEngine.Networking;
using System;

namespace Fantasy3D
{
    public struct UnityWebRequestAwaiter : INotifyCompletion // I가 붙으면 인터페이스 
    {
        UnityWebRequestAsyncOperation asyncOp;
        Action conti;


        public UnityWebRequestAwaiter(UnityWebRequestAsyncOperation async0p)
        {
            this.asyncOp = async0p;
            conti = null;
        }

        public bool IsCompleted { get { return asyncOp.isDone; } }
        public void GetResult() { }

        public void OnCompleted(Action continuation)
        {
            this.conti = continuation;
            asyncOp.completed += OnRequestCompleted;
        }
        
        private void OnRequestCompleted(AsyncOperation operation)
        {
            conti.Invoke();
        }
    }

    public static class ExtensionMethos
    {

        public static UnityWebRequestAwaiter GetAwaiter(this UnityWebRequestAsyncOperation asyncOp)
        {
            return new UnityWebRequestAwaiter(asyncOp);
        }
    }
}
