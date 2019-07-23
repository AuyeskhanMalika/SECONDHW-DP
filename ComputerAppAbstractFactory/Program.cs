using System;

namespace ComputerAppAbstractFactory
{
        public interface IComputerFactory
        {
            IMainboard CreateMainboard();

            IProcessor CreateProcessor();
        }
        class Dell : IComputerFactory
        {
            public IMainboard CreateMainboard()
            {
                return new DellMainboard();
            }

            public IProcessor CreateProcessor()
            {
                return new DellProcessor();
            }
        }
        class Sony : IComputerFactory
        {
            public IMainboard CreateMainboard()
            {
                return new SonyMainboard();
            }

            public IProcessor CreateProcessor()
            {
                return new SonyProcessor();
            }
        }
        public interface IMainboard
        {
            string ShowMessage();
        }
        class DellMainboard : IMainboard
        {
            public string ShowMessage()
            {
                return "Dell's monitor shows message:";
            }
        }

        class SonyMainboard : IMainboard
        {
            public string ShowMessage()
            {
                return "Sony's monitor shows message:";
            }
        }
        public interface IProcessor
        {
            string ShowBatteryVolume();
            string ShowBatteryChargeLevel(IMainboard collaborator);
        }
        class DellProcessor : IProcessor
        {
            public string ShowBatteryVolume()
            {
                return "Dell's processor volume is 2000 MAh";
            }
            public string ShowBatteryChargeLevel(IMainboard collaborator)
            {
                var result = collaborator.ShowMessage();

                return $"({result}): processor charge level is 40%";
            }
        }

        class SonyProcessor : IProcessor
        {
            public string ShowBatteryVolume()
            {
                return "Sony's processor volume is 1500 MAh";
            }
            public string ShowBatteryChargeLevel(IMainboard collaborator)
            {
                var result = collaborator.ShowMessage();

                return $"({result}): processor charge level is 40%";
            }
        }
        class Client
        {
            public void Main()
            {
                // Клиентский код может работать с любым конкретным классом
                // фабрики.
                Console.WriteLine("Client: Testing client code with the first factory type...");
                ClientMethod(new Dell());
                Console.WriteLine();

                Console.WriteLine("Client: Testing the same client code with the second factory type...");
                ClientMethod(new Sony());
            }

            public void ClientMethod(IComputerFactory factory)
            {
                IMainboard mainboard = factory.CreateMainboard();
                IProcessor processor = factory.CreateProcessor();

                Console.WriteLine(processor.ShowBatteryVolume());
                Console.WriteLine(processor.ShowBatteryChargeLevel(mainboard));
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                new Client().Main();
            }
        }
    }
