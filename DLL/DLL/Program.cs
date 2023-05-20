using System;
using User;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Numerics;
using System.Linq;

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
                Console.WriteLine("if you want to show all of users names press 5");
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
                        if (email.ToLower() == userData[i].Email.ToLower() && password == userData[i].Password)
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
                    bool update = false;
                    Console.WriteLine("if you want to update your profile enter user email");
                    string email = Console.ReadLine();
                    Console.WriteLine("if you want to update your profile enter user password");
                    string password = Console.ReadLine();
                    for (int i = 0; i < userData.Length; i++)
                    {
                        if (email.ToLower() == userData[i].Email.ToLower() && password == userData[i].Password)
                        {
                            update = true;
                            Console.WriteLine("if you want to change password press 1");
                            Console.WriteLine("if you want to change email and username press 2");
                            Console.WriteLine("if you want to change phone number press 3 Number must bu Azerbaijan number");
                            Console.WriteLine("if you dont want to update profile press 0");
                            int selection = Convert.ToInt32(Console.ReadLine());
                            if (selection==0)
                            {
                                Console.WriteLine("profile dont update");
                                update = false;
                                break;
                            }
                            else if (selection==1)
                            {
                                Console.WriteLine("enter new password for update your password");
                                string newPassword = Console.ReadLine();
                                Match matchPassword = rejPassword.Match(newPassword);
                                if (matchPassword.Success)
                                {
                                    userData[i].Password = newPassword;
                                    Console.WriteLine("password update..");
                                }
                            }
                            else if (selection == 2)
                            {
                                Console.WriteLine("enter new username for update your username");
                                string newUserName = Console.ReadLine();
                                Console.WriteLine("enter new Email for update your email");
                                string newEmail = Console.ReadLine();
                                Match matchEmail = rejEmail.Match(email);
                                if (matchEmail.Success)
                                {
                                    userData[i].Email = newEmail;
                                    Console.WriteLine("email update..");
                                }
                                else
                                {
                                    Console.WriteLine("email is not valid");
                                }
                                Console.WriteLine("username  update..");
                                
                                
                            }
                            else if (selection == 3)
                            {
                                Console.WriteLine("enter new phone number for update your phone number");
                                string newPhone = Console.ReadLine();
                                Match matchPhone = rejPhone.Match(newPhone);
                                if (matchPhone.Success)
                                {
                                    userData[i].Phone = newPhone;
                                    Console.WriteLine("phone number update..");
                                }
                                else
                                {
                                    Console.WriteLine("phone number must bu Azerbaijan number..");
                                }
                            }
                        }
                    }
                    if (update==false)
                    {
                        Console.WriteLine("email or password is incorrect");
                    }
                }
                else if (choose==4)
                {
                    Boolean deleted = false;
                    Console.WriteLine("if you want to delete your profile enter user email");
                    string email = Console.ReadLine();
                    Console.WriteLine("if you want to delete your profile enter user password");
                    string password = Console.ReadLine();
                    foreach (var item in userData)
                    {
                        if (email.ToLower()==item.Email.ToLower()&&password==item.Password)
                        {
                            userData = userData.Where(val => val != item).ToArray();
                            Console.WriteLine("your profile is deleted:");
                            deleted = true;
                        }
                    }
                    if (deleted==false)
                    {
                        Console.WriteLine("email or password is incorrect");
                    }
                }
                else if (choose==5)
                {
                    foreach (var item in userData)
                    {
                        item.Info();
                    }
                }

            }


        }
    }
}


