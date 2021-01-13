using AfterX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterX_backend.Services.Interfaces
{
    public interface ITableTypeService
    {
        Task<List<TableType>> GetTableTypesAsync();
        Task<TableType> GetTableTypeByIdAsync(int tableTypeId);
        Task<bool> CreateTableTypeAsync(TableType tableType);
        Task<bool> UpdateTableTypeAsync(TableType tableTypeToUpdate);
        Task<bool> DeleteTableTypeAsync(int tableTypeId);
    }
}
