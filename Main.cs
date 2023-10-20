using General;
using Login;
using Notification;
using PersonelManage;
using UpdateProfile;
using InventoryManage;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace DoAnCuoiKy{
    class Program
    {
        // tạo biến global để giữ thông tin
        static NhanVien account = new NhanVien();
        //tạo các list để thao tác
        static List<NhanVien> listNhanVien = new List<NhanVien>();
        static List<HangHoa> listHangHoa = new List<HangHoa>();
        static QuanLyThongBao manageNotification = new QuanLyThongBao();
        static ManagePersonel managePersonel = new ManagePersonel(listNhanVien);
        static ManageInventory manageInventory = new ManageInventory(listHangHoa);
        static UpdateInfo updateInfo = new UpdateInfo();
        static Calender calender = new Calender();
        static int logIn(){
            bool flag1 = true;
            while(flag1){
                //tạo class để đăng nhập
                SignIn dangNhap = new SignIn(listNhanVien);
                bool flag2 = true;
                //bắt đầu nhập
                while(flag2){
                    dangNhap.printSignForm();
                    Console.SetCursorPosition(2,4);
                    switch(Console.ReadKey(true).Key){
                        case ConsoleKey.D1:
                        //dòng này để nhận vào username
                        dangNhap.inputUsername();
                        break;
                        case ConsoleKey.D2:
                        //dòng này để nhận vào password
                        dangNhap.inputPassword();
                        break;
                        //chọn 3 để xác nhận đăng nhập
                        case ConsoleKey.D3:
                            //kiểm tra username và password đã được nhập chưa?
                            if(dangNhap.IsNotEmpty()){
                                account = dangNhap.Identify();
                                if(account != null){
                                    flag1 = false;
                                    flag2 = false;
                                }
                            }
                        break;
                    }
                }
                
            }
            return 2;
        }
        static void printMainPage(){
                Console.Clear();
                int accountType = account.TypeUser;
                Console.SetCursorPosition(0,0);
                string[] typeUser = {"Member","Admin"};
                string[,] content=
                new string[,]
                {
                    {
                        "1.Xem kho",
                        "2.Xem thông tin nhân viên",
                        "3.Xem thông báo",
                        "4.Cập nhật thông tin"
                    },
                    {
                        "1.Quản lý kho",
                        "2.Quản lý nhân viên",
                        "3.Cập nhật, xem thông báo",
                        "4.Cập nhật thông tin"
                    }
                };
                Console.WriteLine(
                    "{5,-20}{6,20}\n"+
                    " {4} \n"+
                    "|{0,-38}|\n"+
                    "|{1,-38}|\n"+
                    "|{2,-38}|\n"+
                    "|{3,-38}|\n"+
                    " {4} \n",
                    content[accountType,0],content[accountType,1],content[accountType,2],content[accountType,3],"".PadRight(38,'-'),"0.Đăng xuất",typeUser[account.TypeUser]
                );
            }
        static int navMainPage(){
            bool flag = true;
            while(flag){
                printMainPage();
                calender.printCalender();
                switch(Console.ReadKey(true).Key){
                    case ConsoleKey.D1:
                    if(account.TypeUser == 1)
                            quanLyKho();
                        else
                            manageInventory.HienThiBang();
                        break;
                    case ConsoleKey.D2:
                        if(account.TypeUser == 1)
                            quanLyNhanVien();
                        else
                            managePersonel.HienThiNhanVien(account.TypeUser);
                        break;
                    case ConsoleKey.D3:
                        if(account.TypeUser == 1)
                            Notification();
                        else
                        {
                            manageNotification.XemThongBao();
                            Console.ReadKey();
                        }
                    break;
                    case ConsoleKey.D4:
                        Information();
                    break;
                    case ConsoleKey.D0:
                        account = new NhanVien();
                        return 1;
                }
            }
            return 3;
        }
        static void quanLyKho(){
            while (true)
            {
                manageInventory.printInventory();
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D0:
                        return;
                    case ConsoleKey.D1:
                        manageInventory.HienThiBang();
                        break;
                    case ConsoleKey.D2:
                        manageInventory.CapNhatKho();
                        break;
                }
            }
        }
        static void quanLyNhanVien()
        {
            while (true)
            {
                bool flag = true;
                managePersonel.PrintQuanLyNhanVien();
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D0: 
                    return;
                    case ConsoleKey.D1:
                        managePersonel.NhapNhanVien();
                        break;
                    case ConsoleKey.D2: 
                        managePersonel.HienThiNhanVien(account.TypeUser);
                    break;
                    case ConsoleKey.D3:
                        while (flag)
                        {
                            managePersonel.PrintTimNhanVien();
                            switch (Console.ReadKey(true).Key)
                            {
                                case ConsoleKey.D0:
                                    flag = false;
                                    break;
                                case ConsoleKey.D1:
                                    Console.Write("Nhập tên nhân viên: ");
                                    string tenNV = Console.ReadLine();
                                    List<NhanVien> KqTimKiem = managePersonel.TimTen(tenNV);
                                    if (KqTimKiem != null)
                                    {
                                        Console.WriteLine("Nhấn phím bất kỳ để tiếp tục");
                                        managePersonel.ShowNhanVien(KqTimKiem);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Không có nhân viên nào tên: " + tenNV);
                                        Console.WriteLine("Nhấn phím bất kỳ để tiếp tục");
                                    }
                                Console.ReadKey(true);
                                break;
                            }
                        }
                        break;
                    case ConsoleKey.D4:
                        int idNv = -1;
                        while (flag)
                        {
                            managePersonel.PrintXoaNhanVien(idNv);
                            Console.WriteLine();
                            managePersonel.ShowNhanVien(listNhanVien);
                            switch (Console.ReadKey(true).Key)
                            {
                                case ConsoleKey.D1:
                                    idNv = managePersonel.inputId();
                                    break;
                                case ConsoleKey.D2:
                                    if(idNv != -1){
                                        managePersonel.XoaNhanVien(idNv);
                                        idNv = -1;
                                    }
                                    break;
                                case ConsoleKey.D0:
                                    flag = false;
                                    break;
                            }
                        }
                        break;
                }
            }
        }
        static void Notification(){
            while (true)
            {                
                manageNotification.printBangThongBao();
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D0:
                        return;
                    case ConsoleKey.D1:
                        manageNotification.printBangThongBao();
                        Console.Write("Nhập tiêu đề: ");
                        string tieuDe = Console.ReadLine();
                        Console.Write("Nhập nội dung: ");
                        string noiDung = Console.ReadLine();
                        manageNotification.DangThongBao(tieuDe, noiDung);
                        break;
                    case ConsoleKey.D2:
                        while (true)
                        {
                            manageNotification.printBangThongBao();
                            Console.Write("Nhập ID thông báo cần xóa (0 để quay lại): ");
                            int idXoa;
                            idXoa = manageNotification.inputIdThongBao();
                            if (idXoa == 0)
                                break;
                            else if(idXoa != -1)
                            manageNotification.XoaThongBao(idXoa);
                        }
                        break;
                    case ConsoleKey.D3:
                        manageNotification.XemThongBao();
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void Information()
        {
            while (true)
            {
                updateInfo.printBang(account);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1: 
                        account.PassWord=updateInfo.inputPassWord(account);
                        break;
                    case ConsoleKey.D2: 
                        account.TenNhanVien=updateInfo.inputTenNhanVien(account);
                        break;
                    case ConsoleKey.D3: 
                        account.BirthDay = updateInfo.inputBirthDay(account);
                        break;
                    case ConsoleKey.D4:
                        account.GioiTinh= updateInfo.inputGioiTinh();
                        break;
                    case ConsoleKey.D5: 
                        account.CCCD=updateInfo.inputCanCuoc(account);
                            break;
                    case ConsoleKey.D6:
                        account.SDT = updateInfo.inputSDT(account);
                            break;
                    case ConsoleKey.D7: 
                        managePersonel.setDataNhanVien();
                        return;
                    case ConsoleKey.D0: 
                        return;
                }
            }
        
        }
        static void Main(){
            Console.OutputEncoding = Encoding.UTF8;
            // Lấy thông tin từ file
            managePersonel.getDataNhanVien();
            manageInventory.getDataHangHoa();
            manageNotification.getDataThongBao();
            //bắt đầu giai đoạn
            int phase = 1;
            // vòng lặp này để quản lý flow ban đầu của chương trình
            while(phase != -1){
                switch(phase){
                    case 1:
                    phase = logIn();
                    break;
                    case 2:
                    phase = navMainPage();
                    break;
                    default:
                    phase = -1;
                    break;
                }
            }
        }
    }
}