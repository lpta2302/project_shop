using General;
using System.Collections.Generic;

namespace Login;
//Tạo class đăng nhập
public class SignIn
{
    private List<NhanVien> listNhanVien;
    public SignIn(List<NhanVien> list){
        listNhanVien = list;
    }
    GeneralMethod generalMethod = new GeneralMethod();
    private string username = "";
    private string password = "";
    public bool IsNotEmpty(){
        return username != "" && password != "";
    }
    //hàm dùng để in ra form đăng nhập
    public void printSignForm()
    {
        Console.Clear();
        Console.WriteLine(
            "\n" +
            " ---------------------------- \n" +
            "|1.username:{0,-17}|\n" +
            "|2.password:{1,-17}|\n" +
            "|           3.Đăng Nhập      |\n" +
            " ---------------------------- ",
            username, password
        );
    }
    //Hàm dùng để đăng nhập
    public void inputUsername()
    {
        username = "";
        printSignForm();
        Console.SetCursorPosition(12, 2);
        username = generalMethod.inputString(15,username);
    }
    public void inputPassword()
    {
        password = "";
        printSignForm();
        Console.SetCursorPosition(12, 3);
        password = generalMethod.inputString(15,password);

    }
    public void wrongAccount(){
        Console.SetCursorPosition(0,0);
        Console.Clear();
        Console.WriteLine(
            " ---------------------------------------------- \n" +
            "|                                              |\n" +
            "|          Sai tài khoản hoặc mật khẩu         |\n" +
            "|         Nhấn phím bất kỳ để nhập lại         |\n" +
            "|                                              |\n" +
            " ---------------------------------------------- "
        );
        Console.ReadKey();
    }
    public NhanVien Identify(){
        bool haveit = false;
        foreach(NhanVien i in listNhanVien){
            if(username == i.UserName){
                haveit = true;
                if(password == i.PassWord){
                    return i;
                }
                else {
                    wrongAccount();
                    break;
                }
            }
        }
        //tránh in wrong account 2 lần
        if(!haveit)wrongAccount();
        return null;
    }
}