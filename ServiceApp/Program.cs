using StackExchange.Redis;
using System;

namespace ServiceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------");
            var redis = ConnectionMultiplexer.Connect("localhost:6379");
            var getSub = redis.GetSubscriber();
            getSub.Subscribe("Helloservice", (channel,name)=> Message(name));
            Console.ReadLine();
        }
        private static void Message(RedisValue name) => Console.WriteLine($"Hello {name}");

    }
}