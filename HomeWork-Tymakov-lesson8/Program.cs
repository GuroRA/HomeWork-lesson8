using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_Tymakov_lesson8
{
    internal class Program
    {

        static void TymakovLabTasks()
        {
            BankAccount BobsAccount = new BankAccount(344.4M);
            BankAccount TomsAccount = new BankAccount();
            BankAccount LeraAccount = new BankAccount(345.4M, AccountType.currentAccount);
            LeraAccount.TransferMoney(BobsAccount, 45);
            BobsAccount.DepositMoney(145);
            BobsAccount.DepositMoney(245);
            BobsAccount.WithdrawMoney(65);
            BobsAccount.Dispose();
        }

        static void TytmakovHomeTask()
        {
            Song song = new Song();
            Song song2 = new Song("My ordinary life", "The Living Tombstone");
            Song song3 = new Song("I Got No Time", "The Living Tombstone", song2);
            Console.WriteLine(song.Title());
            Console.WriteLine(song2.Title());
            Console.WriteLine(song3.Prev.Title());
        }
        static void Main(string[] args)
        {
            /*
            Упражнение 9.1 В классе банковский счет, созданном в предыдущих упражнениях, удалить
            методы заполнения полей. Вместо этих методов создать конструкторы. Переопределить
            конструктор по умолчанию, создать конструктор для заполнения поля баланс, конструктор
            для заполнения поля тип банковского счета, конструктор для заполнения баланса и типа
            банковского счета. Каждый конструктор должен вызывать метод, генерирующий номер
            счета.

            Упражнение 9.2 Создать новый класс BankTransaction, который будет хранить информацию
            о всех банковских операциях. При изменении баланса счета создается новый объект класса
            BankTransaction, который содержит текущую дату и время, добавленную или снятую со
            счета сумму. Поля класса должны быть только для чтения (readonly). Конструктору класса
            передается один параметр – сумма. В классе банковский счет добавить закрытое поле типа
            System.Collections.Queue, которое будет хранить объекты класса BankTransaction для
            данного банковского счета; изменить методы снятия со счета и добавления на счет так,
            чтобы в них создавался объект класса BankTransaction и каждый объект добавлялся в
            переменную типа System.Collections.Queue.

            Упражнение 9.3 В классе банковский счет создать метод Dispose, который данные о
            проводках из очереди запишет в файл. Не забудьте внутри метода Dispose вызвать метод
            GC.SuppressFinalize, который сообщает системе, что она не должна вызывать метод
            завершения для указанного объекта.
            */
            TymakovLabTasks();

            /*
            Домашнее задание 9.1 В класс Song (из домашнего задания 8.2) добавить следующие
            конструкторы:
            1) параметры конструктора – название и автор песни, указатель на предыдущую песню
            инициализировать null.
            2) параметры конструктора – название, автор песни, предыдущая песня. В методе Main
            создать объект mySong. Возникнет ли ошибка при инициализации объекта mySong
            следующим образом: Song mySong = new Song(); ?
            */

            TytmakovHomeTask();
            Console.ReadKey();
        }
    }
}
