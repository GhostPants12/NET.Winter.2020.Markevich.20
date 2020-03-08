# Day 20
 * Strings. Task1
   
   * Реализовать метод, который принимает на вход строку source и количество итераций count.

   >public string Convert(string source, int count)
  
   * На каждой итерации метода объединяются нечетные символы строки и переносятся в ее начало, и четные символы, которые переносятся в конец.

         Пример (строка «Привет Эпам!»):

         1 итерация: «Пие пмрвтЭа!»
         2 итерация: «Пепртаи мвЭ!»
         ...

   * Результат работы метода – результат склеек символов через count итераций.

   * При реализации алгоритма учесть, что входная строка может содержать очень большое количество символов, а количество итераций может быть огромным. Оптимизировать код с точки зрения быстродействия и потребления ресурсов.

   * Проверить аргументы на валидность:

     * Запрещается передавать пустые строки, строки из пробелов, null.
     * Количество итераций должно быть больше 0.
     * При нарушении этих условий метод генерирует исключение.

   * Проверить работу метода с помощью модульных тестов (проект StringExtension.Tests (Ссылки на внешний сайт.)), к предложенным тест-кейсам добавить дополнительные.
* Strings. Task 2
   * Для объектов класса Note, у которого есть  свойства Author, Data, Content и др. (можно взять за основу класс, разработанный ранее) реализовать возможность строкового представления различного вида в зависимости от спецификатора формата (Ссылки на внешний сайт.). Например, для объекта со значениями

   * Author = "Jon Skeet", Data = 22.09.2019, Content = "Publish book "C# in Depth" " 

     могут быть следующие варианты:

            Note record: Jon Skeet, C# in Depth, 2019
            Note record: Jon Skeet, C# in Depth
            Nore record: Jon Skeet, 2019
            Note record: C# in Depth и т.д.
   * Разработать модульные тесты.
 * String.Task 3
   * Не изменяя класс Note, добавить для объектов данного класса дополнительную (любую не существующую у класса изначально) возможность форматирования, не предусмотренную классом.

   * Разработать модульные тесты.
