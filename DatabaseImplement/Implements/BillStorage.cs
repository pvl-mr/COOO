using BusinessLogics.BindingModels;
using BusinessLogics.Interfaces;
using BusinessLogics.ViewModels;
using DatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseImplement.Implements
{
    /// <summary>
    /// Реализация хранилища счетов
    /// </summary>
    public class BillStorage : IBillStorage
    {
        /// <summary>
        /// Метод получения полного списка счетов
        /// </summary>
        /// <returns>Полный список счетов</returns>
        public List<BillViewModel> GetFullList()
        {
            using (var context = new Database())
            {
                return context.Bills
                    .Include(bill => bill.Waiter)
                    .Select(bill => new BillViewModel
                    {
                        Id = bill.Id,
                        WaiterId = bill.WaiterId,
                        WaiterFullName = bill.Waiter.WaiterFullName,
                        Type = bill.Type,
                        Info = bill.Info,
                        Sum = bill.Sum.ToString()
                    })
                    .ToList();
            }
        }

        /// <summary>
        /// Метод получения отфильтрованного списка счетов
        /// </summary>
        /// <param name="model">Модель счета</param>
        /// <returns>Отфильтрованный список счетов</returns>
        public List<BillViewModel> GetFilteredList(BillBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new Database())
            {
                return context.Bills
                //    .Where(bill => bill.TableId == model.TableId)
                    .Include(bill => bill.Waiter)
                    .Select(bill => new BillViewModel
                    {
                        Id = bill.Id,
                        WaiterId = bill.WaiterId,
                        WaiterFullName = bill.Waiter.WaiterFullName,
                        Type = bill.Type,
                        Info = bill.Info,
                        Sum = bill.Sum.ToString()
                    })
                .ToList();
            }
        }

        /// <summary>
        /// Метод получения счета
        /// </summary>
        /// <param name="model">Модель счета</param>
        /// <returns>Счет</returns>
        public BillViewModel GetElement(BillBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new Database())
            {
                var tempBill = context.Bills.Include(bill => bill.Waiter).FirstOrDefault(bill => bill.Id == model.Id);

                return tempBill != null ?
                    new BillViewModel
                    {
                        Id = tempBill.Id,
                        WaiterId = tempBill.WaiterId,
                        WaiterFullName = tempBill.Waiter.WaiterFullName,
                        Type = tempBill.Type,
                        Info = tempBill.Info,
                        Sum = tempBill.Sum.ToString()
                    } : null;
            }
        }

        /// <summary>
        /// Метод добавления счета
        /// </summary>
        /// <param name="model">Модель счета</param>
        public void Insert(BillBindingModel model)
        {
            using (var context = new Database())
            {
                context.Bills.Add(CreateModel(model, new Bill()));
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Метод обновления счета
        /// </summary>
        /// <param name="model">Модель счета</param>
        public void Update(BillBindingModel model)
        {
            using (var context = new Database())
            {
                var tempBill = context.Bills.FirstOrDefault(bill => bill.Id == model.Id);
                if (tempBill == null)
                {
                    throw new Exception("Счет не найден");
                }
                CreateModel(model, tempBill);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Метод удаления счета
        /// </summary>
        /// <param name="model">Модель счета</param>
        public void Delete(BillBindingModel model)
        {
            using (var context = new Database())
            {
                Bill tempBill = context.Bills.FirstOrDefault(bill => bill.Id == model.Id);

                if (tempBill != null)
                {
                    context.Bills.Remove(tempBill);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Счет не найден");
                }
            }
        }

        /// <summary>
        /// Метод получения модели счета
        /// </summary>
        /// <param name="model">Модель счета</param>
        /// <param name="bill">Модель счета</param>
        /// <returns>Модель счета</returns>
        private Bill CreateModel(BillBindingModel model, Bill bill)
        {
            bill.WaiterId = model.WaiterId;
            bill.Type = model.Type;
            bill.Info = model.Info;
            bill.Sum = model.Sum;
            return bill;
        }
    }
}
