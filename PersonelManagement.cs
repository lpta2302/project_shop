﻿using General;
namespace PersonelManage
{
    public class ManagePersonel
    {
        GeneralMethod generalMethod = new GeneralMethod();
        private List<NhanVien> listNhanVien;
        public ManagePersonel(List<NhanVien> list){
            listNhanVien = list;
        }
        public void PrintQuanLyNhanVien()
        {
            Console.Clear();
            Console.SetCursorPosition(18, 0);
            Console.WriteLine("QUẢN LÝ NHÂN VIÊN ");
            Console.WriteLine("0. Quay lại");
            Console.Write(" ----------------------------------------------------- \n" +
                          "| 1. Thêm nhân viên                                   |\n" +
                          "| 2. Hiển thị thông tin nhân viên                     |\n" +
                          "| 3. Tìm kiếm nhân viên                               |\n" +
                          "| 4. Xóa nhân viên                                    |\n" +
                          " ----------------------------------------------------- \n");
        }
        private int GenerateID()
        {
            int max = 0;
            foreach (NhanVien sv in listNhanVien)
            {
                if (max < sv.IdNhanVien)
                {
                    max = sv.IdNhanVien;
                }
            }
            return max+1;
        }
        private string CreateUserName( string tenNhanVien)
        {
            string userName, name;
            int spaceIndex = tenNhanVien.LastIndexOf(' ');
            name = generalMethod.convertToUnSign(tenNhanVien.Substring(spaceIndex + 1)); // Lấy phần sau khoảng trắng là tên
            Random random = new Random();
            userName = name.ToLower() + random.Next(100,999);
            return userName;
        }
        private string CreatePassword(string pass)
        {
            string passwordstr;
            int passwordint;
            Random random = new Random();
            passwordint = random.Next(1000, 9999);
            passwordstr = passwordint.ToString();
            return passwordstr;
        }
        private void PrintNhapNhanVien(string tenNV,int typeUser){
            Console.Clear();
            Console.WriteLine("0.Quay lại\n"+
                                " ------------------------------------------------------- \n" +
                                "| 1. Nhập tên nhân viên:{0,-32}|\n" +
                                "| 2. User/Admin (nhập 1/0):{1,-29}|\n" +
                                "| 3. Xác nhận                                           |\n" +
                                " ------------------------------------------------------- ",
                                tenNV,(typeUser==-1)?"":typeUser);
        }
        public void NhapNhanVien()
        {
            bool flag = true;
            string tennv = "";
            int typeUser = -1;
            while (flag)
            {
                PrintNhapNhanVien(tennv,typeUser);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        PrintNhapNhanVien("",typeUser);
                        Console.SetCursorPosition(24,2);
                        tennv = generalMethod.inputString(20,tennv);
                        break;
                    case ConsoleKey.D2:
                        PrintNhapNhanVien(tennv,-1);
                        Console.SetCursorPosition(27,3);
                        typeUser = generalMethod.inputInt(0,1);
                        break;
                    case ConsoleKey.D3:
                        if(tennv != "" && typeUser != -1){
                            NhanVien nhanVien = new NhanVien();
                            nhanVien.IdNhanVien = GenerateID();
                            nhanVien.UserName = CreateUserName(tennv);
                            nhanVien.PassWord = CreatePassword(nhanVien.PassWord);
                            nhanVien.TypeUser = typeUser;
                            nhanVien.TenNhanVien = tennv;
                            Console.Clear();
                            Console.WriteLine("Nhập thông tin nhân viên thành công !!!");
                            Console.WriteLine("Nhấn phím bất kỳ để tiếp tục");
                            Console.ReadKey(true);
                            listNhanVien.Add(nhanVien);
                            setDataNhanVien();
                            flag = false;
                        }
                        break;
                    case ConsoleKey.D0:
                        return;
                }
            }
        }
        public void PrintTimNhanVien()
        {
            Console.Clear();
            Console.WriteLine("0. Quay lại");
            Console.Write(" ----------------------------------------------------- \n" +
                          "| 1. Bắt đầu tìm nhân viên                            |\n" +
                          " ----------------------------------------------------- \n");
        }
        public List<NhanVien> TimTen(string keyword)
        {
            List<NhanVien> KqTimKiem = new List<NhanVien>();
            //tìm kiếm nhấn viên có tên trùng với keyword đang tìm
            foreach (NhanVien nv in listNhanVien)
            {
               if (nv.TenNhanVien.ToUpper() == keyword.ToUpper())
               {
                  KqTimKiem.Add(nv);
               }
            }
            if(KqTimKiem.Count != 0)  
            return KqTimKiem;
            else
            return null;
        }
        public void SapXep()
        {
            Console.Clear();
            Console.WriteLine("0. Quay lại");
            Console.Write(" ----------------------------------------------------- \n" +
                          "| 1. Sắp xếp theo tên nhân viên                       |\n" +
                          "| 2. Sắp xếp theo Id nhân viên                        |\n" +
                          "| 3. Sắp xếp theo giới tính                           |\n" +
                          " ----------------------------------------------------- \n");
        }
        public void ShowNhanVien(List<NhanVien> ListNhanVien)
        {
            string[] gioitinh = { "Nữ", "Nam" };
            string[] typeuser = { "member","admin" };
            Console.WriteLine("BẢNG THÔNG TIN NHÂN VIÊN");
            // Hiển thị tiêu đề cột 
            Console.WriteLine(" --------------------------------------------------------------------------------------------------------------- \n" +
                              "| Id |        Tên NV        | Sex |  BirthDay  |     CCCD     |     SDT     |  Type   |  Username  |  Password  |\n" +
                              " --------------------------------------------------------------------------------------------------------------- ");
            // hien thi danh sach sinh vien       
            foreach (NhanVien nhanvien in ListNhanVien)
            {
                Console.WriteLine("| {0, -3}| {1, -21}| {2, -4}| {3, -11}| {4,-13}| {5, -12}| {6,-8}| {7,-11}| {8,-11}|",
                nhanvien.IdNhanVien, nhanvien.TenNhanVien, gioitinh[nhanvien.GioiTinh],
                nhanvien.BirthDay, nhanvien.CCCD,nhanvien.SDT,
                typeuser[nhanvien.TypeUser],nhanvien.UserName,nhanvien.PassWord);
            }
            Console.WriteLine(" ---------------------------------------------------------------------------------------------------------------- ");
        }
        public void ShowNhanVien2()
        {
            string[] gioitinh = { "Nữ", "Nam" };
            string[] typeuser = { "member","admin" };
            Console.WriteLine("BẢNG THÔNG TIN NHÂN VIÊN");
            // Hiển thị tiêu đề cột 
            Console.WriteLine(" -------------------------------------------------------------------------------------\n" +
                              "| Id |        Tên NV        | Sex |  BirthDay  |     CCCD     |     SDT     |   Type  |\n" +
                              " -------------------------------------------------------------------------------------");
            // hien thi danh sach sinh vien       
            foreach (NhanVien nhanvien in listNhanVien)
            {
                Console.WriteLine("| {0, -3}| {1, -21}| {2, -4}| {3, -11}| {4,-13}| {5, -12}| {6,-8}|",
                nhanvien.IdNhanVien, nhanvien.TenNhanVien, gioitinh[nhanvien.GioiTinh],
                nhanvien.BirthDay, nhanvien.CCCD,nhanvien.SDT,
                typeuser[nhanvien.TypeUser]);
            }
            Console.WriteLine(" -------------------------------------------------------------------------------------");
        }
        public void SapXepTen()
        {
            listNhanVien.Sort((nv1, nv2) =>
            {
                //lấy ra khoảng cách cuối cùng
                int spaceIndex1 = nv1.TenNhanVien.LastIndexOf(' ');
                int spaceIndex2 = nv2.TenNhanVien.LastIndexOf(' ');
                return nv1.TenNhanVien.Substring(spaceIndex1 + 1).ToUpper().CompareTo(nv2.TenNhanVien.Substring(spaceIndex2 + 1).ToUpper());
            });
        }
        public void SapXepID()
        {
            listNhanVien.Sort
              (
                (nv1,nv2)=>
              {
                  return nv1.IdNhanVien.CompareTo(nv2.IdNhanVien);
              });
        }
        public void SapXepGioiTinh()
        {
            listNhanVien.Sort
                (
                (nv1,nv2)=>
                {
                    return nv1.GioiTinh.CompareTo(nv2.GioiTinh);
                }
                );
        }
        public void HienThiNhanVien(int choice){
            while (true)
            {
                SapXep();
                if(choice == 1)
                ShowNhanVien(listNhanVien);
                else
                ShowNhanVien2();
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        SapXepTen();
                        break;
                    case ConsoleKey.D2:
                        SapXepID();
                        break;
                    case ConsoleKey.D3:
                        SapXepGioiTinh();
                        break;
                    case ConsoleKey.D0:
                        SapXepID();
                        return;
                }
            } 
        }
        public void PrintXoaNhanVien(int id)
        {
            Console.Clear();
            Console.SetCursorPosition(18, 0);
            Console.WriteLine("XÓA NHÂN VIÊN");
            Console.WriteLine("0. Quay lại");
            Console.Write(" ----------------------------------------------------- \n" +
                          "| 1. Nhập mã nhân viên:{0,-31}|\n" +
                          "| 2. Xác nhận !                                       |\n" +
                          " ----------------------------------------------------- ",(id==-1)?"":id);
        }
        public int inputId()
        {
            Console.SetCursorPosition(23,3);
            int id = generalMethod.inputInt(1,99);
            return id;
        }
        public NhanVien TimId(int IdNhanVien)
        {
            NhanVien result = listNhanVien.Find(x => x.IdNhanVien ==  IdNhanVien);
            return result;
        }
        public bool XoaNhanVien(int IdNhanVien)
        {
            bool Xoa = false;
            // tìm kiếm sinh viên theo ID
            NhanVien nhanvien = (TimId(IdNhanVien));
            if (nhanvien != null)
            {
                Xoa = listNhanVien.Remove(nhanvien);
                setDataNhanVien();
                Console.WriteLine("Xóa thành công\nNhấn phím bất kỳ để tiếp tục");
                Console.ReadKey();
            }
            else{
                Console.WriteLine("Không tìm thấy Id\nNhấn phím bất kỳ để tiếp tục");
                Console.ReadKey();
            } 
            return Xoa;
        }
        private string fileNhanVien = "nhanvien.txt";
        public void getDataNhanVien(){
            //using này để lấy dữ liệu vào cái list. đưa vào try catch để kiểm tra lỗi file
            try
                {
                    using(StreamReader sr = new StreamReader(fileNhanVien)){
                        string tmp;
                        //Đến cuối file sẽ trả về con trỏ null nên là khác null
                        while((tmp = sr.ReadLine())!=null){
                            listNhanVien.Add(new NhanVien(
                            int.Parse(tmp),sr.ReadLine(),sr.ReadLine(),
                            int.Parse(sr.ReadLine()),sr.ReadLine(),sr.ReadLine(),
                            int.Parse(sr.ReadLine()),sr.ReadLine(),sr.ReadLine()));
                        }
                    }
                }
            //nếu không thấy file thì báo lỗi
                catch (FileNotFoundException)
                {
                    Console.SetCursorPosition(0,0);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine(
                        " ---------------------------------------------- \n" +
                        "|                                              |\n" +
                        "|       Không tìm thấy dữ liệu nhân viên       |\n" +
                        "|          Nhấn phím bất kỳ để thoát           |\n" +
                        "|                                              |\n" +
                        " ---------------------------------------------- "
                    );
                    Console.ReadKey();
                    return;
                }
        }
        public void setDataNhanVien(){
            //using này để ghi dữ liệu vào file
            using(StreamWriter wr = new StreamWriter(fileNhanVien)){
                foreach (NhanVien item in listNhanVien)
                {
                    wr.WriteLine(item.IdNhanVien);
                    wr.WriteLine(item.UserName);
                    wr.WriteLine(item.PassWord);
                    wr.WriteLine(item.TypeUser);
                    wr.WriteLine(item.TenNhanVien);
                    wr.WriteLine(item.BirthDay);
                    wr.WriteLine(item.GioiTinh);
                    wr.WriteLine(item.CCCD);
                    wr.WriteLine(item.SDT);
                }
                wr.Flush();
            }
        }
    }
}