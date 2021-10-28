using BusinessLogics.BindingModels;
using BusinessLogics.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogics.Interfaces
{
    public interface IWaiterStorage
    {
        /// <summary>
        /// Метод получения полного списка официантов
        /// </summary>
        /// <returns>Список официантов</returns>
        List<WaiterViewModel> GetFullList();

        /// <summary>
        /// Метод получения отфильтрованного списка официантов
        /// </summary>
        /// <param name="model">Модель официанта</param>
        /// <returns>Список отфильтрованных официантов</returns>
        List<WaiterViewModel> GetFilteredList(WaiterBindingModel model);

        /// <summary>
        /// Метод получения официанта
        /// </summary>
        /// <param name="model">Модель официанта </param>
        /// <returns> Столик </returns>
        WaiterViewModel GetElement(WaiterBindingModel model);

        /// <summary>
        /// Добавить нового официанта
        /// </summary>
        /// <param name="model">Модель официанта</param>
        void Insert(WaiterBindingModel model);

        /// <summary>
        /// Обновить официанта
        /// </summary>
        /// <param name="model">Модель официанта</param>
        void Update(WaiterBindingModel model);

        /// <summary>
        /// Удалить официанта
        /// </summary>
        /// <param name="model">Модель официанта</param>
        void Delete(WaiterBindingModel model);
    }
}
