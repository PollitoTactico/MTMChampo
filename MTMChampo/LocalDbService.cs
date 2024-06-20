using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTMChampo.Models;
using System.Diagnostics;

namespace MTMChampo
{
    public class LocalDbService
    {
        private const string DB_CHAMPO = "bank_accounts.db";
        private readonly SQLiteAsyncConnection _connection;

        public LocalDbService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_CHAMPO));

            _connection.CreateTableAsync<CuentaBanco>().Wait();
        }
        public async Task<List<CuentaBanco>> GetCustomersAsync()
        {
            return await _connection.Table<CuentaBanco>().ToListAsync();
        }
        public async Task<CuentaBanco> GetById (int id)
        {
            return await _connection.Table<CuentaBanco>().Where(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task Create(CuentaBanco cuentaBanco)
        {
            await _connection.InsertAsync(cuentaBanco);
        }
        public async Task Update(CuentaBanco cuentaBanco)
        {
            await _connection.UpdateAsync(cuentaBanco);
        }
        public async Task Delete(CuentaBanco cuentaBanco)
        {
            await _connection.DeleteAsync(cuentaBanco);
        }
    }

    
}
