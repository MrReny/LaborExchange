using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Radzen.Blazor;

namespace LaborExchange.Server.ViewModels
{
    public class QueryableViewModel<T> : ComponentBase where T : class, new()
    {
        //TODO inject logger

        [Inject] public LaborExchangeDbContext LocalDbContext { get; set; }

        [Inject] public IHttpContextAccessor ViewHttpContextAccessor { get; set; }

        public RadzenDataGrid<T> ItemsGrid;

        public T ItemToInsert;

        public IList<T> Items;

        #region RowEditing

        [Authorize(Roles = "Admin")] //TODO сделать
        public async Task EditRow(T item)
        {
            try
            {
                await ItemsGrid.EditRow(item);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void OnUpdateRow(T item)
        {
            try
            {
                if (item == ItemToInsert) ItemToInsert = null;

                LocalDbContext.Update(item);
                LocalDbContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public async Task SaveRow(T item)
        {
            try
            {
                if (item == ItemToInsert) ItemToInsert = null;

                await ItemsGrid.UpdateRow(item);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void CancelEdit(T item)
        {
            try
            {
                if (item == ItemToInsert) ItemToInsert = null;

                ItemsGrid.CancelEditRow(item);

                var itemEntry = LocalDbContext.Entry(item);
                if (itemEntry.State == EntityState.Modified)
                {
                    itemEntry.CurrentValues.SetValues(itemEntry.OriginalValues);
                    itemEntry.State = EntityState.Unchanged;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public async Task DeleteRow(T item)
        {
            try
            {
                if (item == ItemToInsert) ItemToInsert = null;

                if (Items.Contains(item))
                {
                    Items.Remove(item);

                    LocalDbContext.Remove(item);

                    await LocalDbContext.SaveChangesAsync();

                    await ItemsGrid.Reload();
                }
                else
                {
                    ItemsGrid.CancelEditRow(item);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public async Task InsertRow()
        {
            try
            {
                ItemToInsert = new T();
                await ItemsGrid.InsertRow(ItemToInsert);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void OnCreateRow(T item)
        {
            try
            {
                LocalDbContext.Add(item);

                LocalDbContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        #endregion
    }
}