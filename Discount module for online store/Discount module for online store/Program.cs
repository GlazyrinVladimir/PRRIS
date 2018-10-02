using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscountModuleForOnlineStore;

class Program
{
    static void Main(string[] args)
    {
        //создание обьектов продукты
        Product A = new Product("A", 10);
        Product B = new Product("B", 20);
        Product C = new Product("C", 3);
        Product D = new Product("D", 30);
        Product E = new Product("E", 15);
        Product F = new Product("F", 25);
        Product G = new Product("G", 34);
        Product K = new Product("K", 37);
        Product L = new Product("L", 11);
        Product M = new Product("M", 17);

        //создание объекта магазина
        Shop shop = new Shop();

        //пример добавления продуктов в корзину
        shop.AddProductToShoppingCart(E);
        shop.AddProductToShoppingCart(E);
        shop.AddProductToShoppingCart(F);
        shop.AddProductToShoppingCart(F);
        shop.AddProductToShoppingCart(G);
        shop.AddProductToShoppingCart(G);

        //получение цены продуктов с учетом скидок
        float price = shop.GetSummaryPrice();
        Console.WriteLine(price);

        Console.ReadKey();
    }
}

