using System;
using System.Threading.Tasks;
using CSD.Util.Repository;
using CSD.Util.Service;

namespace CSD.Util
{
    public static class DbUtil
    {
        #region Sync Repository Operations

        public static R DoWorkForRepository<R>(Func<R> func, string msg)
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                throw new RepositoryException(msg, ex);
            }
        }

        public static void DoWorkForRepository(Action action, string msg)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                throw new RepositoryException(msg, ex);
            }
        }

        #endregion

        #region Sync Service Operations

        public static R DoWorkForService<R>(Func<R> func, string msg)
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                throw new ServiceException(msg,
                    ex is RepositoryException
                        ? ex.InnerException
                        : ex); //Repodan gelirse reponun sarmaladığı innerexception exception olarak gelmeli, yoksa innerinin inneri diye tren yapar
            }
        }

        public static void DoWorkForService(Action action, string msg)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                throw new ServiceException(msg, ex is RepositoryException ? ex.InnerException : ex);
            }
        }

        #endregion

        #region Wrap and Start Operations

        public static Task<R> WrapNStart<R>(Task<R> task)
        {
            task.Start();
            return task;
        }

        public static Task WrapNStart(Task task)
        {
            task.Start();
            return task;
        }

        #endregion

        #region Async Repository Operations

        public static async Task<R> DoWorkForRepositoryAsync<R>(Func<Task<R>> func, string msg)
        {
            try
            {
                return await func();
            }
            catch (Exception ex)
            {
                throw new RepositoryException(msg, ex);
            }
        }

        public static Task<R> DoWorkForRepositoryAsync<R>(Func<R> func, string msg)
        {
            try
            {
                return WrapNStart(new Task<R>(() => DoWorkForRepository(func, msg)));
            }
            catch (Exception ex)
            {
                throw new RepositoryException(msg, ex);
            }
        }

        public static async Task DoWorkForRepositoryAsync(Func<Task> action, string msg)
        {
            try
            {
                await action();
            }
            catch (Exception ex)
            {
                throw new RepositoryException(msg, ex);
            }
        }

        public static Task DoWorkForRepositoryAsync(Action action, string msg)
        {
            try
            {
                return WrapNStart(new Task(() => DoWorkForRepository(action, msg)));
            }
            catch (Exception ex)
            {
                throw new RepositoryException(msg, ex);
            }
        }

        #endregion

        #region Async Service Operations

        public static async Task<R> DoWorkForServiceAsync<R>(Func<Task<R>> func, string msg)
        {
            try
            {
                return await func();
            }
            catch (Exception ex)
            {
                throw new ServiceException(msg,
                    ex is RepositoryException
                        ? ex.InnerException
                        : ex); //Repodan gelirse reponun sarmaladığı innerexception exception olarak gelmeli, yoksa innerinin inneri diye tren yapar
            }
        }

        public static Task<R> DoWorkForServiceAsync<R>(Func<R> func, string msg)
        {
            try
            {
                return WrapNStart(new Task<R>(() => DoWorkForService(func, msg)));
            }
            catch (Exception ex)
            {
                throw new ServiceException(msg,
                    ex is RepositoryException
                        ? ex.InnerException
                        : ex); //Repodan gelirse reponun sarmaladığı innerexception exception olarak gelmeli, yoksa innerinin inneri diye tren yapar
            }
        }

        public static async Task DoWorkForServiceAsync(Func<Task> action, string msg)
        {
            try
            {
                await action();
            }
            catch (Exception ex)
            {
                throw new ServiceException(msg, ex is RepositoryException ? ex.InnerException : ex);
            }
        }

        public static Task DoWorkForServiceAsync(Action action, string msg)
        {
            try
            {
                return WrapNStart(new Task(() => DoWorkForService(action, msg)));
            }
            catch (Exception ex)
            {
                throw new ServiceException(msg, ex is RepositoryException ? ex.InnerException : ex);
            }
        }

        #endregion
    }
}