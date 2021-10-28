using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Office.Interop.Word;

namespace PavComponents
{
    /// <summary>
    /// Класс для создания документа Word с настраиваемой таблицей
    /// </summary>
    public partial class Word_Custom_Table_Component : Component
    {
        public Word_Custom_Table_Component()
        {
            InitializeComponent();
        }

        public Word_Custom_Table_Component(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        /// <summary>
        /// Метод для создания документа Word с настраиваемой таблицей
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">Путь до документа</param>
        /// <param name="document_header">Название документа</param>
        /// <param name="height_rows">Массив высот строк</param>
        /// <param name="column_info">Информация о колонках (Заголовок, ширина, название свойства объекта)</param>
        /// <param name="list_of_data">Список данных (Объектов)</param>
        /// <returns>Получилось ли создать документ</returns>
        /// 
        public bool CreateDoc<T>(String path, String document_header, int[] height_rows, List<WordTableColumn> column_info, List<T> list_of_data)
        {
            try
            {
                //Если передаваемые параметры не пусты
                if (path != null && document_header != null && height_rows != null && column_info != null && list_of_data != null)
                {
                    //Если массив длина массива строк высот таблицы совпадает с длиной списка объектов (+1 строка под шапку)
                    if (height_rows.Length == list_of_data.Count + 1)
                    {
                        //Создаем приложение Word
                        Application application = new Application();
                        application.Visible = true;

                        //Открываем документ
                        Document document = application.Documents.Add(Visible: true);

                        Paragraph paragraph_header = document.Content.Paragraphs.Add();
                        paragraph_header.Range.Text = document_header;
                        paragraph_header.Range.Font.Size = 24;
                        paragraph_header.Range.Font.Name = "Century Gothic";
                        paragraph_header.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

                        Paragraph paragraph = document.Content.Paragraphs.Add();
                        paragraph = document.Content.Paragraphs.Add();

                        //Создаем таблицу (Дополнительная строка под шапку)
                        Table table = document.Tables.Add(paragraph.Range, list_of_data.Count + 1, column_info.Count);
                        table.Borders.Enable = 1;
                        table.Range.Font.Name = "verdana";
                        table.Range.Font.Size = 10;
                        table.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

                        //Названия свойств объекта в колонках
                        List<string> properties_columns = new List<string>();

                        foreach (var column in column_info)
                        {
                            properties_columns.Add(column.PropertyName);
                        }

                        //Нумерация колонок и строк в Word ничинается с 1 а не с 0
                        for (int row = 1; row <= table.Rows.Count; row++)
                        {
                            // Сдвиг в колонке идет из-за шапки
                            for (int column = 1; column <= table.Columns.Count; column++)
                            {
                                //Если это шапка
                                if (row == 1)
                                {
                                    //Выделяем жирным и записываем заголовок
                                    table.Cell(row, column).Range.Text = column_info[column - 1].Header;
                                    table.Cell(row, column).Range.Font.Bold = 1;
                                    table.Cell(row, column).Column.Width = column_info[column - 1].Width;
                                }
                                else
                                {
                                    //Получаем данные по свойству из объекта (по имени свойства этого объекта, которое есть для каждой колонки)
                                    var data = list_of_data[row - 2].GetType().GetProperty(column_info[column - 1].PropertyName)
                                        .GetValue(list_of_data[row - 2]) ?? null;

                                    //Если данные по свойству не пусты записываем в соответсвующую клетку
                                    if (data != null)
                                    {
                                        table.Cell(row, column).Range.Text = data.ToString();
                                    }

                                    //Если это вертикальная шапка (1 колонка) - Выделяем жирным
                                    table.Cell(row, column).Range.Font.Bold = column == 1 ? 1 : 0;

                                    //Если это вертикальная шапка (1 колонка) - Настраиваем ширину
                                    if (column == 1)
                                    {
                                        table.Cell(row, column).Row.Height = height_rows[row - 2];
                                    }
                                }

                                //Вертикальное расположение текста в клетке - по середине
                                table.Cell(row, column).VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                            }
                        }

                        //Проверка на заполненность шапок таблицы (1 строки и 1 столбца)
                        bool check_headers = true;

                        //Проверяем 1 строку
                        for (int column = 1; column <= table.Columns.Count; column++)
                        {
                            //Если \r\a - значит ячейка пустая
                            if (table.Cell(1, column).Range.Text == "\r\a")
                            {
                                check_headers = false;
                            }
                        }

                        //проверяем 1 колонку
                        for (int row = 1; row <= table.Rows.Count; row++)
                        {
                            //Если \r\a - значит ячейка пустая
                            if (table.Cell(row, 1).Range.Text == "\r\a")
                            {
                                check_headers = false;
                            }
                        }

                        //Сохраняем документ
                        document.SaveAs(path);

                        document.Close();
                        application.Quit();

                        //Если обнаружилась пустая клетка в заголовках
                        if (!check_headers)
                        {
                            throw new Exception(message: "Обнаружен пустой заголовок в шапке");
                        }

                        return true;
                    }
                    else
                    {
                        throw new Exception(message: "Массив высоты строк для таблицы не " +
                            "совподает по размеру с размером списка объектов");
                    }
                }
                else
                {
                    throw new Exception(message: "Один или несколько аргументов null");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }
    }
}