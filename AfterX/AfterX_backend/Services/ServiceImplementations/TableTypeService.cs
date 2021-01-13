using AfterX;
using AfterX_backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AfterX_backend.Services.ServiceImplementations
{
    public class TableTypeService : ITableTypeService
    {
        private readonly DataContext _dataContext;
        public TableTypeService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<bool> CreateTableTypeAsync(TableType tableType)
        {
            _dataContext.Add(tableType);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteTableTypeAsync(int tableTypeId)
        {
            var tableType = await GetTableTypeByIdAsync(tableTypeId);

            _dataContext.Remove(tableType);

            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<TableType> GetTableTypeByIdAsync(int tableTypeId)
        {
            var tableType = await _dataContext.TableTypes
                .FirstOrDefaultAsync(m => m.Id == tableTypeId);

            return tableType;
        }

        public async Task<List<TableType>> GetTableTypesAsync()
        {
            return await _dataContext.TableTypes.ToListAsync();

        }

        public async Task<bool> UpdateTableTypeAsync(TableType cityToUpdate)
        {
            _dataContext.Update(cityToUpdate);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }
    }
}
