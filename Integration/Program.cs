using Integration;

class Program
{
    static void Main(string[] strings)
    {
        //  создаём список с типом данных Contact
        var phoneBook = new List<Contact>
        {
            // добавляем контакты
            new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"),
            new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"),
            new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"),
            new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"),
            new Contact("Сергей", "Брин", 799900000013, "serg@example.com"),
            new Contact("Лариса", "Абрикосова", 79838371723, "whoami@nowhere.com"),
            new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"),
            new Contact("Лариса", "Абрамова", 79909371273, "lara1967@mail.ru")
        };

        // кол-во контактов на странице
        int amountContactsOnPage = 5;
        // кол-во страниц: если кол-во объектов не кратно amountContactsOnPage
        // - добавляется ещё одна страница
        int pages = (phoneBook.Count % amountContactsOnPage == 0) 
                    ? phoneBook.Count / amountContactsOnPage
                    : phoneBook.Count / amountContactsOnPage + 1;

        // сортировка всей телефонной книги
        phoneBook = phoneBook.OrderBy(i => i.Name).ThenBy(i => i.LastName).ToList();

        while (true)
        { 
            Console.WriteLine("Выберете страницу: ");
            int n = int.Parse(Console.ReadLine());
            if (n > 0 && n <= pages)
            {
                if (phoneBook.Count % pages == 0 || (phoneBook.Count % pages > 0 && n != pages))
                {
                    var nameBook = from item in phoneBook
                                    .Skip((n - 1) * amountContactsOnPage)
                                    .Take(amountContactsOnPage)
                                    select new NameQuery()
                                    {
                                        FirstName = item.Name,
                                        LastName = item.LastName,
                                    };
                    foreach(var item in nameBook)
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
                else// выводятся объекты со страницы, когда их там меньше, чем amountContactsOnPage
                {
                    var nameBook = from item in phoneBook
                                    .Skip((n - 1) * amountContactsOnPage)
                                    .Take(phoneBook.Count % amountContactsOnPage)
                                    select new NameQuery()
                                    {
                                        FirstName = item.Name,
                                        LastName = item.LastName,
                                    };
                    foreach (var item in nameBook)
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
            }
            else
            {
                Console.WriteLine($"Страницы не существует!");
            }
            Console.WriteLine();
        }
    }
}