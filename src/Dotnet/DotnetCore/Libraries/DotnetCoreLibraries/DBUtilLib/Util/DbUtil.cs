using CSD.Util.Repository;
using CSD.Util.Service;
using System;
using System.Threading.Tasks;

namespace CSD.Util
{
    public static class DbUtil
    {

        #region Auto exception handling methods for repository
        public static R DoWorkForRepository<R>(Func<R> func, string msg)
        {
            try
            {
                return func();
            }
            catch (Exception ex) {
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
            var task = new Task<R>(() => DoWorkForRepository(func, msg));

            task.Start();

            return task;            
        }

        public static async Task DoWorkForRepositoryAsync(Func<Task> func, string msg)
        {
            try
            {
                await func();
            }
            catch (Exception ex)
            {
                throw new RepositoryException(msg, ex);
            }
        }

        public static Task DoWorkForRepositoryAsync(Action action, string msg)
        {
            var task = new Task(() => DoWorkForRepository(action, msg));

            task.Start();

            return task;
        }

        #endregion

        #region Auto exception handling methods for service
        public static R DoWorkForService<R>(Func<R> func, string msg)
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                throw new ServiceException(msg, ex is RepositoryException ? ex.InnerException : ex);
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

        public static async Task<R> DoWorkForServiceAsync<R>(Func<Task<R>> func, string msg)
        {
            try
            {
                return await func();
            }
            catch (Exception ex)
            {
                throw new ServiceException(msg, ex is RepositoryException ? ex.InnerException : ex);
            }
        }

        public static Task<R> DoWorkForServiceAsync<R>(Func<R> func, string msg)
        {
            var task = new Task<R>(() => DoWorkForService(func, msg));

            task.Start();

            return task;            
        }

        public static async Task DoWorkForServiceAsync(Func<Task> func, string msg)
        {
            try
            {
                await func();
            }
            catch (Exception ex)
            {
                throw new ServiceException(msg, ex is RepositoryException ? ex.InnerException : ex);
            }
        }

        public static Task DoWorkForServiceAsync(Action action, string msg)
        {
            var task = new Task(() => DoWorkForService(action, msg));

            task.Start();

            return task;
        }

        #endregion
    }
}
