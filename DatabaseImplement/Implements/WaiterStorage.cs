using BusinessLogics.BindingModels;
using BusinessLogics.Interfaces;
using BusinessLogics.ViewModels;
using DatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DatabaseImplement.Implements
{
    /// <summary>
    /// Реализация хранилища официантов
    /// </summary>
    public class WaiterStorage : IWaiterStorage
    {
        /// <summary>
        /// Метод получения полного списка официантов
        /// </summary>
        /// <returns>Полный список официантов</returns>
        public List<WaiterViewModel> GetFullList()
        {
            using (var context = new Database())
            {
                return context.Waiters
                    .Select(waiter => new WaiterViewModel
                    {
                        Id = waiter.Id,
                        WaiterFullName = waiter.WaiterFullName,
                    })
                    .ToList();
            }
        }

        /// <summary>
        /// Метод получения отфильтрованного списка официантов
        /// </summary>
        /// <param name="model">Модель официанта</param>
        /// <returns>Отфильтрованный список официантов</returns>

        public List<WaiterViewModel> GetFilteredList(WaiterBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new Database())
            {
                return context.Waiters
                    .Where(waiter => waiter.WaiterFullName == model.WaiterFullName)
                    .Select(waiter => new WaiterViewModel
                    {
                        Id = waiter.Id,
                        WaiterFullName = waiter.WaiterFullName
                    })
                .ToList();
            }
        }

        /// <summary>
        /// Метод получения официанта
        /// </summary>
        /// <param name="model">Модель официанта</param>
        /// <returns>Официант</returns>
        public WaiterViewModel GetElement(WaiterBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new Database())
            {
                var tempWaiter = context.Waiters.FirstOrDefault(waiter => waiter.Id == model.Id);

                return tempWaiter != null ?
                    new WaiterViewModel
                    {
                        Id = tempWaiter.Id,
                        WaiterFullName = tempWaiter.WaiterFullName,
                    } : null;
            }
        }

        /// <summary>
        /// Метод добавления официанта
        /// </summary>
        /// <param name="model">Модель официанта</param>
        public void Insert(WaiterBindingModel model)
        {
            using (var context = new Database())
            {
                context.Waiters.Add(CreateModel(model, new Waiter()));
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Метод обновления официанта
        /// </summary>
        /// <param name="model">Модель официанта</param>
        public void Update(WaiterBindingModel model)
        {
            using (var context = new Database())
            {
                var tempWaiter = context.Waiters.FirstOrDefault(waiter => waiter.Id == model.Id);
                if (tempWaiter == null)
                {
                    throw new Exception("Официант не найден");
                }
                CreateModel(model, tempWaiter);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Метод удаления официанта
        /// </summary>
        /// <param name="model">Модель официанта</param>
        public void Delete(WaiterBindingModel model)
        {
            using (var context = new Database())
            {
                Waiter tempWaiter = context.Waiters.FirstOrDefault(waiter => waiter.Id == model.Id);

                if (tempWaiter != null)
                {
                    context.Waiters.Remove(tempWaiter);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Счет не найден");
                }
            }
        }

        /// <summary>
        /// Метод получения модели официанта
        /// </summary>
        /// <param name="model">Модель официанта</param>
        /// <param name="waiter">Модель официанта</param>
        /// <returns>Модель официанта</returns>
        private Waiter CreateModel(WaiterBindingModel model, Waiter waiter)
        {
            waiter.WaiterFullName = model.WaiterFullName;
            return waiter;
        }
    }
}
