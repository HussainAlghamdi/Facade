﻿using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                var facadeForClient = new RestaurantFacade();
                Console.WriteLine("----------------------CLIENT ORDERS FOR PIZZA----------------------------\n");
                facadeForClient.GetNonVegPizza();
                facadeForClient.GetVegPizza();
                Console.WriteLine("\n----------------------CLIENT ORDERS FOR BREAD----------------------------\n");
                facadeForClient.GetGarlicBread();
                facadeForClient.GetCheesyGarlicBread();
            }
        }
        public class RestaurantFacade
        {
            private IPizza _PizzaProvider;
            private IBread _BreadProvider;
            public RestaurantFacade()
            {
                _PizzaProvider = new PizzaProvider();
                _BreadProvider = new BreadProvider();
            }
            public void GetNonVegPizza()
            {
                _PizzaProvider.GetNonVegPizza();
            }
            public void GetVegPizza()
            {
                _PizzaProvider.GetVegPizza();
            }
            public void GetGarlicBread()
            {
                _BreadProvider.GetGarlicBread();
            }
            public void GetCheesyGarlicBread()
            {
                _BreadProvider.GetCheesyGarlicBread();
            }
        }
        public interface IPizza
        {
            void GetVegPizza();
            void GetNonVegPizza();
        }
        public class PizzaProvider : IPizza
        {
            public void GetNonVegPizza()
            {
                GetNonVegToppings();
                Console.WriteLine("Getting Non Veg Pizza.");
            }
            public void GetVegPizza()
            {
                Console.WriteLine("Getting Veg Pizza.");
            }
            private void GetNonVegToppings()
            {
                Console.WriteLine("Getting Non Veg Pizza Toppings.");
            }
        }
        public interface IBread
        {
            void GetGarlicBread();
            void GetCheesyGarlicBread();
        }
        public class BreadProvider : IBread
        {
            public void GetGarlicBread()
            {
                Console.WriteLine("Getting Garlic Bread.");
            }
            public void GetCheesyGarlicBread()
            {
                GetCheese();
                Console.WriteLine("Getting Cheesy Garlic Bread.");
            }
            private void GetCheese()
            {
                Console.WriteLine("Getting Cheese.");
            }
        }
    }
}
