using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_StorageManagement.UnitOfWork
{
    public interface IUnitOfWork<out TContext> where TContext : DbContext, new()
    {
        TContext Context { get; }
    
    }
}
