﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_EntityFramework
{
    public class UserView
    {
        public UserRepository _UserRepository;
        public UserView(UserRepository userRepository)
        {
            _UserRepository = userRepository;
        }
        public void WorkWithUsers()
        {
            string choice = string.Empty;
            do
            {
                Console.WriteLine("Что необходимо?\n'show': показать все данные;\n'add': добавить пользователя;\n'update': изменить имя;\n'delete': удалить по Id;\n'exit': выход\n");
                Console.Write("Что необходимо?\nВведите команду: ");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case nameof(Choice.show):
                        _UserRepository.SelectAllUsers();
                        break;
                    case nameof(Choice.delete):
                        Console.Write("Введите Id пользователя для удаления: ");
                        _UserRepository.DeleteUserById(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case nameof(Choice.update):
                        Console.Write("Введите Id пользователя для редактирования: ");
                        _UserRepository.UserDataChangeById(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case nameof(Choice.add):
                        _UserRepository.AddUser();
                        break;
                }
            } while (choice != nameof(Choice.exit));
        }
    }
}
