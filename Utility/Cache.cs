using System;
using System.Collections;
using System.Runtime.Remoting.Messaging;

namespace Utility
{
	public class Cache
	{
		protected Hashtable _Cache = new Hashtable();

		protected object _LockObj = new object();

		public int Count
		{
			get
			{
				return this._Cache.Count;
			}
		}

		public virtual object GetObject(object key)
		{
			if (this._Cache.ContainsKey(key))
			{
				return this._Cache[key];
			}
			return null;
		}

		public void SaveCache(object key, object value)
		{
			EventSaveCache eventSaveCache = new EventSaveCache(this.SetCache);
			eventSaveCache.BeginInvoke(key, value, new AsyncCallback(this.Results), null);
		}

		protected virtual void SetCache(object key, object value)
		{
			lock (this._LockObj)
			{
				if (!this._Cache.ContainsKey(key))
				{
					this._Cache.Add(key, value);
				}
			}
		}

		private void Results(IAsyncResult ar)
		{
			EventSaveCache eventSaveCache = (EventSaveCache)((AsyncResult)ar).AsyncDelegate;
			eventSaveCache.EndInvoke(ar);
		}

		public virtual void DelObject(object key)
		{
			lock (this._Cache.SyncRoot)
			{
				this._Cache.Remove(key);
			}
		}

		public virtual void Clear()
		{
			lock (this._Cache.SyncRoot)
			{
				this._Cache.Clear();
			}
		}
	}
}
