using AfterX;
using AfterX_backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterX_backend.Services.ServiceImplementations
{
    public class TableService : ITableService
    {
        private readonly DataContext _dataContext;
        public TableService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> CreateTableAsync(Table table)
        {
            _dataContext.Add(table);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteTableAsync(int tableId)
        {
            var table = await GetTableByIdAsync(tableId);

            _dataContext.Remove(table);

            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<Table> GetTableByIdAsync(int tableId)
        {
            var table = await _dataContext.Tables
                .FirstOrDefaultAsync(m => m.Id == tableId);

            return table;
        }
        public async Task<List<Table>> GetTablesByClubIdAsync(int clubId)
        {
            var tables = await _dataContext.Tables
                .Where(m => m.Clubid == clubId).ToListAsync();

            return tables;
        }
        public async Task<List<Table>> GetTablesAsync()
        {
            return await _dataContext.Tables.ToListAsync();

        }


        public async Task<bool> UpdateTableAsync(Table cityToUpdate)
        {
            _dataContext.Update(cityToUpdate);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> CreateTablesAsync(List<Table> tables,bool deleteOldTables, int clubId)
        {
            if (deleteOldTables && tables.Count>0)
            {
                var oldTables = await _dataContext.Tables.Where(table=>table.Clubid==clubId).ToListAsync();
                _dataContext.RemoveRange(oldTables);
            }
            await _dataContext.AddRangeAsync(tables);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }

    }
}