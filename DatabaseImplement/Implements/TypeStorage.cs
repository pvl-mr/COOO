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
    /// Реализация хранилища типов
    /// </summary>
    public class TypeStorage : ITypeStorage
    {
        /// <summary>
        /// Метод получения полного списка типов
        /// </summary>
        /// <returns>Полный список типов</returns>
        public List<TypeViewModel> GetFullList()
        {
            using (var context = new Database())
            {
                return context.Types
                    .Select(type => new TypeViewModel
                    {
                        Id = type.Id,
                        TypeName = type.TypeName,
                    })
                    .ToList();
            }
        }

        /// <summary>
        /// Метод получения отфильтрованного списка типов
        /// </summary>
        /// <param name="model">Модель типа</param>
        /// <returns>Отфильтрованный список типов</returns>

        public List<TypeViewModel> GetFilteredList(TypeBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new Database())
            {
                return context.Types
                    .Where(type => type.TypeName == model.TypeName)
                    .Select(type => new TypeViewModel
                    {
                        Id = type.Id,
                        TypeName = type.TypeName
                    })
                .ToList();
            }
        }

        /// <summary>
        /// Метод получения тип
        /// </summary>
        /// <param name="model">Модель типа</param>
        /// <returns>Тип</returns>
        public TypeViewModel GetElement(TypeBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new Database())
            {
                var tempType = context.Types.FirstOrDefault(type => type.Id == model.Id);

                return tempType != null ?
                    new TypeViewModel
                    {
                        Id = tempType.Id,
                        TypeName = tempType.TypeName,
                    } : null;
            }
        }

        /// <summary>
        /// Метод добавления типа
        /// </summary>
        /// <param name="model">Модель типа</param>
        public void Insert(TypeBindingModel model)
        {
            using (var context = new Database())
            {
                context.Types.Add(CreateModel(model, new Models.Type()));
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Метод обновления типа
        /// </summary>
        /// <param name="model">Модель типа</param>
        public void Update(TypeBindingModel model)
        {
            using (var context = new Database())
            {
                var tempType = context.Types.FirstOrDefault(type => type.Id == model.Id);
                if (tempType == null)
                {
                    throw new Exception("Тип заказа не найден");
                }
                CreateModel(model, tempType);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Метод удаления типа заказа
        /// </summary>
        /// <param name="model">Модель типа заказа</param>
        public void Delete(TypeBindingModel model)
        {
            using (var context = new Database())
            {
                Models.Type tempType = context.Types.FirstOrDefault(waiter => waiter.Id == model.Id);

                if (tempType != null)
                {
                    context.Types.Remove(tempType);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Счет не найден");
                }
            }
        }

        /// <summary>
        /// Метод получения модели типа заказа
        /// </summary>
        /// <param name="model">Модель типа заказа</param>
        /// <param name="type">Модель типа заказа</param>
        /// <returns>Модель тип</returns>
        private Models.Type CreateModel(TypeBindingModel model, Models.Type type)
        {
            type.TypeName = model.TypeName;
            return type;
        }
    }
}
