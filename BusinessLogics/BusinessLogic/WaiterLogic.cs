using BusinessLogics.BindingModels;
using BusinessLogics.Interfaces;
using BusinessLogics.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogics.BusinessLogic
{
    /// <summary>
    /// Логика официантов
    /// </summary>
    public class WaiterLogic
    {
        /// <summary>
        /// Хранилище офицантов
        /// </summary>
        private readonly IWaiterStorage waiterStorage;

        /// <summary>
        /// Конструктор логики официантов
        /// </summary>
        /// <param name="waiterStorage"> Хранилище официантов </param>
        public WaiterLogic(IWaiterStorage waiterStorage)
        {
            this.waiterStorage = waiterStorage;
        }

        /// <summary>
        /// Получить список официантов
        /// </summary>
        /// <param name="model"> Модель официанта </param>
        /// <returns> Список официантов </returns>
        public List<WaiterViewModel> Read(WaiterBindingModel model)
        {
            if (model == null)
            {
                return waiterStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<WaiterViewModel>
            {
                waiterStorage.GetElement(model)
            };
            }
            return waiterStorage.GetFilteredList(model);
        }

        /// <summary>
        /// Добавить официанта
        /// </summary>
        /// <param name="model"> Модель официанта </param>
        public void CreateOrUpdate(WaiterBindingModel model)
        {
            if (model.Id.HasValue)
            {
                waiterStorage.Update(model);
            }
            else
            {
                waiterStorage.Insert(model);
            }
        }

        /// <summary>
        /// Удалить официанта
        /// </summary>
        /// <param name="model"> Модель официанта </param>
        public void Delete(WaiterBindingModel model)
        {
            var element = waiterStorage.GetElement(new WaiterBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Официант не найден");
            }
            waiterStorage.Delete(model);
        }
    }
}

