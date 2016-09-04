using MiauCore.IO.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace MiauCore.IO.Domain.Infraestrutura
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> CreateRepository<T>() where T : class, IGenericEntity;
    }
}
