using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncOperationUIControls.Core
{
	public static class Extensions
	{
		public static Task<T> LockControls<T>(this Task<T> task, params Control[] lockControls)
		{
			var lockControlsList = lockControls.ToList();

			// disable controls
			lockControlsList.ForEach(c => c.Enabled = false);

			// enable controls
			return task
				.ContinueWith(t => { lockControlsList.ForEach(c => c.Enabled = true); return t; }, TaskScheduler.FromCurrentSynchronizationContext())
				.Unwrap()
			;
		}

		/// <summary>
		/// Dispose objects witout guarantie, that this completes before retuned task will be completed
		/// </summary>
		public static Task<T> WithLazyDispose<T>(this Task<T> task, params IDisposable[] disposables)
		{
			task
				.ContinueWith(t => {

					foreach (var disposable in disposables)
					{
						try
						{
							disposable.Dispose();
						}
						catch
						{
						}
					}

				}, TaskContinuationOptions.ExecuteSynchronously)
			;

			return task;
		}

		public static Task WithLazyDispose(this Task task, params IDisposable[] disposables)
		{
			// start tracking
			return task
				.ContinueWith(t => (object)null, TaskContinuationOptions.ExecuteSynchronously)
				.WithLazyDispose(disposables)
			;
		}
	}
}
