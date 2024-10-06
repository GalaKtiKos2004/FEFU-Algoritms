using System;

namespace Informatics
{
    public class BitManipulator
    {
        private byte[] _byteArray;

        public BitManipulator(byte[] byteArray)
        {
            _byteArray = byteArray;
        }

        public bool GetBit(int index)
        {
            if (index < 0 || index >= _byteArray.Length * 8)
                throw new ArgumentOutOfRangeException(nameof(index), "Индекс выходит за пределы допустимого диапазона.");

            int byteIndex = index / 8;
            int bitPosition = index % 8;

            return (_byteArray[byteIndex] & (1 << bitPosition)) != 0;
        }

        public void SetBit(int index, bool value)
        {
            if (index < 0 || index >= _byteArray.Length * 8)
                throw new ArgumentOutOfRangeException(nameof(index), "Индекс выходит за пределы допустимого диапазона.");

            int byteIndex = index / 8;
            int bitPosition = index % 8;

            if (value)
            {
                _byteArray[byteIndex] |= (byte)(1 << bitPosition);
            }
            else
            {
                _byteArray[byteIndex] &= (byte)~(1 << bitPosition);
            }
        }

        public byte[] GetByteArray()
        {
            return _byteArray;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите массив байтов через пробел");
            string input = Console.ReadLine();

            string[] byteStrings = input.Split(' ');
            byte[] byteArray = new byte[byteStrings.Length];
            for (int i = 0; i < byteStrings.Length; i++)
            {
                if (byte.TryParse(byteStrings[i], out byte value))
                {
                    byteArray[i] = value;
                }
                else
                {
                    Console.WriteLine($"Ошибка: '{byteStrings[i]}' не является допустимым значением байта.");
                    return;
                }
            }

            BitManipulator manipulator = new BitManipulator(byteArray);

            Console.WriteLine("Введите команду (get или set):");
            string command = Console.ReadLine()?.ToLower();

            Console.WriteLine("Введите индекс бита:");

            if (!int.TryParse(Console.ReadLine(), out int bitIndex) || bitIndex < 0)
            {
                Console.WriteLine("Ошибка: индекс должен быть неотрицательным числом.");
                return;
            }

            if (command == "get")
            {
                try
                {
                    bool bitValue = manipulator.GetBit(bitIndex - 1);
                    Console.WriteLine($"Значение бита {bitIndex}: {bitValue}");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if (command == "set")
            {
                Console.WriteLine("Введите значение бита (0 или 1):");
                if (int.TryParse(Console.ReadLine(), out int bitValue) && (bitValue == 0 || bitValue == 1))
                {
                    try
                    {
                        manipulator.SetBit(bitIndex - 1, bitValue == 1);
                        Console.WriteLine($"Бит {bitIndex} успешно установлен в {bitValue}.");
                    }
                    catch (ArgumentOutOfRangeException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка: значение должно быть 0 или 1.");
                }
            }
            else
            {
                Console.WriteLine("Ошибка: допустимые команды — 'get' или 'set'.");
            }

            byte[] newByteArray = manipulator.GetByteArray();
            Console.WriteLine("Измененный массив байтов:");
            foreach (var b in newByteArray)
            {
                Console.WriteLine(Convert.ToString(b, 2).PadLeft(8, '0'));
            }
        }
    }
}
