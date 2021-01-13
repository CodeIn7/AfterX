using AfterX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterX_backend.Services.Interfaces
{
    public interface ITableService
    {
        Task<List<Table>> GetTablesAsync();
        Task<List<Table>> GetTablesByClubIdAsync(int clubId);
        Task<Table> GetTableByIdAsync(int tableId);
        Task<bool> CreateTableAsync(Table table);
        Task<bool> CreateTablesAsync(List<Table> tables, bool deleteOldTables, int clubId);
        Task<bool> UpdateTableAsync(Table cityToUpdate);
        Task<bool> DeleteTableAsync(int tableId);
    }
}
