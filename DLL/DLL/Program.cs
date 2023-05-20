using System;
using User;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DLL
{
    class Program
    {
        static void Main(string[] args)
        {
           
            
            Regex rejEmail = new Regex(@"^[\w\.]{7,20}@[\w\.]{5,12}$");
            Regex rejPassword = new Regex(@"[\w]{8,20}");
            Regex rejPhone = new Regex(@"^\+994(51|50|70|77|55|99)[\d]{7}$");
            SignUp rufet = new SignUp("Rufet123", "Rufet1122", "rft.smayilov@bk.ru", "+994513004484");
            SignUp[] userData = new SignUp[] {rufet} ;
            
            while (true)
            {
                Console.WriteLine("if you want to create user press 1");
                Console.WriteLine("if you want to enter your user profile press 2");
                Console.WriteLine("if you want to update profile \"edit\" press 3");
                Console.WriteLine("if you want to delete profile press 4");
                Console.WriteLine("if you want to close page press 0");
                int choose = Convert.ToInt32(Console.ReadLine());
                if (choose==0)
                {
                    Console.WriteLine("page is closed");
                    break;
                }
                else if (choose==1)
                {
                    Console.WriteLine("enter username:");
                    string userName = Console.ReadLine();
                    Console.WriteLine("enter password and it must be strong");
                    string password = Console.ReadLine();
                    Console.WriteLine("enter email:and it must bu setisfy");
                    string email = Console.ReadLine();
                    Console.WriteLine("enter phone number and it must be Azerbaijan number");
                    string phone = Console.ReadLine();
                    Match matchPassword = rejPassword.Match(password);
                    Match matchEmail = rejEmail.Match(email);
                    Match matchPhone = rejPhone.Match(phone);
                    if (matchPassword.Success&&matchEmail.Success&&matchPhone.Success)
                    {
                        Boolean signUp = false;
                        for (int i = 0; i < userData.Length; i++)
                        {
                            if (userName != userData[i].Username && email != userData[i].Email)
                            {
                                signUp = true;
                            }
                        }
                        if (signUp==true)
                        {
                            SignUp user = new SignUp(userName, password, email, phone);
                            Array.Resize(ref userData, userData.Length + 1);
                            userData[userData.Length - 1] = user;
                            Console.WriteLine("user is succesfully created");
                        }
                        else
                        {
                            Console.WriteLine("there are these username or email");
                        }
                    }
                    else if (!matchPassword.Success)
                    {
                        Console.WriteLine("pasword is not strong");
                    }
                    else if (!matchEmail.Success)
                    {
                        Console.WriteLine("email is not valid");
                    }
                    else if (!matchPhone.Success)
                    {
                        Console.WriteLine("number is not Azerbaijan Numbers");
                    }
                    else
                    {
                        Console.WriteLine("informations is wrong");
                    }
                    
                }
                else if (choose==2)
                {
                    Boolean acces = false;
                    Console.WriteLine("enter user email:");
                    string email = Console.ReadLine();
                    Console.WriteLine("enter user password");
                    string password = Console.ReadLine();
                    for (int i = 0; i < userData.Length; i++)
                    {
                        if (email == userData[i].Email && password == userData[i].Password)
                        {
                            acces = true;
                            Console.WriteLine(userData[i].FullInfo());
                            break;
                        }
                    }
                    if (acces==false)
                    {
                        Console.WriteLine("your email and password is incorrect:");
                    }
                    
                }
                else if (choose==3)
                {
                    Boolean update = false;
                    Console.WriteLine("if you want to update your profile enter user email");
                    string email = Console.ReadLine();
                    Console.WriteLine("if you want to update your profile enter user password");
                    string password = Console.ReadLine();
                    for (int i = 0; i < userData.Length; i++)
                    {
                        if (email == userData[i].Email && password == userData[i].Password)
                        {
                            Console.WriteLine("if you want to change password press 1");
                            Console.WriteLine("if you want to change email and username press 2");
                            Console.WriteLine("if you want to change phone number press 3 Number must bu Azerbaijan number");
                            Console.WriteLine("if you want to edit profile press 4");
                            Console.WriteLine("if you dont want to update profile press 0");
                        }
                    }
                }

            }


        }
    }
}


