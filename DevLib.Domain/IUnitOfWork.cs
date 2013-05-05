using System;

namespace DevLib.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        ///<summary>
        /// Сохранить изменения в базу
        ///</summary>
        void Commit();
    }
}