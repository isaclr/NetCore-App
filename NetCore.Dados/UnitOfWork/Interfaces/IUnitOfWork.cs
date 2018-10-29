using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Dados.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Confirmar();
    }
}
